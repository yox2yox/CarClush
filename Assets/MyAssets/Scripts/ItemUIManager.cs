using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour {

    public ItemManager ItemManager;
    public List<GameObject> ItemIcons;
    public List<int> ItemsId;
    public List<GameObject> ItemPanels;
    private List<GameObject> _generatedIcons;
    private List<GameObject> GeneratedIcons {
        get {
            if (_generatedIcons == null) {
                _generatedIcons = new List<GameObject>();
            }
            return _generatedIcons;
        }
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNewItem(int id) {
        if (ItemPanels.Count > ItemsId.Count) {
            if (id > ItemIcons.Count-1) {
                Debug.LogError("[ERROR]: Failed SetNewItem. Id is invalid.");
                return;
            }
            ItemPanels[ItemsId.Count].SetActive(true);
            GeneratedIcons.Add(GameObject.Instantiate(ItemIcons[id], ItemPanels[ItemsId.Count].transform));
            var index = ItemsId.Count;
            ItemPanels[ItemsId.Count].GetComponent<Button>().onClick.AddListener(()=> {
                ItemManager.ExecuteItem(id);
                RemoveItem(index);
                Debug.Log("onClick with Item Panel is executed");
            });
            ItemsId.Add(id);
        }
     
    }

    public void RemoveItem(int index) {
        for (int i = GeneratedIcons.Count-1; i>=index ; i--) {
            GameObject.Destroy(GeneratedIcons[i]);
            GeneratedIcons.RemoveAt(i);
            ItemPanels[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
        ItemPanels[ItemsId.Count - 1].SetActive(false);
        ItemsId.RemoveAt(index);
        for (int i = index; i < ItemsId.Count; i++) {
            GeneratedIcons.Add(GameObject.Instantiate(ItemIcons[ItemsId[i]], ItemPanels[i].transform));
            var itemid = ItemsId[i];
            var targetindex = i;
            ItemPanels[i].GetComponent<Button>().onClick.AddListener(() => {
                ItemManager.ExecuteItem(itemid);
                RemoveItem(targetindex);
                Debug.Log("onClick with Item Panel is executed");
            });
        }
    }

}
