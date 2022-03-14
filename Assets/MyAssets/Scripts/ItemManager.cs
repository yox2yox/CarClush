using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public List<string> ItemsId;
    public List<int> OwnItems;
    public ItemUIManager ItemUIManager;
    public EquipUIManager EquipUIManager;
    public StatusManager StatusManager;
    public PlayerCarController PlayerCarController;
    public AudioSource GetItemAudio;
    public AudioSource EquipAudio;
    public AudioSource HealAudio;
    public AudioSource SpeedUpAudio;


    /* Equips */
    public ShieldEquip ShieldEquip;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            var id = ItemsId.IndexOf(other.gameObject.name);
            if (id >= 0)
            {
                GetItemAudio.Play();
                GameObject.Destroy(other.gameObject);
                ItemUIManager.SetNewItem(id);
            }
        }
    }

    public void ExecuteItem(int id) {
        switch (id) {
            case 0:
                EquipUIManager.SetEquip(0);
                ShieldEquip.gameObject.SetActive(true);
                ShieldEquip.SetShield();
                EquipAudio.Play();
                break;
            case 1:
                StatusManager.ChangeAngerGage(-5);
                HealAudio.Play();
                break;
            case 2:
                PlayerCarController.rb.AddRelativeForce(new Vector3(0, 0, 1000), ForceMode.Force);
                SpeedUpAudio.Play();
                break;
            case 3:
                StatusManager.ChangeAngerGage(-3);
                HealAudio.Play();
                break;
            default:
                break;
        }
    }

}
