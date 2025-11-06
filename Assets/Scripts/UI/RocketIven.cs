using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RocketIven : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI remainRocket;

    // Update is called once per frame
    void Update()
    {
        remainRocket.text = RocketFire.instance.remain.ToString();
    }
}
