using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeDestroy : MonoBehaviour
{
    public float timeLife = 2f;
    float _timelife = 0f;
    public int damage = 10;

    // Update is called once per frame
    void Update()
    {
        // // Destroy(obj,timeLife);
        if (_timelife <= 0)
        {
            _timelife = timeLife;
            gameObject.SetActive(false);
        }
        else _timelife -= Time.deltaTime;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.instance.OnCollisionEnemy();
            damage = Random.Range(7, 14);
            EnemyBehave rb = collision.gameObject.GetComponent<EnemyBehave>();
            rb.TakeDamage(damage);
            // Destroy(obj);
            gameObject.SetActive(false);
        }
    }
}
