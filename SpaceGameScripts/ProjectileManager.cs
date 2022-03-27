using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    
    Rigidbody projectileRb;

    [SerializeField] GameObject player;

    Vector3 farFromPlayer = new Vector3(0,3,0);    
    float waitTimeBeforeShoot = 1f;    

    void Update()
    {   
        if (MenuManager.instance.isGameOn)
        {   
            waitTimeBeforeShoot -= Time.deltaTime; 
            Shot();
        }    
    }

    void Shot()
    {        
        if (Input.GetKey(KeyCode.Space) && waitTimeBeforeShoot <0)
        {            
            transform.position = player.transform.position + farFromPlayer;
            GameObject obj = ObjectPooler.instance.GetPooledObject("Projectile"); 
            obj.SetActive(true);           
            obj.transform.position = transform.position;
            if (player.GetComponent<PlayerScript>().isPowerUp)
            {
                waitTimeBeforeShoot = 0.2f;
            }else
            {
                waitTimeBeforeShoot = 0.8f;   
            }                       
                                
        }         
    }
}
