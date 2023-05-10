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

    public void DetermineNote(int midiNote, int velocity)
    {
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Kick))
        {
            SpawnNote(Kick, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Snare))
        {
            SpawnNote(Snare, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Hihat))
        {
            SpawnNote(Hihat, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.LeftCrash))
        {
            SpawnNote(LeftCrash, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.RightCrash))
        {
            SpawnNote(RightCrash, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.China))
        {
            SpawnNote(China, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Splash))
        {
            if (splash)
            {
                SpawnNote(Splash, velocity);
            }
            else
            {
                SpawnNote(LeftCrash, velocity);
            }
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Ride))
        {
            SpawnNote(Ride, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom0))
        {
            if (tom0)
            {
                SpawnNote(Tom0, velocity);
            }
            else
            {
                SpawnNote(Tom1, velocity);
            }
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom1))
        {
            SpawnNote(Tom1, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom2))
        {
            SpawnNote(Tom2, velocity);
        }
        if (Tracks.Drums.IsNote(midiNote, Tracks.DrumMap.Tom3))
        {
            SpawnNote(Tom3, velocity);
        }
    }

    public void SpawnClick()
    {
        Instantiate(click, transform);
    }

    private void SpawnNote(GameObject noteObj, int velocity)
    {
        Instantiate(noteObj, transform);
        Note note = noteObj.GetComponent<Note>();
    }

    private void SpawnNoteWithPulse(GameObject note)
    {

    }
}
