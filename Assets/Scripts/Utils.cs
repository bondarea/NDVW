using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    private static bool castleVisited = false;

    private static Dictionary<string, int> states = new Dictionary<string, int>();

    static void Awake()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");  
        if(characters.Length != 0){
            if(!states.ContainsKey(characters[0].name)){
                foreach (GameObject character in characters)
                {
                    states[character.name] = 0;
                }  
            }
        } 
    }

    public static void setCastleVisited(){ 
        castleVisited = true; 
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");  
        if(characters.Length != 0){
            if(!states.ContainsKey(characters[0].name)){
                foreach (GameObject character in characters)
                {
                    states[character.name] = 0;
                }   
            }   
        }
    }

    public static bool isCastleVisited(){ return castleVisited; }

    public static void setState(string characterName, int state){
        states[characterName] = state;
    }

    public static int getState(string characterName){
        if(states.ContainsKey(characterName)){
            return states[characterName];
        }
        else{
            return 0;
        }
    }
}
