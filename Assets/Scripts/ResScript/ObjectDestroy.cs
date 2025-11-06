using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public float timeLife;
    void Update()
    {
        Destroy(gameObject, timeLife);
    }
}
