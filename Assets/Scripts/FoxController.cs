using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxController : MonoBehaviour
{
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    public GameObject player;
    private Vector3 offset;
    private bool idlePlaying = true;
    private Vector3 doorPosition = new Vector3(-1.23f, 0.05f, 1.92f);

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play("Idle");

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        this.transform.position = player.transform.position;

        if(Utils.isCastleVisited() && SceneManager.GetActiveScene().name == "VillageScene"){ 
            this.transform.position = doorPosition;
        }

        Debug.Log("Fox: " + this.transform.position);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().IsGoingForward())
        {
            offset = new Vector3(0.0f, 0.0f, -1.0f);
        }else
        {
            offset = new Vector3(0.0f, 0.0f, 1.0f);
        }

        agent.destination = player.transform.position + offset;

        if((agent.destination - this.transform.position).magnitude >= 0.1f && idlePlaying)
        {
            animator.Play("Running");
            idlePlaying = false;
        }else if((agent.destination - this.transform.position).magnitude < 0.1f && !idlePlaying)
        {
            animator.Play("Idle");
            idlePlaying = true;
        }
    }
}
