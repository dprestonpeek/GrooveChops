using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool MidiOK = false;
    public bool Mp3OK = false;
    public bool MapOK = false;

    [SerializeField]
    GameObject noteCanvas;

    [SerializeField]
    GameObject errorWindow;
    [SerializeField]
    TMP_Text errorWindowText;

    //[SerializeField]
    //TMP_Text midi;

    //[SerializeField]
    //TMP_Text mp3;

    //[SerializeField]
    //TMP_Text map;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateInfo(string infoName)
    {

    }

    public void ShowErrorWindow(string errorMsg)
    {
        errorWindowText.text = errorMsg;
        errorWindow.SetActive(true);
    }

    public void StartGamePressed()
    {
        GameManager.Instance.PrepareGame();
        GameManager.Instance.StartGame();
        noteCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        noteCanvas.SetActive(false);
        gameObject.SetActive(true);
    }

    public void PickAnotherSong()
    {
        if (!gameObject.activeSelf)
        {
            ShowMenu();
        }
        Library.Instance.DisplayLibrary();
        VideoManager.Instance.DeactivateVideo();
    }
}
