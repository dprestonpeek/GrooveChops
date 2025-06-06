using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LibraryPick : Library
{
    public override void DisplayLibrary()
    {
        ClearLibraryList();
        RefreshLibrary();
        List<SongInfo> library = Library.Instance.GetLibrary();
        base.DisplayLibrary(library);
    }
}
