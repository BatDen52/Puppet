using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _maxFailCount = 2;
    [SerializeField] private int _maxBrokenCount = 5;

    private SongManager _songManager;
    private List<string> _strings = new List<string> { "q", "w", "e", "r" };

    public int SuccessScore { get; private set; }
    public int NoteScore { get; private set; }
    public int FailScore { get; private set; }
    public int BrokeScore { get; private set; }
    public int TotalScore { get; private set; }
    public static List<string> BrokenStrings { get; private set; } = new List<string>();

    public event Action EndGame;
    public event Action<int> Success;
    public event Action<int> Fail;
    public event Action<int> Broken;
    public event Action GameWin;

    private void Awake()
    {
        _songManager = FindObjectOfType<SongManager>();
        _songManager.Fail += OnFail;
        _songManager.Success += OnSuccess;
    }

    public float GetProgressScore()
    {
        return _songManager.NotesCount / NoteScore * 100;
    }

    public float GetPerfectScore()
    {
        return _songManager.NotesCount / SuccessScore * 100;
    }

    private void OnSuccess()
    {
        SuccessScore++;
        NoteScore++;
        TotalScore += BrokenStrings.Count + 1;

        Success?.Invoke(SuccessScore);
    }

    public void Win()
    {
        GameWin?.Invoke();
    }

    private void OnFail()
    {
        FailScore++;
        NoteScore++;
        Fail?.Invoke(FailScore);

        if (FailScore == _maxFailCount)
        {
            FailScore = 0;
            BrokeScore++;

            if (BrokeScore == _maxBrokenCount)
            {
                EndGame?.Invoke();
            }
            else
            {
                if (_strings.Count > 0)
                {
                    string brokenString = _strings[0];

                    BrokenStrings.Add(brokenString);
                    _strings.Remove(brokenString);
                }

            }
            Broken?.Invoke(BrokeScore);
        }
    }
}
