using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Behaviour : StateMachineBehaviour
{
    public float speed;        // Movement speed
    private Transform PlayerPos; 

    public int distanceclose;       // How close the boss can get to the player before it stops moving
    public int howfar;              // How far the boss is away from the player before it starts moving
    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // The target as the player x position
        Vector2 target = new Vector2(PlayerPos.position.x, animator.transform.position.y);

        // Check if the player is close enough to attack
        // If not move towards the player
        if (Vector2.Distance(animator.transform.position, target) > distanceclose)
        {
            // Checks if the player is to the left
            // If so flip the boss
            if (PlayerPos.position.x < animator.transform.position.x)
                animator.transform.localScale = new Vector3(-10f, 10f, 1f);
            else
                animator.transform.localScale = new Vector3(10f, 10f, 1f);

            // Go players position
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        } else
        {
            // Pick a random number to choose an attack
            rand = Random.Range(0,2);

            if (rand == 0)
                animator.SetTrigger("NormalAttack");
            else
                animator.SetTrigger("SpinAttack");

        }

        // If the player is not in range go back to idle
        if(Vector2.Distance(animator.transform.position, target) > howfar) {
            animator.SetBool("Follow", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
