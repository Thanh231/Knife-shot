using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject explosion;

    private float timer = 0;
    private float dir = 1;
    private bool isStartGame = false;
    void OnEnable()
    {
        EventManager.StartGame += StartGame;
        EventManager.ResetGame += ResetGame;

        explosion.GetComponent<ParticleSystem>().Stop();

    }

    private void StartGame()
    {
        isStartGame = true;
    }

    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ResetGame -= ResetGame;
    }

    private void ResetGame()
    {
        timer = 0;
        dir = (UnityEngine.Random.Range(0, 2) == 0) ? 1f : -1f;
        isStartGame = false;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (isStartGame)
        {
            timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            timer = 0f;
            dir = (UnityEngine.Random.Range(0, 2) == 0) ? 1f : -1f;
        }
        transform.Rotate(0, 0, GameManager.ins.GetObstacleSpeed() * dir * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().DisablePlayerObject();

        SoundManager.instance.Play(SoundManager.instance.loseSound);

        if (explosion != null)
        {

            explosion.transform.position = collision.gameObject.transform.position;
            explosion.GetComponent<ParticleSystem>().Play();
        }

        StartCoroutine(EndGame());
    }
    private IEnumerator EndGame()
    {

        yield return new WaitForSeconds(2f);
        GameManager.ins.EndGame();
    }
}
