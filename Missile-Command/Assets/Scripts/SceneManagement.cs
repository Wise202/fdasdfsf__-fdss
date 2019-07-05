using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
   public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quitscene()
    {
        Application.Quit();
    }
}
