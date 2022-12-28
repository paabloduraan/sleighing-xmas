using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEditor;

public class PlayerMeleeAttack : MonoBehaviour{

      //public Animator animator;
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
      public GameHandler gameHandlerObj;
      public Animator grinch;
      public Animator santa;
      public GameObject player1;
      public GameObject player2;


      void Start(){
           grinch = gameObject.GetComponentInChildren<Animator>();
      }

      void Update(){
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        grinch.SetTrigger("punch");
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
                  if (Input.GetAxis("Attack2") > 0){
                        santa.SetTrigger("punch-san");
                         Attack2();
                         nextAttackTime = Time.time + 1f / attackRate;
                   }

            }
      }

      //grinch attacking santa
      void Attack(){
            //animator.SetTrigger ("Melee");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);

                 if (enemy.name == "Player1_santa") {
                      gameHandlerObj.AddScore2(-1);
                      // Instantiate(treePrefab, new Vector3(
                      //     (player1.transform.position.x),
                      //     (player1.transform.position.y + 4),
                      //     (player1.transform.position.z)),
                      //  Quaternion.identity);
                  }
                //  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
            }
      }

      //santa attacks grinch
      void Attack2(){
            //animator.SetTrigger ("Melee");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);

                  if (enemy.name == "Player2_grinch") {
                      gameHandlerObj.AddScore(-1);
                  }
                //  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
            }
      }

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }

}
