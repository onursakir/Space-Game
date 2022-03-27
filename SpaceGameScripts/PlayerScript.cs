using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody playerRb;

    float playerMovementPower = 2f;
    float playerTorque = 500000;
    float limitX = 12;
    float limitY = 13;
    
    Vector3 limitVectorHorizontal = new Vector3(0.5f,0,0);    
    Vector3 limitVectorVectoral = new Vector3(0,0.5f,0);

    private float horizontalInput;
    private float verticalInput;
    float delaySpeedChange = 2f;
    float maxSpeed = 10f;
    public bool isPowerUp = false;
        
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();      
    }
    
    void FixedUpdate()
    {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            PlayerMovementPatern();          

        if(playerRb.velocity.magnitude > maxSpeed)  // Max speed control
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
    }    

    void PlayerMovementPatern()
    {
        // Horizontal part
        if (transform.position.x >= -limitX && transform.position.x <= limitX)
        {    
            playerRb.AddForce(Vector3.right * horizontalInput * playerMovementPower, ForceMode.VelocityChange);
            playerRb.AddTorque(Vector3.forward * horizontalInput * playerTorque);


        }else if (transform.position.x <-limitX)
        {
            playerRb.velocity = Vector3.Lerp(playerRb.velocity,limitVectorHorizontal,delaySpeedChange);
            
        }
        else if (transform.position.x > limitX)
        {
            playerRb.velocity = Vector3.Lerp(playerRb.velocity,-limitVectorHorizontal,delaySpeedChange);
        }

        // Vectoral part
        if (transform.position.y < limitY && transform.position.y >-limitY)
        {
            playerRb.AddForce(Vector3.up * verticalInput * playerMovementPower, ForceMode.VelocityChange ); 
        }else if (transform.position.y >=limitY)
        {         
            playerRb.velocity = Vector3.Lerp(playerRb.velocity,-limitVectorVectoral,delaySpeedChange);
           
        }else if (transform.position.y <=-limitY)
        {
            playerRb.velocity = Vector3.Lerp(playerRb.velocity,limitVectorVectoral,delaySpeedChange);
        }
    }    
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Power"))
        {
            StartCoroutine("PowerUpRoutine");
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator PowerUpRoutine()
    {
        isPowerUp = true;
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        transform.GetChild(2).gameObject.SetActive(false);
        isPowerUp = false;
    }
}

