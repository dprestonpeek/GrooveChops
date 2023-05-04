using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrumMapManager : MonoBehaviour
{
    string[] drumMapData = new string[10];
    string loadedDrumMap = "";

    string mapPath = "";

    // Start is called before the first frame update
    void Start()
    {
        loadedDrumMap = PlayerPrefs.GetString("drummap");
        if (loadedDrumMap == "")
        {
            ResetDrumMap();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadDrumMapFromPath(string path)
    {
        mapPath = path;
        //Read in the new map
        LoadDrumMap(File.ReadAllLines(mapPath));
    }

    public void LoadDrumMap(string[] mapData)
    {
        try
        {
            for (int line = 0; line < mapData.Length; line++)
            {
                //Get the map for each drum
                string[] split = mapData[line].Split('=');

                //Get each note and add it to the current map line
                string[] notes = split[1].Split(',');
                int[] mapline = new int[notes.Length];
                for (int note = 0; note < notes.Length; note++)
                {
                    mapline[note] = int.Parse(notes[note]);
                }
                Tracks.DrumMap.Map[line] = mapline;
            }
            UIManager.Instance.UpdateMap(Path.GetFileName(mapPath));
        }
        catch (Exception ex)
        {
            UIManager.Instance.ShowErrorWindow(ex.Message);
        }
    }

    public void ResetDrumMap()
    {
        Tracks.DrumMap.Map = Tracks.DrumMap.DefaultMap;
    }
}
