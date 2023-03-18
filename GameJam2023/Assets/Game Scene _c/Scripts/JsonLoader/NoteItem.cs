using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoteItem : MonoBehaviour
{
    public string Bit;
    public List<string> Keys;

    public NoteItem(string data)
    {
        NoteItem item = JsonUtility.FromJson<NoteItem>(data);

        Bit = item.Bit;
        Keys = item.Keys;
    }
}
