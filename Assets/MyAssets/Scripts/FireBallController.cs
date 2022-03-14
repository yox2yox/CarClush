using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        this.rb.AddRelativeForce(transform.forward * 300, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
