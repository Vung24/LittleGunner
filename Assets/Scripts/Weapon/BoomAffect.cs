using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAffect : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab vụ nổ
    public float explosionRadius = 3f; // Bán kính vụ nổ
    public int explosionWeight = 50;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Tạo vụ nổ
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Áp lực lên các đối tượng trong bán kính nổ
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (Collider2D hit in colliders)
            {
                EnemyBehave rb = hit.gameObject.GetComponent<EnemyBehave>();
                if (rb != null)
                {
                    rb.TakeDamage(explosionWeight);
                }
            }

            // Phá hủy rocket
            Destroy(gameObject);
        }
    }
}
