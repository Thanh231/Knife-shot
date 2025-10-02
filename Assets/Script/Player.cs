using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject knifePrefabs;
    private bool isStartGame = false;
    private Vector3 defaultPos = new Vector3(0, 1.6f, 0);
    void OnEnable()
    {
        EventManager.StartGame += StartGame;
        EventManager.ResetGame += ResetGame;
    }
    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ResetGame -= ResetGame;
    }

    private void ResetGame()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.identity;
    }

    private void StartGame()
    {
        isStartGame = true;

    }

    public void DisablePlayerObject()
    {
        isStartGame = false;
    }

    private void Update()
    {
        if (isStartGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(knifePrefabs, transform.position, Quaternion.identity);
            }
        }

    }
}
