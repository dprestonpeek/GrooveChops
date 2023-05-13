using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndSongManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text SongInfo;

    [SerializeField]
    GameObject SongsObj;

    // Start is called before the first frame update
    void Start()
    {
        Song currentSong = GameManager.Instance.currentSong;
        List<Song> gigSongs = GameManager.Instance.pickedSongs;
        if (SongsObj)
        {
            for (int i = 0; i < gigSongs.Count; i++)
            {
                GameObject spawnedSong = Instantiate(Library.Instance.songPrefab, Vector3.zero, Quaternion.identity, SongsObj.transform);
                spawnedSong.GetComponentInChildren<RightClick>().enabled = false;
                Vector3 newPos = Vector3.zero;
                newPos.y = i * Library.Instance.songSpacing * -1;
                spawnedSong.transform.localPosition = newPos;
                spawnedSong.GetComponentInChildren<TMP_Text>().text = gigSongs[i].Artist + " - " + gigSongs[i].Name;
            }
        }
        if (SongInfo)
        {
            SongInfo.text = currentSong.Artist + " - " + currentSong.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAgain()
    {
        gameObject.SetActive(false);
        UIManager.Instance.StartGamePressed();
    }

    public void RestartGig()
    {
        gameObject.SetActive(false);
        GameManager.Instance.songIndex = 0;
        UIManager.Instance.StartGamePressed();
    }

    public void PlayNextSong()
    {
        gameObject.SetActive(false);
        VideoManager.Instance.DeactivateVideo();
        GameManager.Instance.NextSong();
        UIManager.Instance.StartGamePressed();
    }

    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }
}
