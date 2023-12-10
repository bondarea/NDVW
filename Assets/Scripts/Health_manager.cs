using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_manager : MonoBehaviour
{
    public GameObject gameover, health_bar0, health_bar1, health_bar2, health_bar3;
    public static int health;
    //In the other scripts, add the following if the solution is wrong: 
    // Health_manager.health -= 1; 

    void Start()
    {
        health = 4;
        health_bar0.gameObject.SetActive(true);
        health_bar1.gameObject.SetActive(true);
        health_bar2.gameObject.SetActive(true);
        health_bar3.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (health)
        {
            case 4:
                health_bar0.gameObject.SetActive(true);
                health_bar1.gameObject.SetActive(true);
                health_bar2.gameObject.SetActive(true);
                health_bar3.gameObject.SetActive(true);
                break;
            case 3:
                health_bar0.gameObject.SetActive(true);
                health_bar1.gameObject.SetActive(true);
                health_bar2.gameObject.SetActive(true);
                health_bar3.gameObject.SetActive(false);
                break;
            case 2:
                health_bar0.gameObject.SetActive(true);
                health_bar1.gameObject.SetActive(true);
                health_bar2.gameObject.SetActive(true);
                health_bar3.gameObject.SetActive(false);
                break;
            case 1:
                health_bar0.gameObject.SetActive(true);
                health_bar1.gameObject.SetActive(true);
                health_bar2.gameObject.SetActive(false);
                health_bar3.gameObject.SetActive(false);
                break;
            case 0:
                health_bar0.gameObject.SetActive(true);
                health_bar1.gameObject.SetActive(true);
                health_bar2.gameObject.SetActive(false);
                health_bar3.gameObject.SetActive(false);
                break;
            default:
                health_bar0.gameObject.SetActive(false);
                health_bar1.gameObject.SetActive(false);
                health_bar2.gameObject.SetActive(false);
                health_bar3.gameObject.SetActive(false);
                gameover.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}
