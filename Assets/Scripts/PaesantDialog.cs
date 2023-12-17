using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PaesantDialog : MonoBehaviour
{
    // Start is called before the first frame update
    int currentState = 0;
    GameObject player;
    GameObject paesantCanvas;
    TMP_Text characterText;

    Canvas[] paesantCanvasChildren;
    Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        paesantCanvas = GameObject.Find("PeasantCanvas");
        paesantCanvasChildren = paesantCanvas.transform.GetComponentsInChildren<Canvas>();
        paesantCanvas.SetActive(false);

        currentState = Utils.getState(gameObject.name);

        buttons = paesantCanvasChildren[currentState].GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = paesantCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            paesantCanvas.SetActive(true);
            for (int i = 0; i < paesantCanvasChildren.Length; i++)
            {   
                if(i == currentState){
                    
                    paesantCanvasChildren[i].gameObject.SetActive(true);
                }
                else{
                    paesantCanvasChildren[i].gameObject.SetActive(false);
                }
            }
        }
        else{
            paesantCanvas.SetActive(false);

            if (currentState == 3 || currentState == 2){
                currentState = 0;
            }
        }
    }

    private void ChangeCanvas(){
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if(currentState == 0 && currentButton.name == "Q1"){
            currentState = 1;
            characterText = paesantCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A1();       
        }
        else if(currentState == 0 && currentButton.name == "Q2"){
            currentState = 3;
            characterText = paesantCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A2();
        }
        else if(currentState == 1 && currentButton.name == "Q3"){
            currentState = 2;
            characterText = paesantCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            A3();
        }
        else if((currentState == 1 || currentState == 2) && currentButton.name == "Q4"){
            A4();
        }

        else if(currentState == 2 && currentButton.name == "Q5"){
            A5();
        }

        buttons = paesantCanvasChildren[currentState].GetComponentsInChildren<Button>();
        
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].onClick.AddListener(ChangeCanvas);
        }

        for (int i = 0; i < paesantCanvasChildren.Length; i++)
        {
            if(i == currentState){
                paesantCanvasChildren[i].gameObject.SetActive(true);
            }
            else{
                paesantCanvasChildren[i].gameObject.SetActive(false);
            }
        }

        Utils.setState(gameObject.name, currentState);
    }

    void A1(){
        string sentence = "Tending the fields as always. I finally managed to keep the pests away from my dear crops,  Belladona does magic indeed! Sad about the knight though, he was good to us villagers.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A2(){
        string sentence =  "Murder's on everyone\'s lips, sad about the knight for sure. But I swear, I only deal in grains and greens.";
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void A3(){
        string sentence =  "When I was bringing in the harvest to the castle storerooms that night, I saw the Viking skulking around, closer to the walls than you\'d expect for a man of the sea. It's known that the Viking bore a grudge.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    void A4(){
        string sentence =  "\n \nDelivering supplies to the castle, I was. Daily business as always.";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    void A5(){
        string sentence = "\n \nThe knight did burn his ship, after all. Such acts are not easily forgiven.";
        
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
