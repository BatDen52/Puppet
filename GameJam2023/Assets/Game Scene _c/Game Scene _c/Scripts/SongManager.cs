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
    float currentPos; //� ��������
    float currentPos_beats; //� ������
    float secPerBeat; 
    float dpsTimePlayed; //������ ������� � ������ ����������
    public float bpm; //������ � ������
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
                print("��");
            }
            nextNoteIndex++;
        }
    }

    /*public NoteStats CheckNote()
    {
        if()
    }*/

}