using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongImport : MonoBehaviour
{
    public string MidiFile = "";
    public string Mp3File = "";
    public string MapFile = "";
    public string InfoFile = "";

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

    public void ImportSong()
    {
        string[] info = GetSongInfo();
        SongManager.Instance.AddNewSong(info[1], info[0], MidiFile, Mp3File, MapFile, InfoFile);
    }

    private string[] GetSongInfo()
    {
        return File.ReadAllLines(InfoFile);
    }
}
