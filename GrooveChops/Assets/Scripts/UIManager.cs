using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool MidiOK = false;
    public bool Mp3OK = false;

    [SerializeField]
    GameObject noteCanvas;

    [SerializeField]
    TMP_Text midi;

    [SerializeField]
    TMP_Text mp3;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMidi(string midiName)
    {
        midi.text = midiName;
    }

    public void UpdateMp3(string mp3Name)
    {
        mp3.text = mp3Name;
    }

    public void StartGamePressed()
    {
        if (Mp3OK && MidiOK)
        {
            GameManager.Instance.StartGame();
            noteCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
