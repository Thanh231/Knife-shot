using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // private BoxCollider2D knifeCollider;
    private bool isMoving = false;
    void Start()
    {
        // knifeCollider = GetComponent<BoxCollider2D>();
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position += Vector3.up * 20f * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            isMoving = false;
            this.transform.parent = collision.transform;
        }
        else if (collision.tag == "Knife")
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        GameManager.ins.EndGame();
    }
}
