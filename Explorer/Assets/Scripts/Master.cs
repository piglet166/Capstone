using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    GameObject[] respawns;
    SavePoint[] savePoints;
    public GameObject respawnPrefab;
    public Health player;
    
    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        savePoints = new SavePoint[respawns.Length];

        for (int i = 0; i < respawns.Length; i++) {
            savePoints[i] = respawns[i].GetComponent<SavePoint>();
            savePoints[i].serialNumber = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MasterRecieve(int sr) {

        foreach (SavePoint sp in savePoints) {
            sp.DeactivateCheckPoint();
        }

        savePoints[sr].ActivateCheckPoint();
    }

    public void MasterRespawn() {
        SavePoint dest = null;

        foreach(SavePoint sp in savePoints) {
            if (sp.isActive()) dest = sp;
        }

        if (dest != null) Instantiate(respawnPrefab, dest.transform.position, dest.transform.rotation);

    }
}
