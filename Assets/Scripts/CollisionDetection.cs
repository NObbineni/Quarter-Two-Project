using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public Transform ground;

	// Update is called once per frame
	void FixedUpdate () {
        Physics.IgnoreCollision(ground.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
