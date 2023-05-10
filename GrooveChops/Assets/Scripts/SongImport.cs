using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SongImport : MonoBehaviour
{
    [SerializeField]
    TMP_Text selection;

    [SerializeField]
    GameObject songPrefab;

    [SerializeField]
    GameObject songsObj;

    private string MidiFile = "";
    private string Mp3File = "";
    private string MapFile = "";
    private string InfoFile = "";
    private string ImportFile = "";
    private string[] ImportFiles = new string[0];

    public void SetMidiFile(string midiFile)
    {
        MidiFile = midiFile;
    }

    public void SetMp3File(string mp3File)
    {
        Mp3File = mp3File;
    }

    public void SetMapFile(string mapFile)
    {
        MapFile = mapFile;
    }

    public void SetInfoFile(string infoFile)
    {
        InfoFile = infoFile;
    }

    public void SetImportFile(string importFile)
    {
        ImportFile = importFile;
    }

    public void SetImportFiles(string[] importFiles)
    {
        ImportFiles = importFiles;
        DisplaySelection(importFiles);
    }

    public void ImportSongs()
    {
        foreach (string song in ImportFiles)
        {
            SongManager.Instance.UnpackImportedSong(song);
        }
    }

    public void ImportSong()
    {
        if (MidiFile == ""  || Mp3File == "" || MapFile == "" || InfoFile == "")
        {
            SongManager.Instance.UnpackImportedSong(ImportFile);
        }
        else
        {
            string[] info = GetSongInfo();
            SongManager.Instance.AddNewSong(info[1], info[0], MidiFile, Mp3File, MapFile, InfoFile);
        }
    }

    public void ResetSelection()
    {
        foreach (Song song in songsObj.GetComponentsInChildren<Song>())
        {
            Destroy(song.gameObject);
        }
    }

    public void DisplaySelection(string[] songs)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            GameObject song = Instantiate(songPrefab, Vector3.zero, Quaternion.identity, songsObj.transform);
            TMP_Text songObj = song.GetComponentInChildren<TMP_Text>();
            songObj.text = Path.GetFileNameWithoutExtension(songs[i]);
            Vector3 newPos = Vector3.zero;
            newPos.y = i * Library.Instance.songSpacing * -1;
            song.transform.localPosition = newPos;
        }
    }

    private string[] GetSongInfo()
    {
        return File.ReadAllLines(InfoFile);
    }
}
