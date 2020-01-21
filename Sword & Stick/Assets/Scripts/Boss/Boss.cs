using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Animator animator;
    public float speed;
    private Transform target;
    public int EnemyHealth;
    public int distanceclose;       //how close the boss can get to the player before it stops moving
    public int howfar;                  //how far the boss is away from the player before it starts moving
    public Collider2D DeathDisableCollider;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position, target.position)<howfar)
            if (Vector2.Distance(transform.position, target.position)>distanceclose)
             {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                animator.SetTrigger("walk");
            }
    }
}
