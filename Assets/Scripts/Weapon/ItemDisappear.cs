using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisappear : MonoBehaviour
{
    public GameObject item;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            Destroy(item);
    }
}
