using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // Get player controller  

    public Animator animator;                // Get player animator
   
    public float runSpeed = 40f;      

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding () {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate(){
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, /*crouch,*/ jump);
        jump = false;
    }
}
