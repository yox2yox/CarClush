using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUIManager : MonoBehaviour {

    public ItemUIManager ItemUIManager;
    public List<GameObject> EquipPanels;
    public List<int> EquipedIds;
    private List<GameObject> _generatedIcons;
    private List<GameObject> GeneratedIcons
    {
        get
        {
            if (_generatedIcons == null)
            {
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

    public void SetEquip(int id) {
        if (EquipedIds.Count < EquipPanels.Count) {
            if (id >= ItemUIManager.ItemIcons.Count) {
                Debug.LogError("[ERROR]:SetEquip not exist id");
                return;
            }
            EquipPanels[EquipedIds.Count].SetActive(true);
            GeneratedIcons.Add(GameObject.Instantiate(ItemUIManager.ItemIcons[id], EquipPanels[EquipedIds.Count].transform));
            EquipedIds.Add(id);
        }
    }

    public void RemoveEquip(int id)
    {
        var index = EquipedIds.IndexOf(id);
        if (index < 0) {
            Debug.LogError("[Error]:Remove target does not exsist");
            return;
        }
        for (int i = GeneratedIcons.Count - 1; i >= index; i--) {
            GameObject.Destroy(GeneratedIcons[i]);
            GeneratedIcons.RemoveAt(i);
        }
        EquipedIds.RemoveAt(index);
        for (int i = index; i < EquipedIds.Count; i++) {
            GeneratedIcons.Add(GameObject.Instantiate(ItemUIManager.ItemIcons[EquipedIds[i]], EquipPanels[i].transform));
        }
    }

}
