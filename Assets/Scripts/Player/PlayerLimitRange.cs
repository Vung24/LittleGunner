using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitRange : MonoBehaviour
{
    float xLimitLeft = -44f, xLimitRight = 32f, xLimitTop = 27f, xLimitBottom = -23f;
    private Vector3 pos;
    public GameObject circleRevive, footprints, particlePosition, character, weapon;
    void Start()
    {
        GameObject circle = Instantiate(circleRevive, particlePosition.transform.position, Quaternion.Euler(-90, 0, 0), transform);
        Destroy(circle, 2f);
        Invoke("Display", 1f);
    }
    void Display()
    {
        Instantiate(footprints, particlePosition.transform.position, Quaternion.identity, transform);
        character.SetActive(true);
        weapon.SetActive(true);
    }
    void Update()
    {
        pos = transform.position;
        float x = Mathf.Clamp(pos.x, xLimitLeft, xLimitRight);
        float y = Mathf.Clamp(pos.y, xLimitBottom, xLimitTop);
        transform.position = new Vector3(x, y, 0);
    }
}
