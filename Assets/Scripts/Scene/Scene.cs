using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void On_MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void On_StartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void On_Quit()
    {
        Application.Quit();
    }
}
