using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class WomanKnightDialog : MonoBehaviour
{
    // Start is called before the first frame update
    int currentState = 0;
    GameObject player;
    GameObject womanKnightCanvas;
    TMP_Text characterText;

    Canvas[] womanKnightCanvasChildren;
    Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        womanKnightCanvas = GameObject.Find("WomanKnightCanvas");
        womanKnightCanvasChildren = womanKnightCanvas.transform.GetComponentsInChildren<Canvas>();
        womanKnightCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        buttons = womanKnightCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per framem
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            womanKnightCanvas.SetActive(true);
            for (int i = 0; i < womanKnightCanvasChildren.Length; i++)
            {
                if(i == currentState){
                    womanKnightCanvasChildren[i].gameObject.SetActive(true);
                }
                else{
                    womanKnightCanvasChildren[i].gameObject.SetActive(false);
                }
            }
        }
        else{
            womanKnightCanvas.SetActive(false);
        }
    }

    private void ChangeCanvas(){
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        // Change current state based on the current button and the previous state

        if(currentState == 0 && currentButton.name == "Q1"){
            currentState = 1;
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A1();       
        }
        else if(currentState == 0 && currentButton.name == "Q2"){
            A2();
        }
        else if(currentState == 1 && currentButton.name == "Q5"){
            A5();
        }
        
        buttons = womanKnightCanvasChildren[currentState].GetComponentsInChildren<Button>();
        
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }

        for (int i = 0; i < womanKnightCanvasChildren.Length; i++)
        {
            if(i == currentState){
                womanKnightCanvasChildren[i].gameObject.SetActive(true);
            }
            else{
                womanKnightCanvasChildren[i].gameObject.SetActive(false);
            }
        }

        Utils.setState(gameObject.name, currentState);
    }
    void A1(){
        characterText.text = "A1";
    }

    void A2(){
        characterText.text = "A2";
    }

    void A3(){
        characterText.text = "A3";
    }
    
    void A4(){
        characterText.text = "A4";
    }
    void A5(){
        characterText.text = "A5";
    }
}
