using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image fillBar;
    [SerializeField] private float timeStaminaRestore = 1f, timeCount = 0f;
    public static StaminaBar instance;
    void Start()
    {
        if (instance == null)
            instance = this;
    }
    void Update()
    {
        if (timeCount <= 0f)
        {
            timeCount = timeStaminaRestore;
            if (Player.instance.currSta + 2 <= Player.instance.maxSta)
                Player.instance.currSta += 2;
            UpdateBar(Player.instance.currSta, Player.instance.maxSta);
        }
        else timeCount -= Time.deltaTime;
    }
    public void UpdateBar(int currentVal, int maxVal)
    {
        fillBar.fillAmount = (float)currentVal / (float)maxVal;
        // healthText.text = currentVal.ToString() + " / " + maxVal.ToString();
    }
}
