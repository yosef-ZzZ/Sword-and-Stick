using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehaviour : StateMachineBehaviour
{
    private int rand;
    public GameObject SlimeBoss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            animator.SetTrigger("jump");
        }
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 S = SlimeBoss.GetComponent<SpriteRenderer>().sprite.bounds.size;
        SlimeBoss.GetComponent<BoxCollider2D>().size = S;
        SlimeBoss.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
        SlimeBoss.GetComponent<BoxCollider2D>().offset = new Vector2 ((1/2), 0);
    }

 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
