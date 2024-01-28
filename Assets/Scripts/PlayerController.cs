using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager gameManager;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        FallDetector();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barier"))
        {
            gameManager.RespawnPlayer();


        }
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        }
    }
    private void FallDetector()
    {
        if (rb.position.y < -2) { 
            gameManager.RespawnPlayer();
        }
    }

}
