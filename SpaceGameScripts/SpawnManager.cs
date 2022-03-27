using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    GameObject objectToSpawn;
    float spawnPosX = 11f;
    float spawnPosY = 18f;
    public float speedMultiplier {get; private set;} = 1;

    string redEnemy = "RedEnemy";
    string blueEnemy = "BlueEnemy";

    [SerializeField] float spawnRate;
    [SerializeField] string methodName;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(methodName,1f,spawnRate);
    }

    void Update() 
    {        
        if (speedMultiplier <3)
        {
            speedMultiplier += Time.deltaTime * 0.02f;
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0,2);
        string randomTag = blueEnemy;

        if (random == 0)
        {
            randomTag = redEnemy;
        }else if (random == 1)
        {
            randomTag = blueEnemy;
        }
        
        GameObject enemy = ObjectPooler.instance.GetPooledObject(randomTag);
        enemy.transform.position = new Vector3(Random.Range(-spawnPosX,spawnPosX), spawnPosY,-1);
        enemy.gameObject.SetActive(true);
    }

     void SpawnPower()
    {
        GameObject enemy = ObjectPooler.instance.GetPooledObject("Power");
        enemy.transform.position = new Vector3(Random.Range(-spawnPosX,spawnPosX), spawnPosY,-1);
        enemy.gameObject.SetActive(true);
    }
}
