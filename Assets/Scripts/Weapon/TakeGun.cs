using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGun : MonoBehaviour
{
    public GameObject GunPrefab;
    public GameObject GunClone;
    public GameObject[] addGunPos;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Gun"))
        {
            for (int j = 0; j < addGunPos.Length; j++)
                if (addGunPos[j].transform.childCount == 0)
                {
                    Instantiate(GunClone, addGunPos[j].transform.position, Quaternion.identity, addGunPos[j].transform);
                    break;
                }
        }
    }
}
