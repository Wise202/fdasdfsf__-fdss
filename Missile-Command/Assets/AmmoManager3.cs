using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoManager3 : MonoBehaviour
{
    public int leftAmmo3 = 20;
    public int middleAmmo3 = 20;
    public int rightAmmo3 = 20;
    public int totalAmmo3;
    public GoldScript3 gs3;

    public Text missileText2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalAmmo3 = leftAmmo3 + middleAmmo3 + rightAmmo3;
        missileText2.text = totalAmmo3.ToString();
        if (gs3.goldAmount3 > 50f && Input.GetButtonDown("p2Fire3"))
        {
            leftAmmo3 += 1;
            rightAmmo3 += 1;
            middleAmmo3 += 1;
        }
    }
    public void LeftMissile()
    {
        leftAmmo3--;
    }
    public void MiddleMissile()
    {
        middleAmmo3--;
    }
    public void RightMissile()
    {
        rightAmmo3--;
    }
}

