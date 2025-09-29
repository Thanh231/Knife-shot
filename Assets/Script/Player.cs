using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float dir = 1;
    public GameObject babySprite;
    public CircleCollider2D circleCollider;
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
        babySprite.SetActive(true);
        circleCollider.enabled = true;
    }

    public void DisablePlayerObject()
    {
        babySprite.SetActive(false);
        circleCollider.enabled = false;
        isStartGame = false;
    }

    private void Update()
    {
        if (isStartGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dir *= -1;
                SoundManager.instance.Play(SoundManager.instance.moveSound);
            }
            float speed = GameManager.ins.GetPlayerSpeed();
            transform.RotateAround(Vector3.zero, Vector3.forward, speed * dir * Time.deltaTime);
        }

    }
}
