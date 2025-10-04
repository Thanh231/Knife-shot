using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
        StartCoroutine(ShowMenu());
    }
    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2f);
        EventManager.ShowMenu?.Invoke();
        EventManager.CleanObject?.Invoke();
    }

    public void ReturnKnifeToPool(GameObject knife)
    {
        EventManager.ReturnObjectToPool?.Invoke(knife);
    }

    public void IncresePoint(int point)
    {
        EventManager.IncreasePoint?.Invoke(point);
    }
}
