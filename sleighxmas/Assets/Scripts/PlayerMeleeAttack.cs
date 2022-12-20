using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour{

      //public Animator animator;
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
      public GameHandler gameHandlerObj;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
      }

      void Update(){
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
                  if (Input.GetAxis("Attack2") > 0){
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
                      gameHandlerObj.AddScore2(-2);
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
                      gameHandlerObj.AddScore(-2);

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
