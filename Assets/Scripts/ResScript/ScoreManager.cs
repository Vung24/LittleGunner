using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;
    public void SubmitScore(){
        int score =  PlayerPrefs.GetInt("HighScore", 0);
        submitScoreEvent.Invoke(inputName.text, score);
    }
}
