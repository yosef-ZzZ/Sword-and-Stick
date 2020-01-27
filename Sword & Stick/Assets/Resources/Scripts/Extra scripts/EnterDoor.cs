using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{ 
    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) {
            if (collider.GetComponent<Keymanager>().hasKey == true)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Add a message telling the player he needs a key to enter
 
    }
}
