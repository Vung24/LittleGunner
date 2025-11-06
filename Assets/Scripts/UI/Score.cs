using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    public int _score = 0;
    public bool highScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        // PlayerPrefs.SetInt("HighScore", 0);
        highScore = false;
        _currentScoreText.text = "Score: " + _score.ToString();
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    // Update is called once per frame
    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = true;
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = "High Score: " + _score.ToString();
        }
    }
    public void UpdateScore(int value)
    {
        _score += value;
        _currentScoreText.text = "Score: " + _score.ToString();
        UpdateHighScore();
    }
    
}
