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
    public float beatsShownInAdvance;
    public float bpm; //ударов в минуту
    public int nextNoteIndex = 0;
    public GameObject notePrefab;
    public Transform noteParent;

    private double currentPos; //в секундах
    private double dpsTimePlayed; //прошло времени с начала композиции
    private NoteItem[] _notes;
    private Dictionary<float, List<Note>> _noteRows = new Dictionary<float, List<Note>>();

    public static float curretnBit = -1;

    private PuppetAnimManager animManager;

    private void Start()
    {
        dpsTimePlayed = AudioSettings.dspTime;
        songToPlay.Play();
        _noteRows.Clear();
        _notes = JsonLoader.GetNotes().ToArray();
    }

    private void Update()
    {
        currentPos = AudioSettings.dspTime - dpsTimePlayed;

        if (nextNoteIndex < _notes.Length && _notes[nextNoteIndex].Bit < currentPos + beatsShownInAdvance)
        {
            foreach (string key in _notes[nextNoteIndex].Keys)
                SpawnNote(key, _notes[nextNoteIndex].Bit);

            nextNoteIndex++;
        }

        if (_noteRows.Count > 0)
            curretnBit = _noteRows.Keys.Min();
    }

    public void SpawnNote(string key, float bit)
    {
        Note newNote = Instantiate(notePrefab).GetComponent<Note>();
        newNote.transform.SetParent(noteParent);
        newNote.GetComponent<RectTransform>().localPosition = notePrefab.GetComponent<RectTransform>().localPosition;

        newNote.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        newNote.key = key;
        newNote.bit = bit;
        newNote.AdjustPos();
        newNote.Missed += OnMissed;
        newNote.Hiting += OnHit;

        if (_noteRows.Count == 0 || _noteRows.ContainsKey(bit) == false)
        {
            _noteRows[bit] = new List<Note>() { newNote };
        }
        else
        {
            _noteRows[bit].Add(newNote);
        }
    }

    public void OnMissed(float bit)
    {
        if (_noteRows.Count > 0)
        {
            if (_noteRows.TryGetValue(bit, out List<Note> notes))
            {
                foreach (var note in _noteRows[bit])
                    Destroy(note.gameObject);

                _noteRows.Remove(bit);
            }
        }
    }

    public void OnHit(float bit)
    {
        if (_noteRows.Count > 0)
        {
            if (_noteRows[bit].All(i => i.isActive))
            {
                foreach (var note in _noteRows[bit])
                    Destroy(note.gameObject);

                _noteRows.Remove(bit);

                Debug.Log("AllHit");
            }
            //вызывается метод отыгрывания анимации 
        }
    }
}