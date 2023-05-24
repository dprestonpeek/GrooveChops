using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public static ControlManager Instance;

    [SerializeField]
    GameObject Notes;

    [SerializeField]
    GameObject HitLine;

    TMP_InputField[] inputFields;
    TMP_Text[] noteLabels;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        inputFields = Notes.transform.GetComponentsInChildren<TMP_InputField>();
        noteLabels = HitLine.transform.GetComponentsInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLabels()
    {
        foreach (TMP_Text label in noteLabels)
        {
            foreach (TMP_InputField input in inputFields)
            {
                if (label.name == input.transform.parent.name)
                {
                    label.text = input.text;
                }
            }
        }
    }
}
