using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Patrol EnemyController;
    public Animator animator;                // Get Skeleton animator
    public Collider2D DeathDisableCollider;
    public int damagetoplayer = 1;
    public int EnemyHealth;

    private float dazedTime;
    public float startDazedTime;

    private float TimeBtwAttack;
    public float StartTimeBtwAttack;

    void Start(){
        DeathDisableCollider.enabled = true;
    }

     void Update(){
        // Plays death animation when the enemy dies
        if (EnemyHealth <= 0){
           DeathDisableCollider.enabled = false;
           animator.SetTrigger("Dead");
        }

        // Makes the character the enemy stop
        if (dazedTime <= 0){
            EnemyController.speed = EnemyController.sendAssignedSpeed();
        } else {
            EnemyController.speed = 0;
            dazedTime -= Time.deltaTime;
        }//else
    }

    // This fucntion checks what the enemy collided with and deals damage if it is the player
   void OnTriggerEnter2D(Collider2D damageCollider) {
       if (TimeBtwAttack <= 0){
            // This checks if the collider touched a player
            if (damageCollider.CompareTag("Player")) {
            // Player takes damage
            damageCollider.GetComponent<PlayerHealth>().health -= damagetoplayer;

            Debug.Log(damageCollider.GetComponent<PlayerHealth>().health);
            }
       } else{
            TimeBtwAttack -= Time.deltaTime;
       }

       damageCollider.GetComponent<PlayerHealth>().BounceBack = true;
       Debug.Log(damageCollider.GetComponent<PlayerHealth>().BounceBack);
   }

   // This function gets called every time the enemy gets hit
   public void TakeDamage(int damage){
       dazedTime = startDazedTime;
       EnemyHealth -= damage;
       Debug.Log("damage Taken, health " + EnemyHealth);
   }

   void DestroyEnemy(){
       Destroy(gameObject);
   }
}
