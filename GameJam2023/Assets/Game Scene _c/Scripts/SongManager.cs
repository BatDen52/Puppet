using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEditor.Search;
using UnityEngine;

public class SongManager : MonoBehaviour
{ 
    [System.Serializable]
    public struct note
    {
        public float bit;
        public KeyCode key;
    }
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
    public note[] notes;
    public int nextNoteIndex = 0;

    public GameObject notePrefab;
    public Transform noteParent;

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dpsTimePlayed = (float)AudioSettings.dspTime;
        songToPlay.Play();
    }

    private void Update()
    {
        currentPos = (float)AudioSettings.dspTime - dpsTimePlayed;
        currentPos_beats = currentPos / secPerBeat;
        if (nextNoteIndex < notes.Length && notes[nextNoteIndex].bit-8 < currentPos_beats + beatsShownInAdvance)
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
        newNote.GetComponent<Note>().key = notes[nextNoteIndex].key;
        newNote.GetComponent<Note>().AdjustPos();
    }

}