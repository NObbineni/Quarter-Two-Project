using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float speed = 1000;
    public float sideways = 50000000;
    public bool down = true;
    public Transform ground;
    public bool grounded = true;
    private int score = 0;
    public Text countText;
    // public GameObject rock;
    //private float num = 0;
    //private float multiply = 0;

    private void Start()
    {
        transform.position = new Vector3((float)-72,(float)1.5,0);
       // num = transform.position.x;
        countText.text = transform.position.x+"";
    }

    // Update is called once per frame
    void FixedUpdate () {
         rb.AddForce(speed * Time.deltaTime, 0, 0);
        float loc = transform.position.x;
        Debug.Log("LOC " + loc);
        if (score != 0)
        {
            loc = loc * score;
        }
        countText.text = "" + (int)loc;
        // rock.SetActive(false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(0, 0, -sideways * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(0, 0, sideways * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && grounded == true)
        {
            Debug.Log("jump");
            rb.AddForce(0, 2000 * Time.deltaTime, 0);
            Invoke("GoDown", .1f);
           // grounded = false;
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("money"))
        {
            other.gameObject.SetActive(false);
            score++;
            Debug.Log(score + " ");
           // num *= score;
        }
    }

    IEnumerator Wait()
    {
     //   down = false;
        yield return new WaitForSeconds(5);
       // down = true;
    }

    private void GoDown()
    {
        rb.AddForce(0, 0, 0);
       // Physics.IgnoreCollision(ground.GetComponent<Collider>(), GetComponent<Collider>());
    }

}
