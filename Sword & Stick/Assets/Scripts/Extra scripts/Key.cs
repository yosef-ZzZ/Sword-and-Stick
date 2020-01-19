using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public virtual void OnTriggerEnter2D (Collider2D collider){
        // Checks if the player touched the key
        if (collider.CompareTag("Player")) {
            // Sets the player has the key value to true
            collider.GetComponent<Keymanager>().hasKey = true;
            // Makes key not visible
            gameObject.SetActive (false);
        }
       
    }
}
