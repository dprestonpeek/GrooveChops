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
        //UpdateMidi(GameManager.Instance.pickedSong.MidiFile);
        //UpdateMp3(GameManager.Instance.pickedSong.Mp3File);
        //UpdateMap(GameManager.Instance.pickedSong.MapFile);
        //UpdateInfo(GameManager.Instance.pickedSong.InfoFile);

        GameManager.Instance.PrepareGame();
        GameManager.Instance.StartGame();
        noteCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
