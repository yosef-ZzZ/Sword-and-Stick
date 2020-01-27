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

    public float attackRangeX;               // Set attacking range on the X-axis
    public float attackRangeY;               // Set attacking range on the Y-axis
    public int damage;                       // Set damage

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0){
            // Attack is allowed
            if (Input.GetButtonDown("Attack")){
                // Activate animation
                playerAnim.SetBool("StopAttack", false);
                playerAnim.SetTrigger("attack");
                playerAnim.SetBool("StopAttack", true);
                // Play sword sound
                SoundManagerS.PlaySound("SwordSlash");

                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    if (enemiesToDamage[i].CompareTag("Enemy"))
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    else
                        enemiesToDamage[i].GetComponent<SecondBossHealth>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }

        } else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
