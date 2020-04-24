using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public int serialNumber;
    public GameObject spawnPoint;
    public Master master;
    public Animator anim;
    public float cpRadius;
    public LayerMask playerLayer;

    [SerializeField] bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        DeactivateCheckPoint();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
    }

    public void ActivateCheckPoint() {
        anim.SetBool("Active", true);
        active = true;
    }

    public void DeactivateCheckPoint() {
        anim.SetBool("Active", false);
        active = false;
    }

    bool CheckPlayer() {

        bool playerDetected = Physics2D.OverlapCircle(transform.position, cpRadius, playerLayer);

        MasterReport();

        return playerDetected;
    }

    void MasterReport() {
        master.MasterRecieve(serialNumber);
    }

    public Transform GetSpawnLocation() {
        return spawnPoint.transform;
    }

    public bool isActive() {
        return active;
    }
}
