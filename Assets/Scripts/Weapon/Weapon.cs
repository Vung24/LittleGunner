using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet, muzzle;
    public float reloadSpeed = 0.5f, bulletForce = 10f;
    public Transform firePos;
    private float reloading = 0f;
    
    public bool isFire = false;
    public static Weapon instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Update()
    {
        RotateGun();
        GunFire();
    }
    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else transform.localScale = new Vector3(1, 1, 0);
    }
    void GunFire()
    {
        if (Input.GetMouseButton(0) && reloading <= 0)
        {
            // GameObject bulletClone = Instantiate(bullet, firePos.position, Quaternion.identity);
            GameObject muzzleClone = Instantiate(muzzle, firePos.position, transform.rotation, transform);
            // Destroy(muzzleClone, 0.1f);
            GameObject bulletClone = ObjectPooling.instance.GetPoolObject();
            isFire = true;
            if (bulletClone != null)
            {
                bulletClone.transform.position = firePos.position;
                bulletClone.transform.rotation = transform.rotation;
                // bulletClone.transform.parent = transform; 
                bulletClone.SetActive(true);
                // StartCoroutine(SetFalse(bulletClone));
            }
            reloading = reloadSpeed;
            Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            reloading -= Time.deltaTime;
            isFire = false;
        }
    }
    // IEnumerator SetFalse(GameObject bulletClone)
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     bulletClone.SetActive(false);
    // }
}
