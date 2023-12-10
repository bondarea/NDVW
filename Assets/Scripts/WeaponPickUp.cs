using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    private Transform hand;
    private GameObject[] weapons;
    private Transform cameraTransform;
    private bool hasWeapon;
    // Start is called before the first frame update
    void Start()
    {
        hand  = gameObject.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightThumbProximal);
        cameraTransform = Camera.main.transform;
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject weapon in weapons)
        {
            if (Vector3.Distance(weapon.transform.position, gameObject.transform.position) < 2.0f && 
                Input.GetKeyDown(KeyCode.F) && weapon.transform.parent == null && !hasWeapon) {  
                weapon.transform.position = hand.transform.position;
                weapon.transform.eulerAngles = new Vector3(0,0,-22);
                weapon.transform.parent = hand;
                weapon.GetComponent<Rigidbody>().useGravity = false;
                weapon.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezeAll;
                hasWeapon = true;
            }
            else if(Input.GetKeyDown(KeyCode.F) && weapon.transform.parent != null && hasWeapon){
                weapon.transform.parent = null;
                weapon.GetComponent<Rigidbody>().useGravity = true;
                weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hasWeapon = false;
            }
        }
    }
}
