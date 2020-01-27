using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    private Transform PlayerPos; 
    public int distanceclose;       // How close the boss can get to the player before it stops moving

    private float timeBeforeAttack;
    private float timeBtwAttack;             // Times the time between attacks
    public float startTimeBtwAttack;         // Set time between attacks

    private Transform attackPos;              // Get attack gameObject
    public LayerMask whatIsPlayer;          // Define the enemy layer

    public float attackRangeX;               // Set attacking range on the X-axis
    public float attackRangeY;               // Set attacking range on the Y-axis
    public int damage;                       // Set damage


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackPos = GameObject.FindGameObjectWithTag("BossAttackPos").GetComponent<Transform>();
        timeBeforeAttack = 0.7f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // The target as the player x position
        Vector2 target = new Vector2(PlayerPos.position.x, animator.transform.position.y);

        // Checks if the player is to the left
        // If so flip the boss
        if (PlayerPos.position.x < animator.transform.position.x)
            animator.transform.localScale = new Vector3(-10f, 10f, 1f);
        else
            animator.transform.localScale = new Vector3(10f, 10f, 1f);

        // Time attack with animation
        if (timeBeforeAttack <= 0){
            // Delay between attacks
            if (timeBtwAttack <= 0){
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsPlayer);

                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<PlayerHealth>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            } 
            else{
            timeBtwAttack -= Time.deltaTime;
            }
        }
        else
            timeBeforeAttack -= Time.deltaTime;

        // Check if the player is too far to attack
        if (Vector2.Distance(animator.transform.position, target) > distanceclose)
            animator.SetTrigger("Walk");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
