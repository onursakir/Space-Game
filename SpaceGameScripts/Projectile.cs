using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
      
    Rigidbody projectileRb;
    ParticleSystem destroyParticle;    


    float bulletSpeed = 80f;
    [SerializeField] int pointForEachSuccessHit = 10;

    void Start()
    {
        destroyParticle = GameObject.Find("DestroyedAnimation").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other) 
    {
         if (other.gameObject.CompareTag("Enemy"))
        {          
            destroyParticle.gameObject.transform.position = other.gameObject.transform.position;
            destroyParticle.Play();   
            AudioClipHolder.instance.DestoyedAudio();
            MenuManager.instance.AddPoint(pointForEachSuccessHit);

            other.gameObject.SetActive(false);
            gameObject.SetActive(false);            
        }    
    }
    private void OnEnable() 
    {
        transform.position = GetComponentInParent<Transform>().position;
        projectileRb = GetComponent<Rigidbody>(); 
        projectileRb.velocity = Vector3.up * bulletSpeed;
        AudioClipHolder.instance.LaserAudio();
       
        StartCoroutine("Disable");                
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
