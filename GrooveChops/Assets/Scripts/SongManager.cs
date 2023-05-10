using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    string libraryPath;
   
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        libraryPath = Path.Combine(Application.persistentDataPath, "SongLibrary");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewSong(string songLocation)
    {
        string midiPath = "";
        string mp3Path = "";
        string mapPath = "";
        string infoPath = "";
        string mp4Path = "";
        string[] info = new string[2];

        try
        {
            foreach (string file in Directory.GetFiles(songLocation))
            {
                if (file.Contains(".mid") || file.Contains(".midi"))
                {
                    midiPath = file;
                }
                if (file.Contains(".mp3"))
                {
                    mp3Path = file;
                }
                if (file.Contains("drummap.txt"))
                {
                    mapPath = file;
                }
                if (file.Contains("info.txt"))
                {
                    infoPath = file;
                    info = File.ReadAllLines(infoPath);
                }
                if (file.Contains(".mp4"))
                {
                    mp4Path = file;
                }
            }
        }
        catch (Exception ex)
        {
            UIManager.Instance.ShowErrorWindow(ex.Message);
            return;
        }
        AddNewSong(info[1], info[0], midiPath, mp3Path, mapPath, infoPath, mp4Path);
    }

    public void AddNewSong(string songName, string artistName, string midiPath, string mp3Path, string mapPath, string infoPath)
    {
        AddNewSong(songName, artistName, midiPath, mp3Path, mapPath, infoPath, "");
    }

    public void AddNewSong(string songName, string artistName, string midiPath, string mp3Path, string mapPath, string infoPath, string mp4Path)
    {
        string artistPath = Path.Combine(libraryPath, artistName);
        string songPath = Path.Combine(artistPath, songName);

        //Create the library directory
        if (!Directory.Exists(libraryPath))
        {
            Directory.CreateDirectory(libraryPath);
        }
        //Create the artist directory
        if (!Directory.Exists(artistPath))
        {
            Directory.CreateDirectory(artistPath);
        }
        //Create the song directory
        if (!Directory.Exists(songPath))
        {
            Directory.CreateDirectory(songPath);
        }
        //Copy the files into the song directory
        File.Copy(midiPath, Path.Combine(songPath, Path.GetFileName(midiPath)));
        File.Copy(mp3Path, Path.Combine(songPath, Path.GetFileName(mp3Path)));
        File.Copy(mapPath, Path.Combine(songPath, Path.GetFileName(mapPath)));
        File.Copy(infoPath, Path.Combine(songPath, Path.GetFileName(infoPath)));
        if (mp4Path != "")
        {
            File.Copy(mp4Path, Path.Combine(songPath, Path.GetFileName(mp4Path)));
        }
    }

    public Song LoadSongFromLibrary(string songName, string artistName)
    {
        string artistPath = Path.Combine(libraryPath, artistName);
        string songPath = Path.Combine(artistPath, songName);

        string midiPath = "";
        string mp3Path = "";
        string mapPath = "";
        string infoPath = "";
        string mp4Path = "";

        try
        {
            foreach(string file in Directory.GetFiles(songPath))
            {
                if (file.Contains(".mid") || file.Contains(".midi"))
                {
                    midiPath = file;
                }
                if (file.Contains(".mp3"))
                {
                    mp3Path = file;
                }
                if (file.Contains("drummap.txt"))
                {
                    mapPath = file;
                }
                if (file.Contains("info.txt"))
                {
                    infoPath = file;
                }
                if (file.Contains(".mp4"))
                {
                    mp4Path = file;
                }
            }
        }
        catch(Exception ex)
        {
            UIManager.Instance.ShowErrorWindow(ex.Message);
            return null;
        }

        if (midiPath != "" && mp3Path != "")
        {
            Song newSong = new Song(Path.GetDirectoryName(songPath), Path.GetDirectoryName(artistPath), songPath);
            return newSong;
        }
        return null;
    }

    public void UnpackImportedSong(string importedFile)
    {
        string newImportedPath = Path.Combine(libraryPath, "Import");
        string newImportedFile = Path.Combine(newImportedPath, Path.GetFileName(importedFile));
        ZipFile.ExtractToDirectory(importedFile, newImportedPath);
        AddNewSong(newImportedPath);
        Directory.Delete(newImportedPath, true);
    }

    public void ExportSong(string songName, string artistName, string exportPath)
    {
        string artistPath = Path.Combine(libraryPath, artistName);
        string songPath = Path.Combine(artistPath, songName);
        ZipFile.CreateFromDirectory(songPath, exportPath);
    }

    public void ImportLibrary(string exportedLibraryPath)
    {
        //Create the library directory
        if (!Directory.Exists(libraryPath))
        {
            Directory.CreateDirectory(libraryPath);
        }
        ZipFile.ExtractToDirectory(exportedLibraryPath, libraryPath);
    }

    public void ExportLibrary()
    {
        string libraryPath = Path.Combine(Application.persistentDataPath, "SongLibrary");
        string exportPath = Path.Combine(Application.persistentDataPath, "Export");

        if (Directory.Exists(exportPath))
        {
            Directory.Delete(exportPath, true);
        }
        Directory.CreateDirectory(exportPath);

        string zipPath = Path.Combine(exportPath, "GrooveSnapLibrary" + ".gslib");

        //Create the zip file
        ZipFile.CreateFromDirectory(libraryPath, zipPath);
    }

    public void OpenLibraryFolder()
    {
        Process.Start("explorer.exe", libraryPath);
    }
}
