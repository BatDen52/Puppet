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

    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _score.Fail += OnFail;
        _score.Broken += OnBroken;
        _score.Success += OnSuccess;
    }

    private void OnFail(int failScore)
    {
        if (_soundsFail.Length > 0)
        {
            _sourceFail.clip = _soundsFail[Random.Range(0, _soundsFail.Length)];
            _sourceFail.Play();
        }
    }

    private void OnBroken(int failScore)
    {
        if (_soundsBroken.Length > 0)
        {
            _sourceBroken.clip = _soundsBroken[Random.Range(0, _soundsBroken.Length)];
            _sourceBroken.Play();
        }
    }

    private void OnSuccess(int failScore)
    {
        if (_soundsSuccess.Length > 0)
        {
            _sourceSuccess.clip = _soundsSuccess[Random.Range(0, _soundsSuccess.Length)];
            _sourceSuccess.Play();
        }
    }
}
