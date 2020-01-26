using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject Boss;
 

void Start()
{
    

void OnTriggerEnter2D(Collider2D other)
{
Debug.Log("Spawn Boss");
Instantiate(Boss, spawnPoint.position, spawnPoint.rotation);
}
}


}
