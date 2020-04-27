using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    public float time;
    public int deaths;
    public int enemies;
    public int totalEnemies;
    public int kills;
    public int finalScore;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void KeepTime(float t) {
        time = t;
    }

    public void EnemyTotal(int te) {
        totalEnemies = te;
    }

    public void EnemyCounter(int e) {
        enemies = e;
    }

    public void DeathCounter(int d) {
        deaths = d;
    }

    public int CalculateScore() {
        kills = totalEnemies - enemies;

        if (time <= 630) {

            finalScore = 200;

        } else if (time > 630 && time <= 660) {

            finalScore = 180;

        } else if (time > 660 && time <= 720) {

            finalScore = 160;

        } else if (time > 720 && time <= 780) {

            finalScore = 140;

        } else if (time > 780 && time <= 840) {

            finalScore = 120;

        } else {

            finalScore = 100;
        }

        finalScore = finalScore + (kills * 20);
        finalScore = finalScore - (deaths * 10);

        return finalScore;
    }

    public void ResetScore() {
        time = 0;
        deaths = 0;
        enemies = 0;
        totalEnemies = 0;
    }
}
