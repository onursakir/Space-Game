using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ParticleSystem playerDeathAnim;
    AudioSource playerDeathSound;

    void Start() 
    {
        playerDeathAnim = GameObject.Find("PlayerDeathAnimation").GetComponent<ParticleSystem>();
        playerDeathSound = GetComponent<AudioSource>();        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDeathAnim.gameObject.transform.position = other.gameObject.transform.position;
            playerDeathAnim.Play();

            playerDeathSound.PlayOneShot(playerDeathSound.clip);
            other.gameObject.SetActive(false);  
            MenuManager.instance.isGameOn = false;
            
            Time.timeScale = 0;
            MenuManager.instance.GameOver();                       
        } 
    }

    private void OnEnable() 
    {
        StartCoroutine("DisableEnemy");
    }

    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
