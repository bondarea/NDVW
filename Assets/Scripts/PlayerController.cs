using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator animator;
    
    private float _speed = 5;
    private float _rotationSpeed = 100;
    private bool idlePlaying = true;
    private Vector3 doorPosition = new Vector3(-9.23f, 0.05f, 27.88f);
    private Vector3 lastPosition;
    private bool isGoingForward = true;
 
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.Play("Idle");
        if(Utils.getScene() && SceneManager.GetActiveScene().name == "VillageScene"){ 
            this.transform.position = doorPosition; 
            Utils.changeScene();
        }
    }

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
 
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);

        if(isNearTheVillageDoor() && SceneManager.GetActiveScene().name == "VillageScene")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneName:"CastleScene"); 
                Utils.changeScene();  
            }
            
        }else if(isNearTheCastleDoor() && SceneManager.GetActiveScene().name == "CastleScene")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneName:"VillageScene");
            }
        }  

        if(Input.GetAxisRaw("Vertical") != 0 && idlePlaying)
        {
            animator.Play("Walking");
            idlePlaying = false;
        }else if(Input.GetAxisRaw("Vertical") == 0 && !idlePlaying)
        {
            animator.Play("Idle");
            idlePlaying = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)){
            animator.Play("Running");
            _speed = 7;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl)){
            if(Input.GetAxisRaw("Vertical") != 0)
            {
                animator.Play("Walking");
            }else
            {
                animator.Play("Idle");
            }
            _speed = 5;
        }

        if(this.transform.position.y > 0.05f){
            this.transform.position = new Vector3(this.transform.position.x, 0.05f, this.transform.position.z);
        }

        if(this.transform.position.z > this.lastPosition.z)
        {
            this.isGoingForward = true;
        }else if(this.transform.position.z < this.lastPosition.z)
        {
            this.isGoingForward = false;
        }

        this.lastPosition = this.transform.position;
    }

    private bool isNearTheVillageDoor()
    {
        return this.transform.position.x >= -10.28f && this.transform.position.x <= -8.28f && this.transform.position.z >= 27.88f && this.transform.position.z <= 28.96f;
    }

    private bool isNearTheCastleDoor()
    {
        return this.transform.position.x >= -1.29f && this.transform.position.x <= 1.16f && this.transform.position.z >= -4.10f && this.transform.position.z <= -2.50f;
    }
    public bool IsGoingForward()
    {
        return this.isGoingForward;
    }
}
