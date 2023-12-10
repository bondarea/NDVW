using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class VikingDialog : MonoBehaviour
{
    // Start is called before the first frame update
    int currentState = 0;
    GameObject player;
    GameObject vikingCanvas;
    TMP_Text characterText;

    Canvas[] vikingCanvasChildren;
    Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        vikingCanvas = GameObject.Find("VikingCanvas");
        vikingCanvasChildren = vikingCanvas.transform.GetComponentsInChildren<Canvas>();
        vikingCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        buttons = vikingCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            //buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
