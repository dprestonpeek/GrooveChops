using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Song : MonoBehaviour
{
    public string Name;
    public string Artist;
    public string SongPath;
    public string MidiFile;
    public string Mp3File;
    public string MapFile;
    public string InfoFile;

    public Song(string name, string artist, string songPath)
    {
        Name = name;
        Artist = artist;
        SongPath = songPath;
        GetSongFiles();
    }

    public void UpdateInfo(string name, string artist, string songPath)
    {
        Name = name;
        Artist = artist;
        SongPath = songPath;
        GetSongFiles();
    }

    public void PickSong()
    {
        GameManager.Instance.PickSong(this);
    }

    public void GetSongFiles()
    {
        try
        {
            foreach (string file in Directory.GetFiles(SongPath))
            {
                if (file.Contains(".mid") || file.Contains(".midi"))
                {
                    MidiFile = file;
                }
                if (file.Contains(".mp3"))
                {
                    Mp3File = file;
                }
                if (file.Contains("drummap.txt"))
                {
                    MapFile = file;
                }
                if (file.Contains("info.txt"))
                {
                    InfoFile = file;
                }
            }
        }
        catch (Exception ex)
        {
            UIManager.Instance.ShowErrorWindow(ex.Message);
        }
    }
}

public class SongInfo
{
    public string Name;
    public string Artist;
    public string SongPath;
    public string MidiFile;
    public string Mp3File;
    public string MapFile;
    public string InfoFile;
    

    public SongInfo(string name, string artist, string songPath)
    {
        Name = name;
        Artist = artist;
        SongPath = songPath;
        GetSongFiles();
    }
    public void GetSongFiles()
    {
        try
        {
            foreach (string file in Directory.GetFiles(SongPath))
            {
                if (file.Contains(".mid") || file.Contains(".midi"))
                {
                    MidiFile = file;
                }
                if (file.Contains(".mp3"))
                {
                    Mp3File = file;
                }
                if (file.Contains("drummap.txt"))
                {
                    MapFile = file;
                }
                if (file.Contains("info.txt"))
                {
                    InfoFile = file;
                }
            }
        }
        catch (Exception ex)
        {
            UIManager.Instance.ShowErrorWindow(ex.Message);
        }
    }
}