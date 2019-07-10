using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General3 : MonoBehaviour
{
    public int playerThreeHealth = 4;

    public GameObject gameOverScreen;

    // Update is called once per frame
    void Update()
    {
        if (playerThreeHealth <= 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }
}
