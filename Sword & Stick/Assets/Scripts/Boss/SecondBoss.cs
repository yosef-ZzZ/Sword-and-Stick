using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : MonoBehaviour
{
     public int BossHealth;     // Bosses health counter
     //public GameObject effect;  // Particle effect

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function gets called every time the enemy gets hit
   public void TakeDamage(int damage){
       //Instantiate(effect, transform.position, Quaternion.identity);
       BossHealth -= damage;
       Debug.Log("damage Taken, health " + BossHealth);
   }
}
