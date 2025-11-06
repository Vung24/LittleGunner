using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI healthText;
    public static HealthBar instance;

    void Start()
    {
        if(instance == null)
            instance = this;
        // currHealth = PlayerHealth.instance.maxHealth;
    }

    public void UpdateBar(int currentVal, int maxVal)
    {
        // damage = currHealth - currentVal;
        // currHealth = currentVal;
        // GameObject floatClone = Instantiate(floatText, transform.position, Quaternion.identity, transform);
        // floatClone.GetComponent<TextMeshPro>().text = damage.ToString();
        // floatClone.GetComponent<TextMeshPro>().color = new Color(0.9137255f, 0.1051038f, 0.0235294f, 1f);
        // Destroy(floatClone, 1f);
        fillBar.fillAmount = (float)currentVal / (float)maxVal;
        healthText.text = currentVal.ToString() + " / " + maxVal.ToString();
    }
}
