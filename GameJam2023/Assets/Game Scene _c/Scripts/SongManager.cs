using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEditor.Search;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    private enum NoteStats
    {
        PERFECT,
        NORAML,
        MISTAKE
    }
    
    public AudioSource songToPlay;
    public int beatsShownInAdvance;
    float currentPos; //в секундах
    float currentPos_beats; //в ударах
    float secPerBeat;
    float dpsTimePlayed; //прошло времени с начала композиции
    public float bpm; //ударов в минуту
    public int nextNoteIndex = 0;

    public GameObject notePrefab;
    public Transform noteParent;

    private NoteItem[] _notes;

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dpsTimePlayed = (float)AudioSettings.dspTime;
        songToPlay.Play();
        _notes = JsonLoader.GetNotes().ToArray();
    }

    private void Update()
    {
        currentPos = (float)AudioSettings.dspTime - dpsTimePlayed;
        currentPos_beats = currentPos / secPerBeat;
        if (nextNoteIndex < _notes.Length && _notes[nextNoteIndex].Bit-8 < currentPos_beats + beatsShownInAdvance)
        {
            SpawnNote();
            //(KeyCode)Enum.Parse(typeof(KeyCode), notes[nextNoteIndex].key))
            if (Input.GetKey(KeyCode.W))
            {
                print("да");
            }
            nextNoteIndex++;
        }
    }

    public void SpawnNote()
    {
        GameObject newNote = Instantiate(notePrefab);
        newNote.transform.SetParent(noteParent);
        newNote.GetComponent<RectTransform>().localPosition = notePrefab.GetComponent<RectTransform>().localPosition;
        newNote.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
    }

}