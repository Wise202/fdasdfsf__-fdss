using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript2 : MonoBehaviour
{

    public float goldAmount2 = 0;
    public bool goldCount12 = false;
    public bool goldCount22 = false;
    public bool goldCount32 = false;
    public Text goldText2;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ChangeGold();
        goldText2.text = goldAmount2.ToString("00");

    }
    void ChangeGold()
    {
        if (goldCount12 == false && goldCount22 == false && goldCount32 == false)
        {
            goldAmount2 += 0.3f;
        }
        if (goldCount12 == true && goldCount22 == false && goldCount32 == false)
        {
            goldAmount2 += 0.6f;
        }
        if (goldCount12 == false && goldCount22 == true && goldCount32 == false)
        {
            goldAmount2 += 0.9f;
        }
        if (goldCount12 == false && goldCount22 == false && goldCount32 == true)
        {
            goldAmount2 += 1.2f;
        }
    }
    public void BuyFirstIncrease()
    {
        if (goldAmount2 > 100f && goldCount12 == false && goldCount22 == false && goldCount32 == false)
        {
            goldAmount2 -= 100f;
            goldCount12 = true;
        }
    }
    public void BuySecondIncrease()
    {
        if (goldAmount2 > 200f && goldCount12 == true && goldCount22 == false && goldCount32 == false)
        {
            goldAmount2 -= 200f;
            goldCount22 = true;
            goldCount12 = false;
        }
    }
    public void BuyThirdIncrease()
    {
        if (goldAmount2 > 300f && goldCount12 == false && goldCount22 == true && goldCount32 == false)
        {
            goldAmount2 -= 300f;
            goldCount32 = true;
            goldCount22 = false;

        }
    }

}
