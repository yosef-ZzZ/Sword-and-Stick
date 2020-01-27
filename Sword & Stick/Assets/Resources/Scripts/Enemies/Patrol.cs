using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
  private float assigned_speed;         // Saves the speed that was set to the enemy
  public float speed;
  public float distance;

  private bool movingLeft = false;

  public Transform groundDetection;

  public Animator animator;                // Get Skeleton animator

  void Start() {
      assigned_speed = speed;
  }//start

  void Update(){
      transform.Translate(Vector2.right * speed * Time.deltaTime);
      animator.SetFloat("Speed", Mathf.Abs(speed));

      RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
      if(groundInfo.collider == false) {
          if (movingLeft == true){
              transform.eulerAngles = new Vector3(0, 0, 0);
              movingLeft = false;
          } else {
              transform.eulerAngles = new Vector3(0, 180, 0);
              movingLeft = true;
          }//else
      }//if
  }//update

  // Returns the assigned speed
  public float sendAssignedSpeed(){
      return assigned_speed;
  }//sendAssignedSpeed
}