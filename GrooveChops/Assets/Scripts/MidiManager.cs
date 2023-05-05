using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MidiPlayerTK;
using MPTK.NAudio.Midi;
using UnityEngine;

public class MidiManager : MonoBehaviour
{
    public static MidiManager Instance;

    [SerializeField]
    public MidiFilePlayer player;

    string midiPath = "";

    List<long> prevTicks;
    List<MPTKEvent> mptkEvents;
    List<TrackMidiEvent> midiEvents;

    NoteManager printer;

    float timer = 0;
    double msPerQuarter;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = FindObjectOfType<MidiFilePlayer>();
        player.OnEventNotesMidi.AddListener(NotesToPlay);
        mptkEvents = new List<MPTKEvent>();
        midiEvents = new List<TrackMidiEvent>();
        printer = FindObjectOfType<NoteManager>();
        prevTicks = new List<long>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.MPTK_PulseLenght > 0)
        {
            msPerQuarter = (player.MPTK_DeltaTicksPerQuarterNote / 2) * player.MPTK_PulseLenght;
            timer += Time.deltaTime;
            if (timer * 1000 >= msPerQuarter)
            {
                printer.Tick();
                timer = 0;
            }
        }
    }

    private void NotesToPlay(List<MPTKEvent> events)
    {
        foreach (MPTKEvent ev in events)
        {
            if (ev.Command == MPTKCommand.NoteOn)
            {
                mptkEvents.Add(ev);
                InstrumentEvent info = new InstrumentEvent(ev.Channel, ev.Value);
                printer.MidiNoteEvent(info);
            }
        }
    }

    public void NoteEvent()
    {
        foreach (MPTKEvent ev in mptkEvents)
        {
            if (ev.Command == MPTKCommand.NoteOn)
            {
            }
        }

        //need to do regex here to get the note name from the TrackMidiEvent
        //NoteOnEvent noteon = (NoteOnEvent)midiEvent.Event;
        //Debug.Log(noteon.NoteName);
    }

    public void LoadMidiFromPath(string path)
    {
        midiPath = path;
        player.MPTK_MidiName = Path.GetFileNameWithoutExtension(path);
        LoadMidi();
    }

    private void LoadMidi()
    {
        byte[] midiFileBytes = File.ReadAllBytes(midiPath);
        MidiLoad midi = player.MPTK_Load(midiFileBytes);

        MidiPlayerGlobal.CurrentMidiSet.MidiFiles.Clear();
        MidiPlayerGlobal.CurrentMidiSet.MidiFiles.Add(player.MPTK_MidiName);

        if (midi != null)
        {
            //UIManager.Instance.UpdateMidi(player.MPTK_MidiName);
        }
    }
}

public struct InstrumentEvent
{
    public int note;
    public int channel;

    public InstrumentEvent(int channel, int note)
    {
        this.note = note;
        this.channel = channel;
    }
}
