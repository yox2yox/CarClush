using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEquip : MonoBehaviour {

    public int MyId = 0;
    public int ShieldNum=0;
    public EquipUIManager EquipUIManager;
    public Collider col;
    public MeshRenderer renderer;
    public AudioSource BreakAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShield() {
        this.renderer.enabled = true;
        ShieldNum++;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (ShieldNum > 0)
        {
            Debug.Log("Collision Shield " + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<Rigidbody>().AddForce(0, 100, -100, ForceMode.Impulse);
                collision.gameObject.tag = "BrokenEnemy";
                EquipUIManager.RemoveEquip(MyId);
                BreakAudio.Play();
                ShieldNum--;
                if (ShieldNum <= 0)
                {
                    this.renderer.enabled = false;
                }
            }
        }
    }

}
