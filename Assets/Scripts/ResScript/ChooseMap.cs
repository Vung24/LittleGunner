using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseGame : MonoBehaviour
{
    public static ChooseGame instance;
    [SerializeField] private Button basicMapButton; // Tham chiếu đến Button cho MapBasic

    public AudioSource music, sfxSource; // Quản lý âm nhạc và hiệu ứng âm thanh
    public AudioClip buttonClick; // Âm thanh khi nhấp button
    public AudioClip[] bgrMusic; // Danh sách nhạc nền

    void Start()
    {
        if (instance == null)
            instance = this;
        int i = Random.Range(0, bgrMusic.Length);
        music.clip = bgrMusic[i];
        music.time = 5f;
        music.Play();
    }
    void OnButtonClick()
    {
        sfxSource.clip = buttonClick;
        sfxSource.Play();
    }
    public void LoadMapBasic()
    {
        OnButtonClick();
        SceneManager.LoadScene("Scenes/MapBasic");
    }
    public void LoadMap1()
    {
        OnButtonClick();
        SceneManager.LoadScene("Scenes/Map1");
    }
        public void LoadMap2()
    {
        OnButtonClick();
        SceneManager.LoadScene("Scenes/Map2");
    }

}