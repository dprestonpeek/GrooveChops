using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField]
    Slider qualitySlider;

    [SerializeField]
    TMP_Text qualityValue;

    [SerializeField]
    Toggle fullScreenValue;

    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    TMP_Text volumeValue;

    string[] qualityNames;
    int qualityIndex = 3;

    // Start is called before the first frame update
    void Start()
    {
        qualityNames = QualitySettings.names;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadVideoOptionValues()
    {
        fullScreenValue.isOn = Screen.fullScreen;
        qualitySlider.value = PlayerPrefs.GetInt("Quality", 3);
    }

    public void ToggleFullscreen()
    {
        if (fullScreenValue.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void AdjustVolume()
    {
        int value = Mathf.RoundToInt(volumeSlider.value * 100);
        volumeValue.text = value.ToString();
    }

    public void ApplyVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void AdjustQuality()
    {
        int value = Mathf.RoundToInt(qualitySlider.value);
        qualityValue.text = qualityNames[value];
        qualityIndex = value;
    }

    public void ApplyQuality()
    {
        QualitySettings.SetQualityLevel(int.Parse(qualityValue.text));
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void ChangeKeyBinding()
    {

    }
}
