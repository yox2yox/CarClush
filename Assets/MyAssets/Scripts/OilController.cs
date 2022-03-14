using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour {

    public GameObject ParentObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            GameObject.Destroy(ParentObj,1f);
        }
    }
}
