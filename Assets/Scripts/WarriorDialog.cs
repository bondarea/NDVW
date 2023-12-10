using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class WarriorDialog : MonoBehaviour
{
    // Start is called before the first frame update
    int currentState = 0;
    GameObject player;
    GameObject warriorCanvas;
    TMP_Text characterText;

    Canvas[] warriorCanvasChildren;
    Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        warriorCanvas = GameObject.Find("WarriorCanvas");
        warriorCanvasChildren = warriorCanvas.transform.GetComponentsInChildren<Canvas>();
        warriorCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        buttons = warriorCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            //buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = warriorCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
