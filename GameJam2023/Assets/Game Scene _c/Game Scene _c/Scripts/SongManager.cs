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

    private void Start()
    {
        secPerBeat = 60f / bpm;
        dpsTimePlayed = (float)AudioSettings.dspTime;
        songToPlay.Play();
    }

    private void Update()
    {
        currentPos = (float)AudioSettings.dspTime - dpsTimePlayed;
        currentPos_beats = currentPos/ secPerBeat;
        if (nextNoteIndex < notes.Length && notes[nextNoteIndex].bit < currentPos_beats + beatsShownInAdvance)
        {
            //SpawnNote();
            //(KeyCode)Enum.Parse(typeof(KeyCode), notes[nextNoteIndex].key))
            if (Input.GetKey(KeyCode.W))
            {
                print("да");
            }
            nextNoteIndex++;
        }
    }

    /*public NoteStats CheckNote()
    {
        if()
    }*/

}