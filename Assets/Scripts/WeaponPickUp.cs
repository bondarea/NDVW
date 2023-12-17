using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponPickUp : MonoBehaviour
{
    private Transform hand;
    private GameObject[] weapons;
    private bool hasWeapon;
    // Start is called before the first frame update
    void Start()
    {
        hand  = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightThumbProximal);
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        hasWeapon = false;
        foreach (GameObject weapon in weapons)
        {
            Debug.Log(weapon.name);
            Debug.Log(Utils.getWeaponCastlePos(weapon.name)); //TODO: position problem
            if(SceneManager.GetActiveScene().name == "VillageScene"){ 
                if(Utils.getweaponsInCastle(weapon.name) && !Utils.getweaponsInHandStatus(weapon.name)){
                    weapon.SetActive(false);
                }else{
                    weapon.SetActive(true);
                    weapon.transform.position = Utils.getWeaponVillagePos(weapon.name); 
                }
            }
            else{
                if(!Utils.getweaponsInCastle(weapon.name) && !Utils.getweaponsInHandStatus(weapon.name)){
                    weapon.SetActive(false);
                }else{
                    weapon.SetActive(true);
                    weapon.transform.position = Utils.getWeaponCastlePos(weapon.name); 
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        hand  = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightThumbProximal);
        
        // If we have changed scene we need the weapon that is linked to the hand to stay with the player
        foreach (GameObject weapon in weapons)
        {
            if(Utils.getweaponsInHandStatus(weapon.name)){
                weapon.transform.position = hand.transform.position;
                weapon.transform.eulerAngles = new Vector3(0,0,-22);
                weapon.transform.parent = hand;
                weapon.GetComponent<Rigidbody>().useGravity = false;
                weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                hasWeapon = true;
                if(SceneManager.GetActiveScene().name == "VillageScene"){ 
                    Utils.setWeaponInCastle(weapon.name, false);
                }
                else{
                    Utils.setWeaponInCastle(weapon.name, true);
                }
            }
        }

        // Press D to pick up or drop weapons
        foreach (GameObject weapon in weapons)
        {
            if (Vector3.Distance(weapon.transform.position, gameObject.transform.position) < 2.0f && 
                Input.GetKeyDown(KeyCode.D) && weapon.transform.parent == null && !hasWeapon) {  
                weapon.transform.position = hand.transform.position;
                weapon.transform.eulerAngles = new Vector3(0,0,-22);
                weapon.transform.parent = hand;
                weapon.GetComponent<Rigidbody>().useGravity = false;
                weapon.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezeAll;
                hasWeapon = true;
                Utils.setWeaponInHand(weapon.name, true);
            }
            else if(Input.GetKeyDown(KeyCode.D) && weapon.transform.parent != null && hasWeapon){
                weapon.transform.parent = null;
                weapon.GetComponent<Rigidbody>().useGravity = true;
                weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hasWeapon = false;
                Utils.setWeaponInHand(weapon.name, false);
            }
        }

        foreach (GameObject weapon in weapons)
        {
            if(SceneManager.GetActiveScene().name == "VillageScene"){ 
                if(Utils.getweaponsInCastle(weapon.name) && !Utils.getweaponsInHandStatus(weapon.name)){
                    weapon.SetActive(false);
                }else{
                    weapon.SetActive(true);
                    weapon.transform.position = Utils.getWeaponVillagePos(weapon.name); 
                }
            }
            else{
                if(!Utils.getweaponsInCastle(weapon.name) && !Utils.getweaponsInHandStatus(weapon.name)){
                    weapon.SetActive(false);
                }else{
                    weapon.SetActive(true);
                    weapon.transform.position = Utils.getWeaponCastlePos(weapon.name); 
                }
            }
        }
    }
}
