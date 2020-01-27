using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    private bool bossAlreadySpawned = false;

    void OnTriggerEnter2D(Collider2D other){
        if (!bossAlreadySpawned){
            Debug.Log("Spawn Boss");
            Instantiate(Boss, transform.position, Quaternion.identity);
            bossAlreadySpawned = true;
        }
    }
}