using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopkeeperDialog : MonoBehaviour
{
    // Start is called before the first frame update
    int currentState = 0;
    GameObject player;
    GameObject shopkeeperCanvas;
    TMP_Text characterText;

    Canvas[] shopkeeperCanvasChildren;
    Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        shopkeeperCanvas = GameObject.Find("ShopKeeperCanvas");
        shopkeeperCanvasChildren = shopkeeperCanvas.transform.GetComponentsInChildren<Canvas>();
        shopkeeperCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        buttons = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            shopkeeperCanvas.SetActive(true);
            for (int i = 0; i < shopkeeperCanvasChildren.Length; i++)
            {   
                if(i == currentState){
                    
                    shopkeeperCanvasChildren[i].gameObject.SetActive(true);
                }
                else{
                    shopkeeperCanvasChildren[i].gameObject.SetActive(false);
                }
            }
        }
        else{
            shopkeeperCanvas.SetActive(false);
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];

            if(currentState != 0){
                characterText.text = "\nWelcome back!";
            }
            else{
                characterText.text = "\nGood day!";
            }
        }
    }

    private void ChangeCanvas(){
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentState == 0 && currentButton.name == "Q1"){
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A1();
        }
        else if(currentState == 0 && currentButton.name == "Q2"){
            currentState = 1;
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A2();
        }else if(currentState == 1 && currentButton.name == "Q3"){
            currentState = 2;
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A3();
        }else if(currentState == 1 && currentButton.name == "Q4"){
            A4();
        }else if(currentState == 1 && currentButton.name == "Q5"){
            A5();
        }else if(currentState == 2 && currentButton.name == "Q4"){
            A4();
        }else if(currentState == 2 && currentButton.name == "Q5"){
            A5();
        }

        buttons = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<Button>();
        
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }

        for (int i = 0; i < shopkeeperCanvasChildren.Length; i++)
        {
            if(i == currentState){
                shopkeeperCanvasChildren[i].gameObject.SetActive(true);
            }
            else{
                shopkeeperCanvasChildren[i].gameObject.SetActive(false);
            }
        }

        Utils.setState(gameObject.name, currentState);
    }
    void A1(){
    string sentence = "Ah, straight to the point I see. Well, the murder has cast a dark cloud over my business, indeed. I wish I could help!";

    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
    }

    void A2(){
        string sentence = "Business has been slow, what with the tragedy and all. A murder in our peaceful town… Who would have thought?";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A3(){
        string sentence = "Suspicious? Well, everyone's been on edge."; // without pickaxe
        // string sentence = "Where did you find that pickaxe?! I indeed wondered for the last couple of days where it went - someone must have stolen it! No ordinary pickaxe, mind you; strong enough to break through castle stone, and even kill a man, that one was.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A4(){
        string sentence = "Belladonna? Aye, it's a dangerous thing. You can make some toxic potion with that. Sold some to the Peasant not long ago.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A5(){
        string sentence = "I was here, taking stock and tending to customers. This shop is my life's work, and I can't afford to leave it unattended.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        characterText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            characterText.text += letter;
            yield return null;
        }
    }

}
