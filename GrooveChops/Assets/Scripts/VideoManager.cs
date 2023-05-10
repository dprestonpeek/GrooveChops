using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Instance;

    [SerializeField]
    GameObject videoPlane;

    [SerializeField]
    VideoPlayer videoPlayer;

    [SerializeField]
    GameObject introPlane;

    [SerializeField]
    VideoPlayer introPlayer;

    public bool playVideo = false;

    string mp4Path = "";
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateVideo(string videoPath)
    {
        videoPlayer.url = videoPath;
        playVideo = true;
        PlayIntro();
    }

    public void DeactivateVideo()
    {
        playVideo = false;
    }

    public void PlayVideo()
    {
        videoPlane.SetActive(true);
        videoPlayer.Play();
    }

    public void StopIntro()
    {
        introPlane.SetActive(false);
        introPlayer.Stop();
    }

    private void PlayIntro()
    {
        introPlane.SetActive(true);
        introPlayer.Play();
    }
}
