using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoManager : MonoBehaviour
{
    public int leftAmmo = 20;
    public int middleAmmo = 20;
    public int rightAmmo = 20;
    public int totalAmmo;
    public GoldScript gs;

    public Text missileText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalAmmo = leftAmmo + middleAmmo + rightAmmo;
        missileText.text = totalAmmo.ToString();
        if (gs.goldAmount > 50f && Input.GetButtonDown("Jump"))
        {
            leftAmmo += 1;
            rightAmmo += 1;
            middleAmmo += 1;
        }
    }
    public void LeftMissile()
    {
        leftAmmo--; 
    }
    public void MiddleMissile()
    {
        middleAmmo--;
    }
    public void RightMissile()
    {
        rightAmmo--;
    }
}

