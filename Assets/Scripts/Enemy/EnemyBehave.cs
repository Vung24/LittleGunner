using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyBehave : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    public GameObject enemy, deadEffect, floatText;
    public int damageEnemy = 5;
    public static EnemyBehave instance;
    public int value = 0;
    void Start()
    {
        enemy = this.gameObject;
        if (instance != null)
            instance = this;
    }
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(enemy);
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Score.instance.UpdateScore(value);
            GameTotal.instance.enemyDeath += 1;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        GameObject floatClone = Instantiate(floatText, transform.position, Quaternion.identity, transform);
        floatClone.GetComponent<TextMeshPro>().text = damage.ToString();
        if(damage > 10)
            floatClone.GetComponent<TextMeshPro>().color = new Color(0.9137255f, 0.1051038f, 0.0235294f, 1f);
        Destroy(floatClone, 1f);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(damageEnemy);
            if(!Player.instance.rollOnce)
                AudioManager.instance.OnEnemyBite();
        }
    }
}
