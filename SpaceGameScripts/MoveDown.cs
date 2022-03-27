using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    float speed = 14;
    float multiplier;

    void Update() 
    { 
        multiplier = GameObject.Find("EnemySpawnManager").GetComponent<SpawnManager>().speedMultiplier;
        transform.Translate(Vector3.down * Time.deltaTime * speed * multiplier);            
    }
}
