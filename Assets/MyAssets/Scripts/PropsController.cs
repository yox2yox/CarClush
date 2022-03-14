using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsController : MonoBehaviour {

    public Rigidbody rb;
    private Vector3 position;
    private Quaternion rotation;
    private float liveTime = 5;
    private float deleteTime;
    private bool startDelete = false;

	// Use this for initialization
	void Start () {
        this.position = transform.position;
        this.rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (startDelete && Time.realtimeSinceStartup > deleteTime) {
            startDelete = false;
            transform.position = this.position;
            transform.rotation = this.rotation;
            gameObject.tag = "Props";
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 0.1f) {
            startDelete=true;
            deleteTime = Time.realtimeSinceStartup + liveTime;
        }
    }

}
