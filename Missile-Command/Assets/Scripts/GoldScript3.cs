using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript3 : MonoBehaviour
{

    public float goldAmount3 = 0;
    public bool goldCount13 = false;
    public bool goldCount23 = false;
    public bool goldCount33 = false;
    public Text goldText3;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ChangeGold();
        goldText3.text = goldAmount3.ToString("00");

    }
    void ChangeGold()
    {
        if (goldCount13 == false && goldCount23 == false && goldCount33 == false)
        {
            goldAmount3 += 0.3f;
        }
        if (goldCount13 == true && goldCount23 == false && goldCount33 == false)
        {
            goldAmount3 += 0.6f;
        }
        if (goldCount13 == false && goldCount23 == true && goldCount33 == false)
        {
            goldAmount3 += 0.9f;
        }
        if (goldCount13 == false && goldCount23 == false && goldCount33 == true)
        {
            goldAmount3 += 1.2f;
        }
    }
    public void BuyFirstIncrease()
    {
        if (goldAmount3 > 100f && goldCount13 == false && goldCount23 == false && goldCount33 == false)
        {
            goldAmount3 -= 100f;
            goldCount13 = true;
        }
    }
    public void BuySecondIncrease()
    {
        if (goldAmount3 > 200f && goldCount13 == true && goldCount23 == false && goldCount33 == false)
        {
            goldAmount3 -= 200f;
            goldCount23 = true;
            goldCount13 = false;
        }
    }
    public void BuyThirdIncrease()
    {
        if (goldAmount3 > 300f && goldCount13 == false && goldCount23 == true && goldCount33 == false)
        {
            goldAmount3 -= 300f;
            goldCount33= true;
            goldCount23 = false;

        }
    }

}
