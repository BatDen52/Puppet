using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    float currentPos; //� ��������
    float currentPos_beats; //� ������
    float secPerBeat;
    float dpsTimePlayed; //������ ������� � ������ ����������
    public float bpm; //������ � ������
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
        if (nextNoteIndex < _notes.Length && _notes[nextNoteIndex].Bit - 8 < currentPos_beats + beatsShownInAdvance)
        {
            SpawnNote();
            //(KeyCode)Enum.Parse(typeof(KeyCode), notes[nextNoteIndex].key))
            if (IsRightKeyDown(_notes[nextNoteIndex].Keys))
            {
                print("��");
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
        //newNote.GetComponent<Note>().key = _notes[nextNoteIndex].Keys;
        newNote.GetComponent<Note>().AdjustPos();
    }

    private bool IsRightKeyDown(List<string> keys)
    {
        return keys.All(i => Input.GetKey(i));
    }
}