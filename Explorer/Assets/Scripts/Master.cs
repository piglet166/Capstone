﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    
    GameObject[] respawns;
    SavePoint[] savePoints;
    public GameObject respawnPrefab;
    public Health player;
    public Camera cam;
    public int deaths;
    public int enemiesLeft;
    public HealthBar hb;
    //public Score score;

    // Start is called before the first frame update
    void Start()
    {
        Score.Instance.ResetScore();

        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        savePoints = new SavePoint[respawns.Length];

        for (int i = 0; i < respawns.Length; i++) {
            savePoints[i] = respawns[i].GetComponent<SavePoint>();
            savePoints[i].serialNumber = i;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        Score.Instance.EnemyTotal(enemiesLeft);

        hb.SetMaxHealth(player.MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        hb.ShowHealth(player.health);

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

        Vector3 respawnPos = new Vector3(dest.transform.position.x, dest.transform.position.y + 0.32f, 0f);

        player.gameObject.transform.position = respawnPos;
        player.health = 25;
        deaths += 1;
        Score.Instance.DeathCounter(deaths);
    }

    public void EnemyDied() {
        enemiesLeft -= 1;
        Score.Instance.EnemyCounter(enemiesLeft);
    }
}
