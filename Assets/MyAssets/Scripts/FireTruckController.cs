using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruckController : MonoBehaviour
{

    public Rigidbody rb;
    public float LiveTime = 6.0f;
    private float spawnTime;
    public GameObject Fireball;
    private float firebalCount;

    // Use this for initialization
    void Start()
    {
        this.spawnTime = Time.realtimeSinceStartup;
        this.rb.AddRelativeForce(new Vector3(0, 0, -150), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        /*rb.velocity = Vector3.zero;
        if (this.rb.velocity.z < 50)
        {
            this.rb.AddRelativeForce(new Vector3(0, 0, 20*Time.deltaTime), ForceMode.Impulse);
        }*/
        if (Time.realtimeSinceStartup - this.spawnTime > LiveTime)
        {
            GameObject.Destroy(gameObject);
        }
        firebalCount += Time.deltaTime;
        if (firebalCount > 1.0f)
        {
            GameObject.Instantiate(Fireball, transform.position + transform.forward * 10, transform.rotation);
            firebalCount = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 100, -100, ForceMode.Impulse);
        }
    }

}
