using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class QuickplayManager : MonoBehaviour
{
    public static QuickplayManager Instance;

    [SerializeField]
    GameObject songsObj;

    int numSongs = 0;

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
        GameObject song = Instantiate(Library.Instance.songPrefab, Vector3.zero, Quaternion.identity, songsObj.transform);
        TMP_Text songObj = song.GetComponentInChildren<TMP_Text>();
        songObj.text = pickedSong.Artist + " - " + pickedSong.Name;
        Vector3 newPos = Vector3.zero;
        newPos.y = numSongs * Library.Instance.songSpacing * -1;
        song.transform.localPosition = newPos;
        GameManager.Instance.pickedSongs.Add(pickedSong);
        numSongs++;
    }
}
