using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour {


    private float timer;
    public float minTime;
    public float maxTime;
    public GameObject SlimeBoss;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = Random.Range(minTime, maxTime);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Vector2 S = SlimeBoss.GetComponent<SpriteRenderer>().sprite.bounds.size;
        SlimeBoss.GetComponent<BoxCollider2D>().size = S;
        SlimeBoss.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
        SlimeBoss.GetComponent<BoxCollider2D>().offset = new Vector2 ((1/2), 0);

        if (timer <= 0)
        {
            animator.SetTrigger("jump");
        }
        else {
            timer -= Time.deltaTime;
        }
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}