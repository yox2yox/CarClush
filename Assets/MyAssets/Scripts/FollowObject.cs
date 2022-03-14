using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowObject : MonoBehaviour {

    public GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Target.transform.position;
	}
}
