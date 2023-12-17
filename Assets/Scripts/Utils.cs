using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    private static bool scene = false; // False = village True = castle
    private static Dictionary<string, int> states = new Dictionary<string, int>();
    private static Dictionary<string, bool> weaponsInHand = new Dictionary<string, bool>();
    private static Dictionary<string, bool> weaponsInCastle = new Dictionary<string, bool>();
    private static Dictionary<string, Vector3> weaponPosInCastle = new Dictionary<string, Vector3>();
    private static Dictionary<string, Vector3> weaponPosInVillage = new Dictionary<string, Vector3>();

    static void Awake()
    {
        // Fill in the dialog states for each character if not done
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");  
        if(characters.Length != 0){
            if(!states.ContainsKey(characters[0].name)){
                foreach (GameObject character in characters)
                {
                    states[character.name] = 0;
                }  
            }
        } 
        // Fill in the status for the weapon in hand if not done
        GameObject[] weaponObjects = GameObject.FindGameObjectsWithTag("Weapon");  
        if(weaponObjects.Length != 0){
            if(!weaponsInHand.ContainsKey(weaponObjects[0].name)){
                foreach (GameObject weapon in weaponObjects)
                {
                    weaponsInHand[weapon.name] = false;
                }  
            }
        }
        // Fill in the location of the weapon if not done
        foreach (GameObject weapon in weaponObjects)
        {
            if(!weaponsInCastle.ContainsKey(weapon.name)){
                Debug.Log(weapon.name);
                if(weapon.name == "SM_Wep_Dagger_01"){
                    weaponsInCastle[weapon.name] = false;
                }
                else{
                    weaponsInCastle[weapon.name] = true;
                }
                Debug.Log(weaponsInCastle[weapon.name]);
            }
        }

        // Fill in the position of the weapon if not done
        if(weaponObjects.Length != 0){
            if(!scene){
                if(!weaponPosInVillage.ContainsKey(weaponObjects[0].name)){
                    foreach (GameObject weapon in weaponObjects)
                    {
                        weaponPosInVillage[weapon.name] = weapon.transform.position;
                    }  
                }
            }
            else{
                if(!weaponPosInCastle.ContainsKey(weaponObjects[0].name)){
                    foreach (GameObject weapon in weaponObjects)
                    {
                        weaponPosInCastle[weapon.name] = weapon.transform.position;
                    }  
                }
            }
        }
    }

    public static void changeScene(){scene = !scene;}
    public static bool getScene(){return scene;}
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
    public static void setWeaponInHand(string weaponName, bool pickedUp){
        weaponsInHand[weaponName] = pickedUp;
    }
    public static bool getweaponsInHandStatus(string weaponName){
        if(weaponsInHand.ContainsKey(weaponName)){
            return weaponsInHand[weaponName];
        }
        else{
            return false;
        }
    }
    public static void setWeaponInCastle(string weaponName, bool castle){
        weaponsInCastle[weaponName] = castle;
    }
    public static bool getweaponsInCastle(string weaponName){
        if(weaponsInCastle.ContainsKey(weaponName)){
            return weaponsInCastle[weaponName];
        }
        else{
            if(weaponName == "SM_Wep_Dagger_01"){
                weaponsInCastle[weaponName] = false;
            }
            else{
                weaponsInCastle[weaponName] = true;
            }
            return weaponsInCastle[weaponName];
        }
    }
    public static void setWeaponVillagePos(string weaponName, Vector3 weaponPos){
        weaponPosInVillage[weaponName] = weaponPos;
    }
    public static Vector3 getWeaponVillagePos(string weaponName){
        if(weaponPosInVillage.ContainsKey(weaponName)){
            return weaponPosInVillage[weaponName];
        }
        else{
            return GameObject.Find(weaponName).transform.position;
        }
    }
    public static void setWeaponCastlePos(string weaponName, Vector3 weaponPos){
        weaponPosInCastle[weaponName] = weaponPos;
    }
    public static Vector3 getWeaponCastlePos(string weaponName){
        if(weaponPosInCastle.ContainsKey(weaponName)){
            return weaponPosInCastle[weaponName];
        }
        else{
            return GameObject.Find(weaponName).transform.position;
        }
    }
}
