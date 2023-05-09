using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Song pickedSong;

    bool gig = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        AudioManager.Instance.PlayDelayed();
        MidiManager.Instance.player.MPTK_Play();
    }

    public void PrepareGame()
    {
        AudioManager.Instance.LoadAudioFromPath(pickedSong.Mp3File);
        MidiManager.Instance.LoadMidiFromPath(pickedSong.MidiFile);
        DrumMapManager.Instance.LoadDrumMapFromPath(pickedSong.MapFile);
        if (pickedSong.Mp4File != "")
        {
            VideoManager.Instance.ActivateVideo(pickedSong.Mp4File);
        }
    }

    public void SongOver()
    {
        if (gig)
        {
            //load & play next song
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PickSong(Song song)
    {
        pickedSong = song;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
