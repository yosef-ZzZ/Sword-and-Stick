using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damagetoplayer = 1;
    public int EnemyHealth;

     void Update()
    {
        if (EnemyHealth <= 0){
            Destroy(gameObject);
        }
    }

    // This fucntion checks what the enemy collided with and deals damage if it is the player
   void OnTriggerEnter2D(Collider2D damageCollider) {
       // This checks if the collider touched a player
       if (damageCollider.CompareTag("Player")) {
           // Player takes damage
           damageCollider.GetComponent<PlayerHealth>().health -= damagetoplayer;

           Debug.Log(damageCollider.GetComponent<PlayerHealth>().health);
       }
   }

   // This function gets called every time the enemy gets hit
   public void TakeDamage(int damage){
       EnemyHealth -= damage;
       Debug.Log("damage Taken, health " + EnemyHealth);
   }
}
