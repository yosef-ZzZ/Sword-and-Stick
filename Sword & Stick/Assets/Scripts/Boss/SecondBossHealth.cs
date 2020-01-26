using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossHealth : MonoBehaviour
{
    public int BossHealth;     // Bosses health counter
    public GameObject effect;
    public Animator animator;   // Get Boss animator

    private void Update() {
        if (BossHealth <= 0){
            animator.SetTrigger("Dead");
        }
    }

    // This function gets called every time the enemy gets hit
   public void TakeDamage(int damage){
       Instantiate(effect, transform.position, Quaternion.identity);
       BossHealth -= damage;
       Debug.Log("damage Taken, health " + BossHealth);
   }

   void DestroyEnemy(){
       Destroy(gameObject);
   }
}
