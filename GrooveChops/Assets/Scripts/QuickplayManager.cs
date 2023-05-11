using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class QuickplayManager : MonoBehaviour
{
    public static QuickplayManager Instance;

    public Song selectedSong;

    [SerializeField]
    GameObject songsObj;

    int numSongs = 0;
    int numCounter = 0;
    GameObject selectedSongObj;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickSong(Song pickedSong)
    {
        AddSongButton(pickedSong);
        GameManager.Instance.pickedSongs.Add(pickedSong);
        numSongs++;
    }

    public void RefreshPickedSongs()
    {
        ClearPickedSongs();
        for (int i = 0; i < GameManager.Instance.pickedSongs.Count; i++)
        {
            AddSongButton(GameManager.Instance.pickedSongs[i]);
        }
    }

    public void ClearPickedSongs()
    {
        numCounter = 0;
        foreach (Song song in songsObj.GetComponentsInChildren<Song>())
        {
            Destroy(song.gameObject);
        }
    }

    public void RemoveSong()
    {
        GameManager.Instance.RemoveSongFromPicked(selectedSong);
        selectedSongObj = selectedSong.gameObject;
        Destroy(selectedSongObj);
        numSongs--;
        RefreshPickedSongs();
    }

    private void AddSongButton(Song pickedSong)
    {
        GameObject songObj = Instantiate(Library.Instance.songPrefab, Vector3.zero, Quaternion.identity, songsObj.transform);
        Song song = songObj.GetComponent<Song>();
        song.UpdateInfo(pickedSong.Name, pickedSong.Artist, pickedSong.SongPath);
        TMP_Text songText = songObj.GetComponentInChildren<TMP_Text>();
        songText.text = pickedSong.Artist + " - " + pickedSong.Name;
        Vector3 newPos = Vector3.zero;
        newPos.y = numCounter * Library.Instance.songSpacing * -1;
        songObj.transform.localPosition = newPos;
        //GameManager.Instance.pickedSongs.Add(pickedSong);
        RightClick rc = songObj.GetComponentInChildren<RightClick>();
        rc.leftClick = null;
        rc.rightClick.AddListener(RemoveSong);
        numCounter++;
    }
}
