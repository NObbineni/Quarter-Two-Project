using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle")
        {
            //movement.enabled = false;
           // Debug.Log("Collided");
            FindObjectOfType<GameManager>().EndGame();
        }
        if(collision.collider.tag == "ground")
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

}
