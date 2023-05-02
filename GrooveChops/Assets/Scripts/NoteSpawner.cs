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
        if (Tracks.Drums.Kick(midiNote))
        {
            Instantiate(Kick, transform);
        }
        if (Tracks.Drums.Snare(midiNote))
        {
            Instantiate(Snare, transform);
        }
        if (Tracks.Drums.Hihat(midiNote))
        {
            Instantiate(Hihat, transform);
        }
        if (Tracks.Drums.LeftCrash(midiNote))
        {
            Instantiate(LeftCrash, transform);
        }
        if (Tracks.Drums.RightCrash(midiNote))
        {
            Instantiate(RightCrash, transform);
        }
        if (Tracks.Drums.China(midiNote))
        {
            Instantiate(China, transform);
        }
        if (Tracks.Drums.Ride(midiNote))
        {
            Instantiate(Ride, transform);
        }
        if (Tracks.Drums.Tom1(midiNote))
        {
            Instantiate(Tom1, transform);
        }
        if (Tracks.Drums.Tom2(midiNote))
        {
            Instantiate(Tom2, transform);
        }
        if (Tracks.Drums.Tom3(midiNote))
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
