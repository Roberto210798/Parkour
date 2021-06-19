using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public GameObject DetectGround;
    public bool isGrounded;
    public GameObject point;
    NavMeshAgent navAgent;
    Animator animator;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        //GroundCheck();
        animator.SetFloat("Viteza", navAgent.velocity.magnitude);
        navAgent.SetDestination(point.transform.position);
    }

    // private void MoveToPosition(){
    //     RaycastHit hit;
    //     if(Physics.Raycast(point, out hit, groundLayerMask)){
    //         navAgent.SetDestination(hit.point);
    //     }
    // }

    void OnTriggerStay(Collider col) {
        
    }
}
