using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator animatorIns, animatorLea;
    public GameObject instruction, leaderboard;
    public AudioSource music, sfxSource;
    public AudioClip buttonClick;
    public AudioClip[] bgrMusic;
    void Start()
    {
        if (instance == null)
            instance = this;
        int i = Random.Range(0, bgrMusic.Length);
        music.clip = bgrMusic[i];
        music.time = 5f;
        music.Play();
        // Cursor.SetCursor(newCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnButtonCLick()
    {
        sfxSource.clip = buttonClick;
        sfxSource.Play();
    }
    public void ChooseMap()
    {
        OnButtonCLick();
        SceneManager.LoadScene("Scenes/ChooseMap");
    }
    public void TurnOnInstruction()
    {
        OnButtonCLick();
        animatorIns.Play("TurnOnInstruction");
        instruction.SetActive(true);
    }
    public void TurnOffInstruction()
    {
        OnButtonCLick();
        animatorIns.Play("TurnOffInstruction");
        StartCoroutine(WaitInsAnimation());
    }
    IEnumerator WaitInsAnimation()
    {
        yield return new WaitForSeconds(1f);
        instruction.SetActive(false);
    }
    public void TurnOnLeaderboard()
    {
        OnButtonCLick();
        animatorLea.Play("TurnOnLeaderboard");
        leaderboard.SetActive(true);
    }
    public void TurnOffLeaderboard()
    {
        OnButtonCLick();
        animatorLea.Play("TurnOffLeaderboard");
        StartCoroutine(WaitLeaAnimation());
    }
    IEnumerator WaitLeaAnimation()
    {
        yield return new WaitForSeconds(1f);
        leaderboard.SetActive(false);
    }
}
