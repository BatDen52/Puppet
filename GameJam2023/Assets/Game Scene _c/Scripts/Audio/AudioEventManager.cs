using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceFail;
    [SerializeField] private AudioSource _sourceBroken;
    [SerializeField] private AudioSource _sourceSuccess;
    [SerializeField] private AudioSource _sourceMusic;
    [SerializeField] private AudioSource _sourceSilentMusic;
    [SerializeField] private AudioClip[] _soundsFail;
    [SerializeField] private AudioClip[] _soundsBroken;
    [SerializeField] private AudioClip[] _soundsSuccess;
    [SerializeField] private AudioClip[] _soundsMove;
    [SerializeField] private AudioClip _soundWin;

    private Score _score;
    private float _timeToRestart = 1.5f;
    private float _currentTime;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _score.Fail += OnFail;
        _score.Broken += OnBroken;
        _score.Success += OnSuccess;
        _score.Success += OnMove;
        _score.GameWin += OnWin;
    }

    private void Update()
    {
        if(_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
                _sourceMusic.mute = false;
        }
    }

    public void OnWin()
    {
        _sourceSuccess.PlayOneShot(_soundWin);
    }

    public void PlayInFail(AudioClip clip)
    {
        _sourceFail.PlayOneShot(clip);
    }

    public void PlayInBroken(AudioClip clip)
    {
        _sourceBroken.PlayOneShot(clip);
    }

    public void PlayInSuccess(AudioClip clip)
    {
        _sourceSuccess.PlayOneShot(clip);
    }

    private void OnFail(int failScore)
    {
        if (_soundsFail.Length > 0)
            PlayInFail(_soundsFail[UnityEngine.Random.Range(0, _soundsFail.Length)]);

        _sourceMusic.mute = true;
        _currentTime = _timeToRestart;
    }

    private void OnBroken(int brokenScore)
    {
        if (_soundsBroken.Length > 0)
            PlayInBroken(_soundsBroken[UnityEngine.Random.Range(0, _soundsBroken.Length)]);
    }

    private void OnSuccess(int successScore)
    {
        if (_soundsSuccess.Length > 0)
            PlayInSuccess(_soundsSuccess[UnityEngine.Random.Range(0, _soundsSuccess.Length)]);
    }

    private void OnMove(int score)
    {
        if (_soundsMove.Length > 0)
            PlayInSuccess(_soundsMove[UnityEngine.Random.Range(0, _soundsMove.Length)]);
    }
}
