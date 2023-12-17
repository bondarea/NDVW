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
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        //if(currentState != 0){
        characterText = warriorCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
        characterText.text = "\nAh... A knight again.";
        

        characterText = warriorCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            warriorCanvas.SetActive(true);
            for (int i = 0; i < warriorCanvasChildren.Length; i++)
            {   
                if(i == currentState){
                    
                    warriorCanvasChildren[i].gameObject.SetActive(true);
                }
                else{
                    warriorCanvasChildren[i].gameObject.SetActive(false);
                }
            }
        }
        else{
            warriorCanvas.SetActive(false);
            characterText = warriorCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "\nAh... A knight again.";
        }
    }

    private void ChangeCanvas(){
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentState == 0 && currentButton.name == "Q1"){
            A1();
        }else if(currentState == 0 && currentButton.name == "Q2"){
            A2();
        }else if(currentState == 0 && currentButton.name == "Q3"){
            A3();
        }else if(currentState == 0 && currentButton.name == "Q4"){
            A4();
        }

        buttons = warriorCanvasChildren[currentState].GetComponentsInChildren<Button>();
        
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }

        for (int i = 0; i < warriorCanvasChildren.Length; i++)
        {
            if(i == currentState){
                warriorCanvasChildren[i].gameObject.SetActive(true);
            }
            else{
                warriorCanvasChildren[i].gameObject.SetActive(false);
            }
        }

        Utils.setState(gameObject.name, currentState);
    }

    void A1(){
        string sentence = "\nYou waste no time. A quality I respect. I hope my visit here has not stoked the fires of conspiracy.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A2(){
        string sentence = "These lands are tense, filled with old memories and unsettled scores. I’m just passing through, but it seems trouble likes to follow.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A3(){
        string sentence = "Suspicion hangs over this town like a fog. I did hear a heated bargain between the Shopkeeper and your fallen comrade over some big debts.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    
    }
    
    void A4(){
        string sentence = "I was discussing old wounds and battles with the Woman Knight. We’ve had our clashes, and I've had my share of disputes with your knights, but murder? That's not my way.";

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
