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
            //buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = shopkeeperCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
