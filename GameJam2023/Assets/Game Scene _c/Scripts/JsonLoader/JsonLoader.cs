using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonLoader
{
    [Serializable]
    class NoteItemData
    {
        public List<NoteItem> Data;
    }

    public static List<NoteItem> GetNotes()
    {
        NoteItemData itemData = JsonUtility.FromJson<NoteItemData>(Resources.Load<TextAsset>("notes").text);
        return itemData.Data;
    }
}
