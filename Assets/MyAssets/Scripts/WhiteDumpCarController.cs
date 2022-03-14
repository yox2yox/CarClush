using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDumpCarController : MonoBehaviour
{

    public Rigidbody rb;
    public float LiveTime = 6.0f;
    public GameObject Oil;
    private float spawnTime;

    // Use this for initialization
    void Start()
    {
        this.spawnTime = Time.realtimeSinceStartup;
        this.rb.AddRelativeForce(new Vector3(0, 0, 300), ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - this.spawnTime > LiveTime)
        {
            if (rb.velocity.x < 0.1f && rb.velocity.y < 0.1f)
            {
                GameObject.Instantiate(Oil, new Vector3(transform.position.x, Oil.transform.position.y, transform.position.z), transform.rotation);
            }
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Instantiate(Oil, new Vector3(transform.position.x, Oil.transform.position.y, transform.position.z), transform.rotation);
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 100, -100, ForceMode.Impulse);
        }
    }

}