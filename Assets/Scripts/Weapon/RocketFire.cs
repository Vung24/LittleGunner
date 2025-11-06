using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFire : MonoBehaviour
{
    public GameObject rocket, rocketPos;
    float reloading;
    public float reloadSpeed = 2f, rocketForce = 20f;
    
    public bool isFire = false;
    public int remain;
    public static RocketFire instance;
    
    void Start()
    {
        if(instance == null)
            instance = this;
        remain = 2;
    }
    void Update()
    {
        GunFire();
    }
    void GunFire()
    {
        if (Input.GetMouseButton(1) && reloading <= 0 && remain > 0)
        {
            reloading = reloadSpeed;
            isFire = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDir = mousePos - rocketPos.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            GameObject rocketClone = Instantiate(rocket, rocketPos.transform.position, Quaternion.Euler(0, 0, angle - 90));
            Rigidbody2D rb = rocketClone.GetComponent<Rigidbody2D>();
            rb.AddForce(lookDir * rocketForce, ForceMode2D.Impulse);
            remain--;
            Destroy(rocketClone, 3f);
        }
        else
        {
            isFire = false;
            reloading -= Time.deltaTime;
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ItemRocket"))
        {
            remain += 1;
        }
    }
}
