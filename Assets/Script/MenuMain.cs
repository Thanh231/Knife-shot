using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject menu;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI tutorialText;
    private bool isIncreasePoint = false;
    private int increaseDuration = 0;

    private int currentScore = 0;
    private int highScore = 0;

    void OnEnable()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            tutorialText.text = "Tap to steer and avoid obstacle";
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            tutorialText.text = "Click to steer and avoid obstacle";
        }
        EventManager.StartGame += StartGame;
        EventManager.ShowMenu += ShowMenu;
    }
    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ShowMenu -= ShowMenu;
    }


    private void StartGame()
    {
        tutorial.SetActive(false);
        currentScore = 0;
        increaseDuration = 0;
    }

    public void SkipMenu()
    {
        tutorial.SetActive(true);
        menu.SetActive(false);
    }

    private void Start()
    {
        highScoreText.text = "";
        currentScoreText.text = "";
        menu.SetActive(true);

    }

    private void ShowMenu(int score)
    {
        currentScore = score;
        isIncreasePoint = true;
        highScore = GameManager.ins.HighScore;
        highScoreText.text = "HIGH SCORE \n" + highScore.ToString("0000");
        menu.SetActive(true);
    }

    void Update()
    {
        if (isIncreasePoint)
        {
            increaseDuration++;
            if (increaseDuration > currentScore)
            {
                isIncreasePoint = false;

            }
            if (currentScore > highScore)
            {
                currentScoreText.text = "NEW BEST \n" + increaseDuration.ToString("0000");
                GameManager.ins.HighScore = currentScore;
            }
            else
            {
                currentScoreText.text = "SCORE \n" + increaseDuration.ToString("0000");
            }
        }
    }

}
