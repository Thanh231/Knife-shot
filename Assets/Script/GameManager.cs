using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    private string highScore;
    public int currentStage = 0;

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
        // SoundManager.instance.Play(SoundManager.instance.playSound);
        EventManager.StartGame?.Invoke();
    }

    public void EndGame()
    {
        currentStage = 0;
        EventManager.ResetGame?.Invoke();
    }

    public void ShowMenu(int score)
    {
        EventManager.ShowMenu?.Invoke(score);
    }
}
