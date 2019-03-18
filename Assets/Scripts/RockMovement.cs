using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour {

    public Transform player;
    public Rigidbody rb;
    bool thrown = false;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
       // gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //gameObject.SetActive(false);
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrown");
           // gameObject.SetActive(true);
            thrown = true;
        }
        if (thrown)
        {
            transform.position = player.position + offset;
            rb.AddForce(50000 * Time.deltaTime, 0, 0);
            StartCoroutine(Wait());
            thrown = false;
        }
    }

    IEnumerator Wait()
    {
       // thrown = false;
        yield return new WaitForSeconds(5);
        //thrown = true;
    }

}
