using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField]
    bool animate;

    [SerializeField]
    [Range(0, 100)]
    public int speed = 10;

    [SerializeField]
    NoteSpawner spawner;

    Dictionary<int, int> instCounter;

    //AnimationEvents events;
    public int ticks = 0;
    public int notes = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //events = GetComponent<AnimationEvents>();
        InitInstCounter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitInstCounter()
    {
        instCounter = new Dictionary<int, int>();
        for (int i = 0; i < 16; i++)
        {
            instCounter.Add(i, 0);
        }
    }

    public void Tick()
    {
        if (animate)
        {
            //every other beat
            if (ticks % 2 != 0)
            {
                spawner.SpawnClick();
            }
            //at 4 beats
            if (ticks % 4 == 0)
            {
            }
            //at 8 beats
            if (ticks % 8 == 0)
            {
            }
        }

        ticks++;
    }

    public void MidiNoteEvent(InstrumentEvent instEvent)
    {
        notes++;

        if (animate)
        {
            if (instEvent.channel == 9)
            {
                spawner.SpawnNote(instEvent.note);
            }
        }
    }
}
