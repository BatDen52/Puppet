using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreVisualize : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTotalScore;
    [SerializeField] private TMP_Text _textProgressScore;
    [SerializeField] private TMP_Text _hudScore;

    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
        _score.GameWin += OnEndGame;
        _score.EndGame += OnEndGame;
        _score.Success += OnSuccess;
        _hudScore.text = "0";
    }

    private void OnSuccess(int successScore)
    {
        _hudScore.text = (_score.TotalScore * 10).ToString("0");
    }

    private void OnEndGame()
    {
        _textTotalScore.text = (_score.TotalScore * 10).ToString("0");
        _textProgressScore.text = _score.GetProgressScore().ToString("0.00") + "%";
    }
}