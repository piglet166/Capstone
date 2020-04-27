using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public Text finalScore;
    public Text finalTime;
    public Text enemiesKilled;
    public Text deaths;

    private void Start() {
        Cursor.visible = true;

        finalScore.text = "Total Score: " + Score.Instance.CalculateScore().ToString();
        finalTime.text = "Total Time: " + Score.Instance.time.ToString() + " seconds";
        enemiesKilled.text = "Total Kills: " + Score.Instance.kills.ToString();
        deaths.text = "Total ReSpawns: " + Score.Instance.deaths.ToString();
    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
