
using AnotherFileBrowser.Windows;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FileBrowserUpdate : MonoBehaviour
{
    [SerializeField]
    TMP_Text filename;
    [SerializeField]
    MidiManager midiManager;
    [SerializeField]
    AudioSource audioPlayer;
    [SerializeField]
    DrumMapManager mapManager;
    [SerializeField]
    SongImport songImport;

    [SerializeField]
    bool midiBrowser = false;
    [SerializeField]
    bool mp3Browser = false;
    [SerializeField]
    bool drumMapBrowser = false;
    [SerializeField]
    bool infoFileBrowser = false;

    public static FileBrowserUpdate midiInstance;
    public static FileBrowserUpdate mp3Instance;
    public static FileBrowserUpdate mapInstance;
    public static FileBrowserUpdate infoInstance;

    private void Start()
    {
        if (midiBrowser)
        {
            midiInstance = this;
        }
        else if (mp3Instance)
        {
            mp3Instance = this;
        }
        else if (drumMapBrowser)
        {
            mapInstance = this;
        }
        else if (infoFileBrowser)
        {
            infoInstance = this;
        }
    }

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        //bp.filter = "Midi files (*.mid, *.midi)";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Load image from local path with UWR
            //StartCoroutine(LoadImage(path));
            if (midiBrowser)
            {
                midiManager.LoadMidiFromPath(path);
                if (songImport)
                {
                    songImport.SetMidiFile(path);
                }
            }
            if (mp3Browser)
            {
                AudioManager.Instance.LoadAudioFromPath(path);
                if (songImport)
                {
                    songImport.SetMp3File(path);
                }
            }
            if (drumMapBrowser)
            {
                mapManager.LoadDrumMapFromPath(path);
                if (songImport)
                {
                    songImport.SetMapFile(path);
                }
            }
            if (infoFileBrowser)
            {
                if (songImport)
                {
                    songImport.SetInfoFile(path);
                }
            }
            if (filename)
            {
                filename.text = Path.GetFileName(path);
            }
        });
    }
}
