using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Library : MonoBehaviour
{
    public static Library Instance;

    public GameObject songs;
    public GameObject songPrefab;

    int totalSongs = 0;
    int totalArtists = 0;

    public int songSpacing { get; private set; } = 30;

    List<SongInfo> library = new List<SongInfo>();
    public List<GameObject> libraryList = new List<GameObject>();

    private void Start()
    {
        if (!GetType().Equals(typeof(LibraryPick)))
        {
            Instance = this;
        }
    }

    public virtual void DisplayLibrary()
    {
        ClearLibraryList();
        RefreshLibrary();
        DisplayLibrary(library);
    }

    public void DisplayLibrary(List<SongInfo> library)
    {
        for (int i = 0; i < library.Count; i++)
        {
            GameObject song = Instantiate(songPrefab, Vector3.zero, Quaternion.identity, songs.transform);
            Song songObj = song.GetComponent<Song>();
            songObj.UpdateInfo(library[i].Name, library[i].Artist, library[i].SongPath);
            Vector3 newPos = Vector3.zero;
            newPos.y = i * songSpacing * -1;
            song.transform.localPosition = newPos;
            song.GetComponentInChildren<TMP_Text>().text = library[i].Artist + " - " + library[i].Name;
            libraryList.Add(song);
        }
    }

    public void ClearLibraryList()
    {
        foreach (GameObject song in libraryList)
        {
            Destroy(song.gameObject);
        }
    }

    public void AddSongToLibrary(SongInfo newSong)
    {
        library.Add(newSong);
    }

    public List<SongInfo> GetLibrary()
    {
        RefreshLibrary();
        return library;
    }

    //public Song GetSongFromInfo()
    //{

    //}

    public void RefreshLibrary()
    {
        library = new List<SongInfo>();
        totalSongs = 0;
        string libraryPath = Path.Combine(Application.persistentDataPath, "SongLibrary");
        string[] artists = Directory.GetDirectories(libraryPath);
        foreach (string artist in artists)
        {
            foreach (string song in Directory.GetDirectories(artist))
            {
                SongInfo newSong = new SongInfo(Path.GetFileNameWithoutExtension(song), 
                    Path.GetFileNameWithoutExtension(artist), song);
                library.Add(newSong);
                totalSongs++;
            }
            totalArtists++;
        }
    }
}
