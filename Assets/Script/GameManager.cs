using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    private string highScore;
    public int currentLevel = 0;

    // public List<float> speedPlayer;

    // public List<float> speedObstacle;
    // public List<float> pivotScore, speedIncreaseScore;

    public float basePivotScore = 100f;
    public float pivotMultiplier = 2f;

    public float basePlayerSpeed = 60;
    public float playerSpeedMultiplier = 1.1f;

    public float baseObstacleSpeed = 55;
    public float obstacleSpeedMultiplier = 1.05f;

    public float baseincreasePointSpeed = 10;
    public float increasePointSpeedMultiplier = 1.05f;
    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public float GetPivotScoreForNextLevel()
    {
        return basePivotScore * Mathf.Pow(pivotMultiplier, currentLevel);
    }

    public float GetPlayerSpeed()
    {
        return basePlayerSpeed * Mathf.Pow(playerSpeedMultiplier, currentLevel);
    }

    public float GetObstacleSpeed()
    {
        return baseObstacleSpeed * Mathf.Pow(obstacleSpeedMultiplier, currentLevel);
    }

    public float GetIncreasePointSpeed()
    {
        return baseincreasePointSpeed * Mathf.Pow(increasePointSpeedMultiplier, currentLevel);
    }
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScore, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScore, value);
        }
    } 

    public void PlayGame()
    {
        SoundManager.instance.Play(SoundManager.instance.playSound);
        EventManager.StartGame?.Invoke();
    }

    public void EndGame()
    {
        currentLevel = 0;
        EventManager.ResetGame?.Invoke();
    }

    public void ShowMenu(int score)
    {
        EventManager.ShowMenu?.Invoke(score);
    }
}
