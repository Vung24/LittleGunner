using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveInput;
    public Animator animator;
    public SpriteRenderer characterSR;
    public float Rolltime = 0.25f, rollbust = 2f;
    private float roll = 0f, ghostTimeDelay = 0.03f;
    public bool rollOnce = false;
    public GameObject ghostCharPrefab;
    private IEnumerator dashEffectCoroutine;
    public int currSta, maxSta = 100;
    public static Player instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        currSta = maxSta;
        StaminaBar.instance.UpdateBar(currSta, maxSta); 
        dashEffectCoroutine = DashEffectCoroutine();
    }
    void Update()
    {
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        // animator.SetBool("Roll",rollOnce);
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (moveInput.magnitude > 0)
        {
            moveInput.Normalize();
        }
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        if (moveInput.x > 0) characterSR.transform.localScale = new Vector3(1, 1, 0);
        if (moveInput.x < 0) characterSR.transform.localScale = new Vector3(-1, 1, 0);
        if (Input.GetKeyDown(KeyCode.Space) && roll <= 0 && rollOnce == false && currSta > 20)
        {
            moveSpeed += rollbust;
            roll = Rolltime;
            rollOnce = true;
            currSta -= 20;
            StaminaBar.instance.UpdateBar(currSta, maxSta);
            StartCoroutine(dashEffectCoroutine);
            // StartDashEffect();
        }
        if (rollOnce == true && roll <= 0)
        {
            moveSpeed -= rollbust;
            rollOnce = false;
            // StopDashEffect();
            StopCoroutine(dashEffectCoroutine);
        }
        else
        {
            roll -= Time.deltaTime;
        }
    }
    public IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghostClone = Instantiate(ghostCharPrefab, transform.position, transform.rotation);
            Destroy(ghostClone, 1f);
            yield return new WaitForSeconds(ghostTimeDelay);
        }

    }
}
