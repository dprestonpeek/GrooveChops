using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteColorPicker : MonoBehaviour
{
    public static NoteColorPicker Instance;

    [SerializeField]
    GameObject colorPicker;

    [SerializeField]
    GameObject NoteConfigHitLine;

    [SerializeField]
    GameObject DrumConfigHitLine;

    [SerializeField]
    GameObject noteHitLineDefaults;
    [SerializeField]
    GameObject drumHitLineDefaults;

    [SerializeField]
    GameObject noteButtons;

    [SerializeField]
    Toggle HighMid;
    [SerializeField]
    Toggle LowMid;
    [SerializeField]
    Toggle RightCrash;
    [SerializeField]
    Toggle China;

    [HideInInspector]
    public GameObject hoveredButton;
    private TMP_InputField changingField;

    private float buttonXSize;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPicker()
    {
        if (hoveredButton)
        {
            colorPicker.SetActive(true);
            Vector3 newPos = colorPicker.transform.localPosition;
            if (hoveredButton.transform.localPosition.x < -250)
            {
                newPos.x = -130;
            }
            else
            {
                newPos.x = 155;
            }
            colorPicker.transform.localPosition = newPos;
        }
    }

    public void ClosePickerAndSetColor()
    {
        colorPicker.SetActive(false);
        Color color = colorPicker.GetComponent<FlexibleColorPicker>().color;
        hoveredButton.GetComponent<Image>().color = color;
        UpdateHitLineColor(hoveredButton.name, color);
        SaveColors();
    }

    public void SetHoveredButton(GameObject button)
    {
        if (!colorPicker.activeSelf)
        {
            hoveredButton = button;
        }
    }

    public void AdjustSize()
    {
        int optionalDrums = 0;
        List<string> removedDrums = new List<string>();
        if (HighMid.isOn)
        {
            optionalDrums++;
        }
        else
        {
            removedDrums.Add("Tom1");
        }
        if (LowMid.isOn)
        {
            optionalDrums++;
        }
        else
        {
            removedDrums.Add("Tom2");
        }
        if (RightCrash.isOn)
        {
            optionalDrums++;
        }
        else
        {
            removedDrums.Add("RightCrash");
        }
        if (China.isOn)
        {
            optionalDrums++;
        }
        else
        {
            removedDrums.Add("China");
        }
        int currentDrums = 5 + optionalDrums;
        float noteSize = 9 / (float)currentDrums;
        foreach (MeshRenderer obj in DrumConfigHitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (removedDrums.Contains(obj.name)) 
            {
                obj.gameObject.SetActive(false);
                continue;
            }
            else
            {
                obj.gameObject.SetActive(true);
            }
            if (obj.gameObject.activeSelf && !obj.name.Contains("Kick"))
            {
                Vector3 newScale = obj.transform.localScale;
                newScale.x = noteSize;
                obj.transform.localScale = newScale;
            }
        }
    }

    public void LoadSize()
    {

    }

    public void SaveSize()
    {

    }

    public void LoadColors()
    {
        if (PlayerPrefs.GetInt("SaveDataExists") == 0)
        {
            CreateSaveData();
        }
        foreach (MeshRenderer obj in NoteConfigHitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                Color color = obj.sharedMaterial.color;
                color.r = PlayerPrefs.GetFloat(obj.name + "-Color-R");
                color.g = PlayerPrefs.GetFloat(obj.name + "-Color-G");
                color.b = PlayerPrefs.GetFloat(obj.name + "-Color-B");
                color.a = PlayerPrefs.GetFloat(obj.name + "-Color-A");
                obj.sharedMaterial.color = color;
                GetButtonImage(obj.name).color = color;
            }
        }
    }

    public void LoadOrder()
    {
        foreach (TMP_InputField field in noteButtons.GetComponentsInChildren<TMP_InputField>())
        {
            string name = field.transform.parent.name;
            GameObject hitLineObj = GetHitLineObj(name);
            if (!hitLineObj)
            {
                return;
            }
            float pos = PlayerPrefs.GetFloat(name + "-Pos");
            field.text = pos.ToString();
            Vector3 newPos = hitLineObj.transform.localPosition;
            newPos.x = pos;
            hitLineObj.transform.localPosition = newPos;
        }
    }

    public void SelectInputField(TMP_InputField inputField)
    {
        changingField = inputField;
    }

    public void UpdateHitLineOrder()
    {
        if (changingField && changingField.text != "")
        {
            int enteredLoc = int.Parse(changingField.text);
            if (enteredLoc > 4)
            {
                enteredLoc = 4;
            }
            if (enteredLoc < -4)
            {
                enteredLoc = -4;
            }
            float oldLoc = -99;
            foreach (Transform obj in NoteConfigHitLine.GetComponentsInChildren<Transform>())
            {
                if (obj.gameObject.activeSelf)
                {
                    if (obj.name == changingField.transform.parent.name)
                    {
                        Vector3 newPos = obj.transform.localPosition;
                        oldLoc = newPos.x;
                        newPos.x = enteredLoc;
                        obj.transform.localPosition = newPos;
                        break;
                    }
                }
            }
            if (oldLoc != -99)
            {
                foreach (Transform obj in NoteConfigHitLine.GetComponentsInChildren<Transform>())
                {
                    if (obj.gameObject.activeSelf)
                    {
                        if (obj.name != changingField.transform.parent.name)
                        {
                            if (obj.transform.localPosition.x == enteredLoc)
                            {
                                Vector3 newPos = obj.transform.localPosition;
                                newPos.x = oldLoc;
                                obj.transform.localPosition = newPos;
                                GetInputField(obj.name).text = newPos.x.ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    private GameObject GetHitLineObj(string name)
    {
        foreach (Transform obj in NoteConfigHitLine.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.activeSelf && obj.name == name)
            {
                return obj.gameObject;
            }
        }
        return null;
    }

    private GameObject GetNoteObj(string name)
    {
        foreach (Transform obj in noteButtons.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.activeSelf && obj.name == name)
            {
                return obj.gameObject;
            }
        }
        return null;
    }

    private TMP_InputField GetInputField(string name)
    {
        foreach (TMP_InputField obj in noteButtons.GetComponentsInChildren<TMP_InputField>())
        {
            if (obj.gameObject.activeSelf && obj.transform.parent.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    private Image GetButtonImage(string name)
    {
        foreach (Image obj in noteButtons.GetComponentsInChildren<Image>())
        {
            if (obj.gameObject.activeSelf && obj.transform.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    private float GetNewXPos(int initPos)
    {
        return initPos * buttonXSize;
    }

    private void UpdateHitLineColor(string name, Color color)
    {
        foreach (Transform obj in NoteConfigHitLine.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.activeSelf && obj.name == name)
            {
                obj.GetComponent<MeshRenderer>().sharedMaterial.color = color;
            }
        }
    }

    public void SaveColors()
    {
        foreach (MeshRenderer obj in NoteConfigHitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                PlayerPrefs.SetFloat(obj.name + "-Color-R", obj.sharedMaterial.color.r);
                PlayerPrefs.SetFloat(obj.name + "-Color-G", obj.sharedMaterial.color.g);
                PlayerPrefs.SetFloat(obj.name + "-Color-B", obj.sharedMaterial.color.b);
                PlayerPrefs.SetFloat(obj.name + "-Color-A", obj.sharedMaterial.color.a);
            }
        }
    }

    public void SaveOrder()
    {
        foreach (TMP_InputField field in noteButtons.GetComponentsInChildren<TMP_InputField>())
        {
            if (field.text != "")
            {
                PlayerPrefs.SetFloat(field.transform.parent.name + "-Pos", int.Parse(field.text));
            }
        }
    }

    public void ResetProperties()
    {
        MeshRenderer[] hitLineObjs = NoteConfigHitLine.GetComponentsInChildren<MeshRenderer>();
        MeshRenderer[] defaultObjs = noteHitLineDefaults.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < hitLineObjs.Length; i++)
        {
            MeshRenderer obj = hitLineObjs[i];
            MeshRenderer defObj = defaultObjs[i];

            if (obj.gameObject.activeSelf)
            {
                obj.sharedMaterial.color = defObj.sharedMaterial.color;
                obj.gameObject.transform.localPosition = defObj.gameObject.transform.localPosition;
                GetButtonImage(obj.name).color = obj.sharedMaterial.color;
                if (obj.name != "Kick")
                {
                    GetInputField(obj.name).text = Mathf.RoundToInt(obj.gameObject.transform.localPosition.x).ToString();
                }
            }
        }
    }

    public void CreateSaveData()
    {
        SaveColors();
        SaveOrder();
        PlayerPrefs.SetInt("SaveDataExists", 1);
    }
}
