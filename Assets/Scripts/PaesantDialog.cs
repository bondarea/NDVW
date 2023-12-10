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
            //buttons[i].onClick.AddListener(ChangeCanvas);
        }
        
        if(currentState != 0){
            characterText = paesantCanvasChildren[currentState].GetComponentsInChildren<TMP_Text>()[^1];
            characterText.text = "Welcome back";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
