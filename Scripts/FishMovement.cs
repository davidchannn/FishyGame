using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float direction = 1;
    public float size = 0.25f;
    public bool fishAlive = true;
    public int fishEaten = 0;
    public Text fishText;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public Rigidbody2D rb;
    Vector2 movement;

    [SerializeField]
    private AudioSource munch;
    // Start is called before the first frame update
    void Start()
    {

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
        if (fishAlive) {
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
                munch.time = 1.37f;
                munch.Play();
                size += 0.03f;
                addFish();
                Destroy(collision.gameObject);
            }
            else {
                munch.time = 1.37f;
                munch.Play();
                fishAlive = false;
                Destroy(gameObject);
                endGame();
            }

            if (fishEaten == 50) {
                Destroy(gameObject);
                winGame();
            }
        }
    }

    public void addFish() {
        fishEaten++;
        fishText.text = fishEaten.ToString();
    }

    public void endGame()
    {
        gameOverScreen.SetActive(true);
    }

    public void winGame()
    {
        victoryScreen.SetActive(true);
    }
}
