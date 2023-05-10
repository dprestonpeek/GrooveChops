using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Song> pickedSongs;
    public int songIndex = 0;
    public Song currentSong;

    [SerializeField]
    GameObject EndSongMenu;
    [SerializeField]
    GameObject EndGigMenu;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        pickedSongs = new List<Song>();
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
        currentSong = pickedSongs[songIndex];
        AudioManager.Instance.LoadAudioFromPath(currentSong.Mp3File);
        MidiManager.Instance.LoadMidiFromPath(currentSong.MidiFile);
        DrumMapManager.Instance.LoadDrumMapFromPath(currentSong.MapFile);
        if (pickedSongs[songIndex].Mp4File != "")
        {
            VideoManager.Instance.ActivateVideo(currentSong.Mp4File);
        }
    }

    public void NextSong()
    {
        songIndex++;
        currentSong = pickedSongs[songIndex];
    }

    public void SongOver()
    {
        MidiManager.Instance.player.MPTK_Stop();
        UIManager.Instance.ShowMenu();
        if (songIndex < pickedSongs.Count - 1)
        {
            //gig is not over yet
            EndSongMenu.SetActive(true);
        }
        else
        {
            //gig is over
            EndGigMenu.SetActive(true);
            songIndex = 0;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //public void PickSong(Song song)
    //{
    //    pickedSongs = song;
    //}

    public void Exit()
    {
        Application.Quit();
    }
}
