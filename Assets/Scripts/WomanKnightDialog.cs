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
    int previousState = 0;
    GameObject player;
    GameObject womanKnightCanvas;
    TMP_Text characterText;

    Canvas[] womanKnightCanvasChildren;
    Button[] buttons;


    string dagger;
    string pickaxe;
    string poison;

    bool dagger_in_hand;
    bool pickaxe_in_hand;
    bool poison_in_hand;

    void Start()
    {
        player = GameObject.Find("Player");
        womanKnightCanvas = GameObject.Find("WomanKnightCanvas");
        womanKnightCanvasChildren = womanKnightCanvas.transform.GetComponentsInChildren<Canvas>();
        womanKnightCanvas.SetActive(false);

        dagger = "SM_Wep_Dagger_01";
        pickaxe = "SM_Wep_Pickaxe_01";
        poison = "SM_Item_Potion_06";
        
        poison_in_hand =  Utils.getweaponsInHandStatus(poison);
        dagger_in_hand =  Utils.getweaponsInHandStatus(dagger);
        pickaxe_in_hand =  Utils.getweaponsInHandStatus(pickaxe);

        if (dagger_in_hand && !pickaxe_in_hand && !poison_in_hand){
            currentState = 2;
        }
        if (pickaxe_in_hand && !dagger_in_hand && !poison_in_hand){
            currentState = 3;
        }

        currentState = Utils.getState(gameObject.name);

        buttons = womanKnightCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "\n\nHello friend.";
        }
        
    }

    // Update is called once per framem
    void Update()
    {
        previousState = currentState;

        poison_in_hand =  Utils.getweaponsInHandStatus(poison);
        dagger_in_hand =  Utils.getweaponsInHandStatus(dagger);
        pickaxe_in_hand =  Utils.getweaponsInHandStatus(pickaxe);

        if (dagger_in_hand && !pickaxe_in_hand && !poison_in_hand){
            currentState = 2;
        }
        if (pickaxe_in_hand && !dagger_in_hand && !poison_in_hand){
            currentState = 3;
        }
        if(previousState != currentState){
            previousState = currentState;
            buttons = womanKnightCanvasChildren[currentState].GetComponentsInChildren<Button>();
            for(int i = 0; i < buttons.Length; i++){
                buttons[i].onClick.AddListener(ChangeCanvas);
            }
        }

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
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "\n\nHello friend.";
            currentState = 0; // Whenever you leave the conversation you start from the beginning (different beginning depending on weapon)
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
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A2();
        }
        else if(currentState == 1 && currentButton.name == "Q5"){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A5();
        }
        else if(currentState == 0 && currentButton.name == "Q2"){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A2();
        }
        else if(currentState == 1 && currentButton.name == "Q5"){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A5();
        }
        else if(currentState == 2 && currentButton.name == "Q4"){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A4();
        }
        else if(currentState == 3 && currentButton.name == "Q3"){
            characterText = womanKnightCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A3();
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
        string sentence = "Peace be upon you. Sadness grips my heart like a vise; the shadows of tragedy stretch far beyond this sorrowful event. Keep your eyes peeled in this room – the killer might have stashed the murder weapon here somewhere. Come back once you find something.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A2(){
        string sentence = "\n\nI respect you are on duty but our brother has fallen, show some respect!";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A3(){
        string sentence = "I actually have, it should belong to the shopkeeper. A couple of days ago I saw the Viking and Shopkeeper gambling around the shop. The Viking seemed to have brought some wine from distant shores; the poor shopkeeper was utterly besotted, beyond sense or sensibility.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A4(){
        string sentence = "Oh thank you for retrieving my dagger! Suspicion has clouded my heart ever since the Warrior arrived. Old grudges die hard! Surely the memory of our bitter strife against that Warrior, alongside our brother-in-arms, has not escaped your mind?";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A5(){
        string sentence = "\nAs night's cloak enveloped our lands, I found myself lost in prayer at the chapel, seeking solace for a heart burdened by the endless toll of battle.";

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
