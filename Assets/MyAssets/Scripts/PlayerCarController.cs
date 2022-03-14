using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarController : MonoBehaviour {

    public Rigidbody rb;
    public Text SpeedText;
    public enum Direction {
        z_p,
        z_m,
        x_p,
        x_m
    }
    public Direction MyDir = Direction.z_m;
    public GameObject VCam;
    public VehicleSponer Sponer;
    public AudioSource SpinAudio;
    public int Speed {
        get {
            if (this.MyDir == Direction.z_m)
            {
                return Mathf.FloorToInt(this.rb.velocity.z * -1);
            }
            else if (this.MyDir == Direction.z_p)
            {
                return Mathf.FloorToInt(this.rb.velocity.z);
            }
            else if (this.MyDir == Direction.x_m)
            {
                return Mathf.FloorToInt(-this.rb.velocity.x);
            }
            else
            {
                return Mathf.FloorToInt(this.rb.velocity.x);
            }
        }
    }

    private bool isSpin = false;
    private float spinEndTime = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (MyDir == Direction.z_m && transform.position.z < -1850)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            VCam.transform.Rotate(new Vector3(0, 90, 0));
            MyDir = Direction.x_m;
            Debug.Log(this.rb.velocity.z);
            this.rb.velocity = new Vector3(this.rb.velocity.z*0.5f, 0, 0);
        }
        else if (MyDir == Direction.x_m && transform.position.x < -194)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            VCam.transform.Rotate(new Vector3(0, 90, 0));
            MyDir = Direction.z_p;
            Debug.Log(this.rb.velocity.x);
            this.rb.velocity = new Vector3(0, 0, this.rb.velocity.x * -0.5f);
        }
        else if (MyDir == Direction.z_p && transform.position.z > 148) {
            transform.Rotate(new Vector3(0, 90, 0));
            VCam.transform.Rotate(new Vector3(0, 90, 0));
            MyDir = Direction.x_p;
            this.rb.velocity = new Vector3(this.rb.velocity.z*0.5f,0,0);
        }
        else if (MyDir == Direction.x_p && transform.position.x > -16)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            VCam.transform.Rotate(new Vector3(0, 90, 0));
            MyDir = Direction.z_m;
            this.rb.velocity = new Vector3(0, 0, this.rb.velocity.x * -0.5f);
            Sponer.GameProgress++;
        }


        if (Input.GetButtonDown("Jump")) {
            this.rb.AddRelativeForce(new Vector3(0,10, 0), ForceMode.Impulse);
        }

        if (isSpin) {
            if (Time.realtimeSinceStartup > spinEndTime) {
                isSpin = false;
                if (this.MyDir == Direction.z_m)
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                else if (this.MyDir == Direction.x_m)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (this.MyDir == Direction.z_p)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
            else
                transform.Rotate(new Vector3(0,Time.deltaTime*360,0));
        }
        else if (Input.GetKey("left"))
        {
            if (Input.GetKeyDown("left"))
            {
                transform.Rotate(new Vector3(0, 45, 0));
            }
            if (this.MyDir == Direction.z_m && this.rb.velocity.x < 30)
            {
                this.rb.AddForce(new Vector3(30 * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.x_m && this.rb.velocity.z > -30)
            {
                this.rb.AddForce(new Vector3(0,0,-30 * Time.deltaTime), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.z_p && this.rb.velocity.x > -30)
            {
                this.rb.AddForce(new Vector3(-30 * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.x_p && this.rb.velocity.z < 30)
            {
                this.rb.AddForce(new Vector3(0,0,30 * Time.deltaTime), ForceMode.Impulse);
            }
        }
        else if (Input.GetKey("right"))
        {
            if (Input.GetKeyDown("right"))
            {
                transform.Rotate(new Vector3(0, -45, 0));
            }
            if (this.MyDir == Direction.z_m && this.rb.velocity.x > -30)
            {
                this.rb.AddForce(new Vector3(-30 * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.x_m && this.rb.velocity.z < 30)
            {
                this.rb.AddForce(new Vector3(0, 0, 30 * Time.deltaTime), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.z_p && this.rb.velocity.x < 30)
            {
                this.rb.AddForce(new Vector3(30 * Time.deltaTime, 0, 0), ForceMode.Impulse);
            }
            if (this.MyDir == Direction.x_p && this.rb.velocity.z > -30)
            {
                this.rb.AddForce(new Vector3(0, 0, -30 * Time.deltaTime), ForceMode.Impulse);
            }
        }
        else if (Input.GetKey("down"))
        {
            if (this.rb.velocity.z < -0.1)
            {
                this.rb.AddRelativeForce(new Vector3(0, 0, -Time.deltaTime * 200), ForceMode.Force);
            }
        }
        else
        {
            if (Input.GetKeyUp("left") || Input.GetKeyUp("right")) {
                if (this.MyDir == Direction.z_m)
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                    this.rb.velocity = new Vector3(0, 0, this.rb.velocity.z);
                }
                else if (this.MyDir == Direction.x_m)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    this.rb.velocity = new Vector3(this.rb.velocity.x, 0, 0);
                }
                else if (this.MyDir == Direction.z_p)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    this.rb.velocity = new Vector3(0, 0, this.rb.velocity.z);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    this.rb.velocity = new Vector3(this.rb.velocity.x, 0, 0);
                }
            }
            if (this.MyDir==Direction.z_m && this.rb.velocity.z > -2 ||
                this.MyDir==Direction.x_m && this.rb.velocity.x > -2 ||
                this.MyDir==Direction.z_p && this.rb.velocity.z < 2) {
                this.rb.AddRelativeForce(new Vector3(0, 0, 3), ForceMode.Impulse);
            }
            else
                this.rb.AddRelativeForce(new Vector3(0, 0, Time.deltaTime*200), ForceMode.Force);
        }

        if (this.MyDir == Direction.z_m)
        {
            this.SpeedText.text = "時速" + Mathf.FloorToInt(this.rb.velocity.z * -1) + "km";
        }
        else if (this.MyDir == Direction.z_p)
        {
            this.SpeedText.text = "時速" + Mathf.FloorToInt(this.rb.velocity.z) + "km";
        }
        else if (this.MyDir == Direction.x_m)
        {
            this.SpeedText.text = "時速" + Mathf.FloorToInt(-this.rb.velocity.x) + "km";
        }
        else if (this.MyDir == Direction.x_p) {
            this.SpeedText.text = "時速" + Mathf.FloorToInt(this.rb.velocity.x) + "km";
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Spinner") {
            if (col.gameObject.name.Contains("Oil")) {
                SpinAudio.Play();
                this.isSpin = true;
                this.spinEndTime = Time.realtimeSinceStartup + 3f;
            }
        }
    }

}
