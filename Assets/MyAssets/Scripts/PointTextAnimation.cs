using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTextAnimation : MonoBehaviour {

    public float DestinationY;
    public float StartPositionY;
    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y < DestinationY)
        {
            transform.localPosition += new Vector3(0, Speed * Time.deltaTime, 0);
        }
        else {
            transform.localPosition = new Vector3(transform.localPosition.x, StartPositionY, transform.localPosition.z);
            gameObject.SetActive(false);
        }
	}
}
