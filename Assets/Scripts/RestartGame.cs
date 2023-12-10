using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1;
        Health_manager.health = 4;
        //SceneManager.LoadScene(0);
    }
}
