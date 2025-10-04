using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject menu;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI scoreText;
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
        EventManager.IncreasePoint += IncresePoint;
    }

    private void IncresePoint(int point)
    {
        currentScore += point;
        scoreText.text = currentScore.ToString();
    }

    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ShowMenu -= ShowMenu;
        EventManager.IncreasePoint -= IncresePoint;
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

    private void ShowMenu()
    {
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
            if (increaseDuration == currentScore)
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
