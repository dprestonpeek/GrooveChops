using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    GameObject hitLine;
    [SerializeField]
    GameObject noteButtons;

    List<SpawnedNote> spawnedNotes = new List<SpawnedNote>();

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

    public void LoadColors()
    {
        foreach (MeshRenderer obj in hitLine.GetComponents<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                Color color = obj.material.color;
                color.r = PlayerPrefs.GetFloat(obj.name + "-Color-R");
                color.g = PlayerPrefs.GetFloat(obj.name + "-Color-G");
                color.b = PlayerPrefs.GetFloat(obj.name + "-Color-B");
                color.a = PlayerPrefs.GetFloat(obj.name + "-Color-A");
                obj.material.color = color;
            }
        }
    }

    public void LoadNoteProperties()
    {
        foreach (MeshRenderer obj in hitLine.GetComponentsInChildren<MeshRenderer>())
        {
            if (obj.gameObject.activeSelf)
            {
                Color color = obj.material.color;
                color.r = PlayerPrefs.GetFloat(obj.name + "-Color-R");
                color.g = PlayerPrefs.GetFloat(obj.name + "-Color-G");
                color.b = PlayerPrefs.GetFloat(obj.name + "-Color-B");
                color.a = PlayerPrefs.GetFloat(obj.name + "-Color-A");
                obj.material.color = color;

                string name = obj.transform.name;
                float pos = 0;
                pos = PlayerPrefs.GetFloat(name + "-Pos");
                Vector3 newPos = obj.transform.localPosition;
                newPos.x = pos;
                obj.transform.localPosition = newPos;

                spawnedNotes.Add(new SpawnedNote(name, color, pos));
            }
        }
        Color kickColor = Color.black;
        kickColor.r = PlayerPrefs.GetFloat("Kick-Color-R");
        kickColor.g = PlayerPrefs.GetFloat("Kick-Color-G");
        kickColor.b = PlayerPrefs.GetFloat("Kick-Color-B");
        kickColor.a = PlayerPrefs.GetFloat("Kick-Color-A");
        spawnedNotes.Add(new SpawnedNote("Kick", kickColor, 0));
    }

    public void SpawnClick()
    {
        Instantiate(click, transform);
    }

    private void SpawnNote(GameObject noteObj, int velocity)
    {
        SpawnedNote spawnedNote = GetSpawnedNote(noteObj.name);
        GameObject spawnedNoteObj = Instantiate(noteObj, transform);
        spawnedNoteObj.GetComponent<MeshRenderer>().sharedMaterial.color = spawnedNote.Color;
        Vector3 newPos = spawnedNoteObj.transform.localPosition;
        newPos.x = spawnedNote.XLoc;
        spawnedNoteObj.transform.localPosition = newPos;
        Note note = spawnedNoteObj.GetComponent<Note>();
    }

    private void SpawnNoteWithPulse(GameObject note)
    {

    }

    private SpawnedNote GetSpawnedNote(string name)
    {
        foreach (SpawnedNote note in spawnedNotes)
        {
            if (note.Name == name)
            {
                return note;
            }
        }
        return null;
    }
}

public class SpawnedNote
{
    public string Name;
    public Color Color;
    public float XLoc;

    public SpawnedNote(string name, Color color, float xLoc)
    {
        Name = name;
        Color = color;
        XLoc = xLoc;
    }
}
