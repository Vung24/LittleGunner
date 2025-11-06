using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music, boomSource, shootSource, dashSource, collisionSource;
    public AudioClip startWarMusic, highPressureClip, boomClip, shootClip, dashClip, reviveClip, playerDeathClip, buttonClip, bulletImpactClip, gameUIPopUpClip;
    public AudioClip[] enemyClip;
    public static AudioManager instance;
    int onchange = 0, ondeath = 0;
    void Start()
    {
        if (instance == null)
            instance = this;
        music.clip = startWarMusic;
        music.time = 4f;
        music.Play();
        dashSource.clip = reviveClip;
        dashSource.Play();
    } 
    void Update()
    {
        if(Weapon.instance.isFire == true)
        {
            OnShootClip();
        }
        if(RocketFire.instance.isFire == true)
        {
            OnBoomClip();
        }
        if(Player.instance.rollOnce == true)
        {
            OnDashClip();
        }
        if(GameTotal.instance.highPressure == true && onchange == 0)
        {
            OnChangeMusicBgr();
            onchange = 1;
        }
        if(PlayerHealth.instance.dead == true && ondeath == 0)
        {
            Invoke("OnPlayerDeathClip", 0.5f);
            ondeath = 1;
        }
    }
    void OnChangeMusicBgr()
    {
        music.clip = highPressureClip;
        music.time = 5f;
        music.Play();
    }
    void OnShootClip()
    {
        shootSource.clip = shootClip;
        shootSource.volume = 0.7f;
        shootSource.Play();
    }
    void OnDashClip()
    {
        dashSource.clip = dashClip;
        dashSource.time = 0.1f;
        dashSource.volume = 0.15f;
        dashSource.Play();
    }
    void OnBoomClip()   
    {
        boomSource.clip = boomClip;
        boomSource.volume = 0.7f;
        boomSource.Play();
        StartCoroutine(StopBoomClip());
    }
    IEnumerator StopBoomClip()
    {
        yield return new WaitForSeconds(2f);
        boomSource.Stop();
    }
    public void OnClickButton()
    {
        boomSource.clip = buttonClip;
        boomSource.volume = 1f;
        boomSource.Play();
    }
    public void OnEnemyBite()
    {
        int i = Random.Range(0, enemyClip.Length);
        dashSource.clip = enemyClip[i];
        dashSource.volume = 0.5f;
        dashSource.Play();
    }
    public void OnCollisionEnemy()
    {
        collisionSource.clip = bulletImpactClip;
        collisionSource.Play();
    }
    void OnPlayerDeathClip()
    {
        dashSource.clip = playerDeathClip;
        dashSource.volume = 1f;
        dashSource.Play();
    }
    public void OnGameUIPopUp()
    {
        boomSource.clip = gameUIPopUpClip;
        boomSource.volume = 1f;
        boomSource.time = 1f;
        boomSource.Play();
    }
}
