
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
    bool midiBrowser = false;
    [SerializeField]
    bool mp3Browser = false;
    [SerializeField]
    bool drumMapBrowser = false;

    public static FileBrowserUpdate midiInstance;
    public static FileBrowserUpdate mp3Instance;
    public static FileBrowserUpdate mapInstance;

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
            }
            if (mp3Browser)
            {
                AudioManager.Instance.LoadAudioFromPath(path);
            }
            if (drumMapBrowser)
            {
                mapManager.LoadDrumMapFromPath(path);
            }
        });
    }

    //IEnumerator LoadAudio(string path)
    //{
    //    using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
    //    {
    //        yield return uwr.SendWebRequest();

    //        if (uwr.isNetworkError || uwr.isHttpError)
    //        {
    //            Debug.Log(uwr.error);
    //        }
    //        else
    //        {
    //            var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
    //            rawImage.texture = uwrTexture;
    //        }
    //    }
    //}

    //IEnumerator LoadImage(string path)
    //{
    //    using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
    //    {
    //        yield return uwr.SendWebRequest();

    //        if (uwr.isNetworkError || uwr.isHttpError)
    //        {
    //            Debug.Log(uwr.error);
    //        }
    //        else
    //        {
    //            var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
    //            rawImage.texture = uwrTexture;
    //        }
    //    }
    //}
}
