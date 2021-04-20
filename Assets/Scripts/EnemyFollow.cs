using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool gameover = false;
    public GameObject Player;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject Enemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Attack;
    public bool GAMEOVER = false;

    void Update(){
        transform.LookAt(Player.transform.position);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Attack) && !gameover) {
           TargetDistance = Vector3.Distance(Player.transform.position,Enemy.transform.position);
            if(TargetDistance < AllowedRange){
                EnemySpeed = 0.025f;
                if(AttackTrigger == 0){
                    Enemy.GetComponent<Animation>().Play("walk");
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position , EnemySpeed);
                }
            }
            else{
                EnemySpeed = 0;
                Enemy.GetComponent<Animation>().Play("idle");
            }
        }
        if(AttackTrigger == 1){
            gameover = true;
            Enemy.GetComponent<Animation>().Play("final_attack");
            Invoke("deleteEnemy",4.3f);
        }
    }

    void OnTriggerEnter(){
        AttackTrigger = 1;
    }
    
    void OnTriggerExit(){
        AttackTrigger = 0;
    }

    void deleteEnemy(){
        Destroy(Enemy);
        AttackTrigger = 2;
    }
}
