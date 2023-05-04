using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject click;

    [SerializeField]
    GameObject Snare;

    [SerializeField]
    GameObject Kick;

    [SerializeField]
    GameObject LeftCrash;
    [SerializeField]
    GameObject RightCrash;
    [SerializeField]
    GameObject Hihat;
    [SerializeField]
    GameObject China;
    [SerializeField]
    GameObject Ride;

    [SerializeField]
    GameObject Tom1;
    [SerializeField]
    GameObject Tom2;
    [SerializeField]
    GameObject Tom3;

    [SerializeField]
    GameObject Tom0;
    bool tom0 = false;

    [SerializeField]
    GameObject Splash;
    bool splash = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNote(int midiNote)
    {
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Kick))
        {
            Instantiate(Kick, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Snare))
        {
            Instantiate(Snare, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Hihat))
        {
            Instantiate(Hihat, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.LeftCrash))
        {
            Instantiate(LeftCrash, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.RightCrash))
        {
            Instantiate(RightCrash, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.China))
        {
            Instantiate(China, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Splash))
        {
            if (splash)
            {
                Instantiate(Splash, transform);
            }
            else
            {
                Instantiate(LeftCrash, transform);
            }
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Ride))
        {
            Instantiate(Ride, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom0))
        {
            if (tom0)
            {
                Instantiate(Tom0, transform);
            }
            else
            {
                Instantiate(Tom1, transform);
            }
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom1))
        {
            Instantiate(Tom1, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom2))
        {
            Instantiate(Tom2, transform);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom3))
        {
            Instantiate(Tom3, transform);
        }
    }

    public void SpawnClick()
    {
        Instantiate(click, transform);
    }

    private void SpawnNoteWithPulse(GameObject note)
    {

    }
}
