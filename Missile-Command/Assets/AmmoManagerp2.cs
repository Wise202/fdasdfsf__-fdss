using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoManagerp2 : MonoBehaviour
{
    public int leftAmmo2 = 20;
    public int middleAmmo2 = 20;
    public int rightAmmo2 = 20;
    public int totalAmmo2;
    public GoldScript2 gs2;

    public Text missileText2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalAmmo2 = leftAmmo2 + middleAmmo2 + rightAmmo2;
        missileText2.text = totalAmmo2.ToString();
        if (gs2.goldAmount2 > 50f && Input.GetButtonDown("p2Fire3"))
        {
            leftAmmo2 += 1;
            rightAmmo2 += 1;
            middleAmmo2 += 1;
        }
    }
    public void LeftMissile()
    {
        leftAmmo2--;
    }
    public void MiddleMissile()
    {
        middleAmmo2--;
    }
    public void RightMissile()
    {
        rightAmmo2--;
    }
}

