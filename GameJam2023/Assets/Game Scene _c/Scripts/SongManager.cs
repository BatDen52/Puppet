using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst;
using UnityEditor.Search;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public IReadOnlyCollection<string> AllKeys = new List<string> { "q", "w", "e", "r", "p", "o", "i", "u" };

    private enum NoteStats
    {
        PERFECT,
        NORAML,
        MISTAKE
    }

    public AudioSource songToPlay;
    public int beatsShownInAdvance;
    double currentPos; //в секундах
    double currentPosBeats; //в ударах
    float secPerBeat;
    double dpsTimePlayed; //прошло времени с начала композиции
    public float bpm; //ударов в минуту
    public int nextNoteIndex = 0;

    public GameObject notePrefab;
    public Transform noteParent;

    private NoteItem[] _notes;

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dpsTimePlayed = AudioSettings.dspTime;
        songToPlay.Play();
        _notes = JsonLoader.GetNotes().ToArray();
    }

    private void Update()
    {
        currentPos = AudioSettings.dspTime - dpsTimePlayed;
        currentPosBeats = currentPos / secPerBeat;
      
        if (nextNoteIndex < _notes.Length && _notes[nextNoteIndex].Bit /*- 8*/ < currentPosBeats + beatsShownInAdvance)
        {
            foreach (string key in _notes[nextNoteIndex].Keys)
                SpawnNote(key);

            if (IsRightKeyDown(_notes[nextNoteIndex].Keys))
            {
                print("да");
            }

            nextNoteIndex++;
        }
    }

    public void SpawnNote(string key)
    {
        GameObject newNote = Instantiate(notePrefab);
        newNote.transform.SetParent(noteParent);
        newNote.GetComponent<RectTransform>().localPosition = notePrefab.GetComponent<RectTransform>().localPosition;

        newNote.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        newNote.GetComponent<Note>().key = key;
        newNote.GetComponent<Note>().AdjustPos();
    }

    private bool IsRightKeyDown(List<string> keys)
    {
        return AllKeys.All(i => Input.GetKey(i) && keys.Contains(i));
    }
}