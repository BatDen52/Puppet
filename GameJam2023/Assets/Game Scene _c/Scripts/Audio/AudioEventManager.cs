using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceFail;
    [SerializeField] private AudioSource _sourceBroken;
    [SerializeField] private AudioSource _sourceSuccess;
    [SerializeField] private AudioClip[] _soundsFail;
    [SerializeField] private AudioClip[] _soundsBroken;
    [SerializeField] private AudioClip[] _soundsSuccess;
    [SerializeField] private AudioClip[] _soundsMove;

    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _score.Fail += OnFail;
        _score.Broken += OnBroken;
        _score.Success += OnSuccess;
        _score.Success += OnMove;
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
            PlayInFail(_soundsFail[Random.Range(0, _soundsFail.Length)]);
    }

    private void OnBroken(int brokenScore)
    {
        if (_soundsBroken.Length > 0)
            PlayInBroken(_soundsBroken[Random.Range(0, _soundsBroken.Length)]);
    }

    private void OnSuccess(int successScore)
    {
        if (_soundsSuccess.Length > 0)
            PlayInSuccess(_soundsSuccess[Random.Range(0, _soundsSuccess.Length)]);
    }

    private void OnMove(int score)
    {
        if (_soundsMove.Length > 0)
            PlayInSuccess(_soundsMove[Random.Range(0, _soundsMove.Length)]);
    }
}
