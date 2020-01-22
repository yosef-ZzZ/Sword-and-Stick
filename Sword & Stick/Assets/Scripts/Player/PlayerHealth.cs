using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    private int maxhealth = 10;
    public float speed = 3;
    public float forhowlong = 0.5f;
    public bool BounceBack = false;

    public Image HealthValue;
    public Sprite health10;
    public Sprite health9;
    public Sprite health8;
    public Sprite health7;
    public Sprite health6;
    public Sprite health5;
    public Sprite health4;
    public Sprite health3;
    public Sprite health2;
    public Sprite health1;
    public Sprite health0;

    // Update is called once per frame
    private void Update() {

        for (int i = 0; i < maxhealth; i++)
            if (i == health)
            {
                if (health == 10)
                    HealthValue.sprite = health10;
                if (health == 9)
                    HealthValue.sprite = health9;
                if (health == 8)
                    HealthValue.sprite = health8;
                if (health == 7)
                    HealthValue.sprite = health7;
                if (health == 6)
                    HealthValue.sprite = health6;
                if (health == 5)
                    HealthValue.sprite = health5;
                if (health == 4)
                    HealthValue.sprite = health4;
                if (health == 3)
                    HealthValue.sprite = health3;
                if (health == 2)
                    HealthValue.sprite = health2;
                if (health == 1)
                    HealthValue.sprite = health1;
                if (health == 0)
                    HealthValue.sprite = health0;
            }//IF

        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Push player back if bounce back is true
        if (BounceBack) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            StartCoroutine(SetBounceBack());
        }
    }

    IEnumerator SetBounceBack() {
       // Set bounce back to false after the specifed seconds 
       yield return new WaitForSeconds(forhowlong);
       BounceBack = false;
    }
    
}
