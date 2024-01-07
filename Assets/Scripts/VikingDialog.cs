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
    int previousState = 0;
    GameObject player;
    GameObject vikingCanvas;
    TMP_Text characterText;

    Canvas[] vikingCanvasChildren;
    Button[] buttons;

    string poison;
    bool poison_in_hand;
    string pickaxe;
    bool pickaxe_in_hand;

    void Start()
    {
        player = GameObject.Find("Player");
        vikingCanvas = GameObject.Find("VikingCanvas");
        vikingCanvasChildren = vikingCanvas.transform.GetComponentsInChildren<Canvas>();
        vikingCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        poison = "SM_Item_Potion_06";
        poison_in_hand =  Utils.getweaponsInHandStatus(poison);
        if (poison_in_hand && currentState == 0){
            currentState = 1;
        }

        buttons = vikingCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
        
        characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];

    }

    // Update is called once per frame
    void Update()
    {
        previousState = currentState;
        poison_in_hand =  Utils.getweaponsInHandStatus(poison);

        if (poison_in_hand && currentState == 0){
            currentState = 1;
        }

        if(previousState != currentState){
            previousState = currentState;
            buttons = vikingCanvasChildren[currentState].GetComponentsInChildren<Button>();
            for(int i = 0; i < buttons.Length; i++){
                buttons[i].onClick.AddListener(ChangeCanvas);
            }
        }

        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            vikingCanvas.SetActive(true);
            for (int i = 0; i < vikingCanvasChildren.Length; i++)
            {   
                if(i == currentState){
                    vikingCanvasChildren[i].gameObject.SetActive(true);
                }
                else{
                    vikingCanvasChildren[i].gameObject.SetActive(false);
                }
            }
        }
        else{
            vikingCanvas.SetActive(false);
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "\n\nAhoy!";
            currentState = 0;
        }
    }

    private void ChangeCanvas(){
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentState == 0 && currentButton.name == "Q1"){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A1();
        }else if(currentState == 1 && currentButton.name == "Q3"){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A3();
        }else if(currentState == 1 && currentButton.name == "Q2"){
            currentState = 2;
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A2();
        }else if(currentState == 2 && currentButton.name == "Q4"){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A4();
        }else if(currentState == 2 && currentButton.name == "Q5"){
            characterText = vikingCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A5();
        }
        buttons = vikingCanvasChildren[currentState].GetComponentsInChildren<Button>();
        
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }

        for (int i = 0; i < vikingCanvasChildren.Length; i++)
        {
            if(i == currentState){
                vikingCanvasChildren[i].gameObject.SetActive(true);
            }
            else{
                vikingCanvasChildren[i].gameObject.SetActive(false);
            }
        }

        Utils.setState(gameObject.name, currentState);
    }

    void A1(){
        string sentence = "Ha! You come at me with accusations as sharp as a serpent's tooth? Mind your tongue, or it might find itself cut from your mouth!";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A2(){
        string sentence = "\nAye, a good day to you. Nothing extraordinary.";
        Debug.Log("A2");

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A3(){
        string sentence = "I did catch that Peasant heading to the castle with all sorts of bottles, but with no goods to deliver. He pretends to tread lightly, but I trust him as I would a serpent.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A4(){
        string sentence = "I was out hunting; a man's gotta eat. I then went straight to my ship afterwards to feast.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A5(){
        string sentence = "\nThis? Oh, the blood's from the day's catch.";

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
