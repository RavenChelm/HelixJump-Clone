using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    public Controll controll;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject wonMenu;
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private TMP_Text nextLevelText;
    [SerializeField] private TMP_Text wonLevelText;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text recordScore;
    [SerializeField] private TMP_Text loseScore;
    [SerializeField] private Slider progressbar;
    [SerializeField] private TMP_Text loseProgress;
    [SerializeField] private ParticleSystem LeftWin;
    [SerializeField] private ParticleSystem RightWin;


    private int currentLevel
    {
        get => PlayerPrefs.GetInt(levelIndexKey, 1);
        set
        {
            PlayerPrefs.SetInt(levelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string levelIndexKey = "LevelIndex";
    //заготовка
    private int maxRecord
    {
        get => PlayerPrefs.GetInt(recordIndexKey, 1);
        set
        {
            PlayerPrefs.SetInt(recordIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string recordIndexKey = "RecordIndex";
    private int currentScore;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrrentState { get; private set; }
    private void Awake()
    {
        currentLevelText.SetText(currentLevel.ToString());
        nextLevelText.SetText((currentLevel + 1).ToString());
        score.SetText("0");
        recordScore.SetText("Best score: " + maxRecord.ToString());
    }
    public void OnPlayerDied()
    {
        if (CurrrentState != State.Playing) return;
        CurrrentState = State.Loss;
        controll.enabled = false;
        wonMenu.SetActive(false);
        loseMenu.SetActive(true);
        loseScore.SetText("You score: " + currentScore.ToString());
        loseProgress.SetText((progressbar.value * 100).ToString("F0") + "% Complete");
    }

    public void OnPlayerFinish()
    {
        if (CurrrentState != State.Playing) return;
        CurrrentState = State.Won;
        controll.enabled = false;
        wonMenu.SetActive(true);
        loseMenu.SetActive(false);
        LeftWin.Play();
        RightWin.Play();
        wonLevelText.SetText("Level " + currentLevel + " completed");
        currentLevel++;
        if (currentScore > maxRecord)
        {
            maxRecord = currentScore;
        }
    }
    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddPoints(int coefficient = 1)
    {
        currentScore += 2 * coefficient;
        score.SetText(currentScore.ToString());
    }
}
