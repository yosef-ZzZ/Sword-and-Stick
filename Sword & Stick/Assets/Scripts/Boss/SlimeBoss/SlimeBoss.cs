using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBoss : MonoBehaviour {

    public Patrol EnemyController;
    public Animator animator;                // Get Skeleton animator
    public Collider2D DeathDisableCollider;
    public GameObject effect;
    public Transform player;
    public Transform spawnPoint;
    public GameObject Door;
    public float jumpTowards = 1;
    public int damagetoplayer = 1;
    private bool isDying = false;
    private float dazedTime;
    public float startDazedTime;
    private float TimeBtwAttack;
    public float StartTimeBtwAttack;
    private bool facingRight= true;
    private bool activated = false;

    private void Start()
    {
        DeathDisableCollider.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        
    if((player.position.x > transform.position.x) && !facingRight)
    {
     //face right
     facingRight = true;
     }else if((player.position.x < transform.position.x) && facingRight)
     {
     //face left
     facingRight = false;
     }

        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("jump"))
        {
             if(animator.GetCurrentAnimatorStateInfo(0).IsTag("jump")&& activated == false)
              {
                   Debug.Log("Jumping");
                 Invoke("Jump", 1f);
               }
                activated = true;
                
            }
            else
            {
                activated = false;
            }
         
    if(animator.GetCurrentAnimatorStateInfo(0).IsTag("death"))
    {
        DeathDisableCollider.enabled= false;
        Invoke("Death", 5f);
    }
        
    }

     // This fucntion checks what the enemy collided with and deals damage if it is the player
   void OnTriggerEnter2D(Collider2D damageCollider) {
       if (TimeBtwAttack <= 0){
            // This checks if the collider touched a player
            if (damageCollider.CompareTag("Player")) {
            // Player takes damage
            damageCollider.GetComponent<PlayerHealth>().health -= damagetoplayer;

            Debug.Log(damageCollider.GetComponent<PlayerHealth>().health);
            }
       } else{
            TimeBtwAttack -= Time.deltaTime;
       }

       damageCollider.GetComponent<PlayerHealth>().BounceBack = true;
       Debug.Log(damageCollider.GetComponent<PlayerHealth>().BounceBack);
   }


    void Jump()
    {
        if(!facingRight && jumpTowards > 0 || facingRight && jumpTowards < 0)
        {
            jumpTowards *= -1;
        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpTowards, 11f), ForceMode2D.Impulse);
        
    }

    void Death()
    {
        Instantiate(Door, spawnPoint.position, spawnPoint.rotation);
        Destroy(gameObject);
    }
}