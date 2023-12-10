using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopKeeperSpeech : MonoBehaviour
{
    GameObject player;
    GameObject shopKeeperCanvas;
    public GameObject characterText;
    public TMP_Text[] dialogs;

    bool hasWeapon = false; // Tag for weapon to get the current weapon on player

    void Start()
    {
        player = GameObject.Find("Player");
        shopKeeperCanvas = GameObject.Find("ShopKeeperCanvas");
        characterText = shopKeeperCanvas.GetComponentsInChildren<TMP_Text>()[2].gameObject;
        shopKeeperCanvas.SetActive(false);
        characterText.SetActive(false);
        Button[] buttons = shopKeeperCanvas.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(CharacterSpeech1);                    
        buttons[1].onClick.AddListener(CharacterSpeech2);  
        dialogs = shopKeeperCanvas.GetComponentsInChildren<TMP_Text>();
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2.0f){
            shopKeeperCanvas.SetActive(true);
            if(!hasWeapon){
                dialogs[0].gameObject.SetActive(true);
                dialogs[1].gameObject.SetActive(true);
                dialogs[0].text = "Hey! Tell me everything \nyou know about the murder!";
                dialogs[1].text = "Good day!\n How have you been doing?";
            }
        }
        else{
            shopKeeperCanvas.SetActive(false);
        }
    }

    void CharacterSpeech1(){
        characterText.SetActive(true);
        if(!hasWeapon){
            characterText.GetComponentsInChildren<TMP_Text>()[0].text = 
            "Ah, straight to the point I see.\n Well, the murder has cast a dark\n cloud over my business, indeed.\n I wish I could help!";
            dialogs[0].gameObject.SetActive(false);
            dialogs[1].gameObject.SetActive(false);
        }
    }

    public void CharacterSpeech2(){
        characterText.SetActive(true);
        if(!hasWeapon){
            characterText.GetComponentsInChildren<TMP_Text>()[0].text = 
            "Business has been slow, \n what with the tragedy and all. \nA murder in our peaceful town… \n Who would have thought?";
            string text = "Have you seen \nanything suspicious?"; 
            dialogs[0].SetText(text); // Doesn't work TODO
            dialogs[1].text = "Have you sold \nany Belladonna lately?"; // TODO
        }
    }
}
