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
    GameObject hitLine;

    [SerializeField]
    GameObject noteButtons;

    [HideInInspector]
    public GameObject hoveredButton;
    private TMP_InputField changingField;

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

    public void LoadColors()
    {
        if (PlayerPrefs.GetInt("SaveDataExists") == 0)
        {
            CreateSaveData();
        }
        foreach (MeshRenderer obj in hitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                Color color = obj.material.color;
                color.r = PlayerPrefs.GetFloat(obj.name + "-Color-R");
                color.g = PlayerPrefs.GetFloat(obj.name + "-Color-G");
                color.b = PlayerPrefs.GetFloat(obj.name + "-Color-B");
                color.a = PlayerPrefs.GetFloat(obj.name + "-Color-A");
                obj.material.color = color;
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
            foreach (Transform obj in hitLine.GetComponentsInChildren<Transform>())
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
                foreach (Transform obj in hitLine.GetComponentsInChildren<Transform>())
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
        foreach (Transform obj in hitLine.GetComponentsInChildren<Transform>())
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

    private void UpdateHitLineColor(string name, Color color)
    {
        foreach (Transform obj in hitLine.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.activeSelf && obj.name == name)
            {
                obj.GetComponent<MeshRenderer>().material.color = color;
            }
        }
    }

    public void SaveColors()
    {
        foreach (MeshRenderer obj in hitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                PlayerPrefs.SetFloat(obj.name + "-Color-R", obj.material.color.r);
                PlayerPrefs.SetFloat(obj.name + "-Color-G", obj.material.color.g);
                PlayerPrefs.SetFloat(obj.name + "-Color-B", obj.material.color.b);
                PlayerPrefs.SetFloat(obj.name + "-Color-A", obj.material.color.a);
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

    private void CreateSaveData()
    {
        SaveColors();
        SaveOrder();
        PlayerPrefs.SetInt("SaveDataExists", 1);
    }
}
