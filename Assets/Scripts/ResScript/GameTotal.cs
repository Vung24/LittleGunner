using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameTotal : MonoBehaviour
{
    public int totalScore, enemyDeath;
    int check = 0;
    public float playTime;
    [SerializeField] private TextMeshProUGUI totalText, timerText, enemyDeathText;
    public GameObject GameOverUI, markPos, highScoreTag;
    public Animator animator;
    public static GameTotal instance;
    public GameObject[] marks;
    public Texture2D newCursorTexture;
    public bool highPressure;
    void Start()
    {
        // marks = GameObject.FindGameObjectsWithTag("PrefabMark");
        playTime = 0;
        highPressure = false;
        if (instance == null)
            instance = this;
        Cursor.SetCursor(newCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
    void Update()
    {
        playTime += Time.deltaTime;
        if (playTime > 100)
            highPressure = true;
        if (PlayerHealth.instance.dead == true && check == 0)
        {
            StartCoroutine(OnGameOver());
            check = 1;
        }
    }
    IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(3f);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);
        timerText.text = "Time play: " + string.Format("{0:00}:{1:00}", minutes, seconds);

        totalScore = Score.instance._score;
        totalText.text = "Total score: " + totalScore.ToString();
        enemyDeathText.text = "enemy death: " + enemyDeath.ToString();
        GameOverUI.SetActive(true);
        animator.Play("UIGameOverPopUp");

        AudioManager.instance.OnGameUIPopUp();
        if (Score.instance.highScore)
        {
            highScoreTag.SetActive(true);
        }

        float testId = (float)totalScore / 90;
        Debug.Log(testId);
        for (int i = 0; i < marks.Length; i++)
        {
            PrefabID prefabID = marks[i].GetComponent<PrefabID>();
            if ((prefabID.id > testId && prefabID.id - 1 <= testId) || i == marks.Length - 1)
            {
                GameObject markClone = Instantiate(marks[i], new Vector3(0, 0, 0), Quaternion.identity, markPos.transform);
                // markClone.RectTransform.anchoredPosition = Vector2.zero;
                break;
            }
        }
        StartCoroutine(DelayPause());
    }
    IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
    public void OnPLayAgain()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void OnExitToScreen()
    {
        SceneManager.LoadScene("Scenes/StartScene");
        Time.timeScale = 1f;
    }
}
