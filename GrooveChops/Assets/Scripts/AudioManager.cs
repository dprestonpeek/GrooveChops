using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip audioClip;

    public string mp3Path;
    public string midiPath;

    public float timer = 0;
    public bool timerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private void Awake()
    {

    }

    public void SetMP3Path(string path)
    {
        mp3Path = path;
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        WWW request = GetAudioFromFile(mp3Path);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = Path.GetFileName(mp3Path);
        audioSource.clip = audioClip;
        if (audioSource.clip != null)
        {
            UIManager.Instance.UpdateMp3(audioClip.name);
            UIManager.Instance.Mp3OK = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        }
    }

    public void PlayDelayed()
    {
        Invoke("PlayAudio", 6.7f);
        timerOn = true;
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }

    private WWW GetAudioFromFile(string path)
    {
        string audioToLoad = path;
        WWW request = new WWW(audioToLoad);
        return request;
    }
}
