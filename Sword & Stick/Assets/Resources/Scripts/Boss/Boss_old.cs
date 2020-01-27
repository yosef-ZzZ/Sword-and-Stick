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
    public int damagetoplayer = 1;

    private float dazedTime;
    public float startDazedTime;

    private float TimeBtwAttack;
    public float StartTimeBtwAttack;
    bool movingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DeathDisableCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position, target.position)<howfar)
            if (Vector2.Distance(transform.position, target.position)>distanceclose)
             {
                animator.SetInteger("state",1);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, target.position) <= distanceclose)
                {
                    //attack goes here
                    animator.SetInteger("state", 2);


                }
                else
                    animator.SetInteger("state", 0);

            }
            else
                animator.SetInteger("state",0);
        else
            animator.SetInteger("state",0);


        if (EnemyHealth <= 0)
        {
            DeathDisableCollider.enabled = false;
            animator.SetTrigger("Dead");
        }

       /* RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = true;
            }//else
        }//if
        */


       
    }

    // This function gets called every time the enemy gets hit
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        EnemyHealth -= damage;
        Debug.Log("damage Taken, health " + EnemyHealth);
    }
}
