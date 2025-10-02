using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // private BoxCollider2D knifeCollider;
    private bool isMoving = false;
    private bool isCollide = false;
    
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

        if (isCollide)
        {
            transform.position -= Vector3.up * 30f * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isMoving = false;
            this.transform.parent = collision.transform;
        }
        else if (collision.gameObject.tag == "Knife")
        {
            isCollide = true;
            StartCoroutine(EndGame());
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        GameManager.ins.EndGame();
        isCollide = false;
    }
}
