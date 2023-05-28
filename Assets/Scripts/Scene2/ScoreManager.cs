using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI totalScoreTxt;
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI bestTimeTxt;
    [SerializeField] private TextMeshProUGUI winningMessage;
    [SerializeField] private GameServer server;

    private int score = 0;
    float gameTime = 5;
    float timer = 0;

    private void Start()
    {
        winningMessage.text = "";
        timer = gameTime;
        var saveData = server.Load();
        if (saveData != null)
        {
            totalScoreTxt.text = saveData.TotalScore.ToString();
            bestTimeTxt.text = saveData.bestTime.ToString();
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreTxt.text = score.ToString();
        if (score == 9)
        {
            winningMessage.text = "Congratulation" ;
            SaveProgress();
            Invoke(nameof(GoBackToMainMenu), 5f);
        }
    }

    void GoBackToMainMenu()
    {
        SceneManager.LoadScene(GameConstants.mainMenuScene);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timeTxt.text = timer.ToString(); 
    }

    void SaveProgress()
    {
        var saveData = server.Load();
        if (saveData == null)
        {
            saveData = new SaveData() { bestTime = 100};
        }
        saveData.lastScore = score;
        saveData.TotalScore += score;
        saveData.time = timer;
        saveData.bestTime = saveData.bestTime > timer ? timer : saveData.bestTime;  
        server.UpdateData(saveData);
        server.Save();
    }
}
