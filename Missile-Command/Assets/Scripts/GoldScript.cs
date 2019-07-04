using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
    public GameObject button1;
    public float goldAmount = 0;
    public bool goldCount1 = false;
    public bool goldCount2 = false;
    public bool goldCount3 = false;
    public Text goldText;
   
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ChangeGold();
        goldText.text = goldAmount.ToString("00");
        
    }
    void ChangeGold()
    {
        if (goldCount1 == false && goldCount2 == false && goldCount3 == false)
        {
            goldAmount += 0.3f;
        }
        if (goldCount1 == true && goldCount2 == false && goldCount3 == false)
        {
            goldAmount += 0.6f;
        }
        if (goldCount1 == false && goldCount2 == true && goldCount3 == false)
        {
            goldAmount += 0.9f;
        }
        if (goldCount1 == false && goldCount2 == false && goldCount3 == true)
        {
            goldAmount += 1.2f;
        }
    }
   public void BuyFirstIncrease()
    {
        if (goldAmount > 100f && goldCount1 == false && goldCount2 == false && goldCount3 == false)
        {
            goldAmount -= 100f;
            goldCount1 = true;
        }
    }
    public void BuySecondIncrease()
    {
        if (goldAmount > 200f && goldCount1 == true && goldCount2 == false && goldCount3 == false)
        {
            goldAmount -= 200f;
            goldCount2 = true;
            goldCount1 = false;
        }
    }
    public void BuyThirdIncrease()
    {
        if (goldAmount > 300f && goldCount1 == false && goldCount2 == true && goldCount3 == false)
        {
            goldAmount -= 300f;
            goldCount3 = true;
            goldCount2 = false;
            Destroy(button1);
        }
    }
    
}
