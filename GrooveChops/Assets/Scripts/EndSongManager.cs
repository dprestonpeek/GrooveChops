using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSongManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text SongInfo;

    // Start is called before the first frame update
    void Start()
    {
        Song currentSong = GameManager.Instance.pickedSong;
        SongInfo.text = currentSong.Artist + " - " +currentSong.Name;
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

    public void PickAnotherSong()
    {
        gameObject.SetActive(false);
        UIManager.Instance.PickAnotherSong();
    }

    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }
}
