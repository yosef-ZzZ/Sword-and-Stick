using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondBossHealth : MonoBehaviour
{
    public int BossHealth;     // Bosses health counter
    public GameObject effect;
    public Slider healthBar;
    public Animator animator;   // Get Boss animator
    private GameObject spawnPoint;
    private GameObject doorpre;
    
    
    private void Start() {
        spawnPoint = GameObject.FindGameObjectWithTag("DoorSpawn");
        var Door = (GameObject)Resources.Load("Prefabs/Items/Door", typeof(GameObject));
        doorpre = Door;
    }

    private void Update() {
        if (BossHealth <= 0){
            animator.SetTrigger("Dead");
        }
        healthBar.value = BossHealth;
    }

    // This function gets called every time the enemy gets hit
   public void TakeDamage(int damage){
       Instantiate(effect, transform.position, Quaternion.identity);
       SoundManagerS.PlaySound("EnemyDamage");
       BossHealth -= damage;
       Debug.Log("damage Taken, health " + BossHealth);
   }

   void DestroyEnemy(){
       Instantiate(doorpre, spawnPoint.transform.position, Quaternion.identity);
       Destroy(gameObject);
   }
}
