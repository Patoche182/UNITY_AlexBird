using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //Start is called before the first frame update
    private void Start()
    {
        _currentScoreText.text = _score.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();

        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScoreText.text = "0";
    }
}
