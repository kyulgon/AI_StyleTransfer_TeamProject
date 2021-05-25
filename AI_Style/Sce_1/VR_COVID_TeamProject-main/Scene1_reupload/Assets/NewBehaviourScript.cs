using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private Transform monsterTr;
    private Transform playerTr;
    private Animator animator;
    //public float stopDist = 2.0f;
    public float dist;
    void Start()
    {
        
        print("start");
        
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print("update");
        dist = Vector3.Distance(playerTr.position, monsterTr.position);
        nvAgent.destination = playerTr.position;
        animator.SetBool("isWalk", true);
        //nvAgent.isStopped = true;
        //if(dist < stopDist)
        //{
        //    animator.SetBool("isWalk", false);
        //}
        //else
        //{
        //    animator.SetBool("isWalk", true);
        //}
    }
}
