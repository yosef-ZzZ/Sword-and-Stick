using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public float speed = 3;
    public float forhowlong = 0.5f;
    public bool BounceBack = false;

    // Update is called once per frame
    private void Update() {
        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Push player back if bounce back is true
        if (BounceBack) {
            if (transform.localScale.x == -8)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            StartCoroutine(SetBounceBack());
        }
    }

    IEnumerator SetBounceBack() {
       // Set bounce back to false after the specifed seconds 
       yield return new WaitForSeconds(forhowlong);
       BounceBack = false;
    }
    
}
