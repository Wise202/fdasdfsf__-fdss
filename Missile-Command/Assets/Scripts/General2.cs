using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General2 : MonoBehaviour
{
    public int playerTwoHealth = 4;

    public GameObject gameOverScreen;

    // Update is called once per frame
    void Update()
    {
        if (playerTwoHealth <= 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }
}
