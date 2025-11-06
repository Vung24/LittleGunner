using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabID : MonoBehaviour
{
    public int id;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        rectTransform.anchoredPosition = Vector2.zero;
    }
}
