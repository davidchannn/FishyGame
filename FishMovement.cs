using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FishMovement : MonoBehaviour
{
    public GameHandler gameHandler;
    public float size = 0.25f;
    public float moveSpeed = 5;
    public float direction = 1;
    public Rigidbody2D rb;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
        gameHandler.background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Movement
    void FixedUpdate() 
    {
        if (movement.x > 0)
        {
            direction = 1;
            transform.localScale = new Vector3(size, direction * size, size);
        }
        else if (movement.x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(size, direction * size, size);
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollision2D(Collision2D collision)
    {
        moveSpeed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Vector3 enemySize = collision.gameObject.transform.localScale;
            if (size > enemySize.z)
            {
                gameHandler.eat();
                size += 0.03f;
                Destroy(collision.gameObject);
            }
            else {
                gameHandler.lose();
                Destroy(gameObject);
                gameHandler.gameOverScreen.SetActive(true);
            }

            if (gameHandler.fishEaten == 50) {
                Destroy(gameObject);
                gameHandler.victoryScreen.SetActive(true);
            }
        }
    }
}
