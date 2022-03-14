using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSponer : MonoBehaviour {

    public GameObject SponeObject;
    public GameObject SponeObjectParent;
    public List<GameObject> SponeObjects;
    public float MinSponeInterval = 5f;
    public float MaxSponeInterval = 15f;
    public float LastSponeTime = 0;
    public float DistanceFromPlayer = 100;
    public PlayerCarController PlayerObject;
    public float NextSponeInterval;
    public int GameProgress = 0;
    public List<int> TargetLength;
    public List<Transform> SponePointZM;
    public List<Transform> SponePointZP;

	// Use this for initialization
	void Start () {
        NextSponeInterval = Random.Range(MinSponeInterval, MaxSponeInterval);
        SponeObjects = new List<GameObject>();
        foreach (Transform child in SponeObjectParent.transform) {
            SponeObjects.Add(child.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.realtimeSinceStartup - LastSponeTime > NextSponeInterval) {
            if (GameProgress >= TargetLength.Count) {
                GameProgress = TargetLength.Count - 1;
            }
            if (PlayerObject.MyDir == PlayerCarController.Direction.z_m)
            {
                Transform tran = SponePointZM[Random.Range(0, SponePointZM.Count)];
                var position = new Vector3(tran.position.x, tran.position.y, PlayerObject.transform.position.z - DistanceFromPlayer);
                var q = Quaternion.Euler(0, 0, 0);
                var targetObj = GetRandomObject(TargetLength[GameProgress]);
                var target = GameObject.Instantiate(targetObj,position,q);
                target.name = targetObj.name;
                target.SetActive(true);
            }
            if (PlayerObject.MyDir == PlayerCarController.Direction.z_p) {
                Transform tran = SponePointZP[Random.Range(0, SponePointZP.Count)];
                var position = new Vector3(tran.position.x, tran.position.y, PlayerObject.transform.position.z + DistanceFromPlayer);
                var q = Quaternion.Euler(0, 180, 0);
                var targetObj = GetRandomObject(TargetLength[GameProgress]);
                var target = GameObject.Instantiate(targetObj, position, q);
                target.name = targetObj.name;
                target.SetActive(true);
            }
            LastSponeTime = Time.realtimeSinceStartup;
            NextSponeInterval = Random.Range(MinSponeInterval, MaxSponeInterval);
        }
	}

    private GameObject GetRandomObject(int targetLength) {

        var index = Random.Range(0,targetLength);
        return SponeObjects[index];
    }
}
