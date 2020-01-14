using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;             // Times the time between attacks
    public float startTimeBtwAttack;         // Set time between attacks

    public Transform attackPos;              // Get attack gameObject
    public LayerMask whatIsEnemies;          // Define the enemy layer
    public Animator playerAnim;              // Get player animator

    public float attackRange;                // Set attaacking range
    public int damage;                       // Set damage

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0){
            // Attack is allowed
            if (Input.GetButtonDown("Attack")){
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }

        } else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
