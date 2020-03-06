using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ProgessBar : MonoBehaviour
{
    public static ProgessBar instance;

    public float CurrentHealth;//Current Health

    public float MaxHealth = 100.0f;//Max Health

    public Image HealthBar;//Health Bar reference
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Health = MaxHealth;
        //Equaling values
        HealthBar = gameObject.GetComponent<Image>();
        HealthBar.type = Image.Type.Filled;
        HealthBar.fillMethod = Image.FillMethod.Horizontal;
    }

    // Update is called once per frame
    void Update()
    {
        float percentFilled = GameManager.Instance.Health / MaxHealth;
        HealthBar.fillAmount = percentFilled;
        if (percentFilled > .25)//Changing colors
        {
            HealthBar.color = Color.green;
        }
        else
        {
            HealthBar.color = Color.red;
        }
    }
}
