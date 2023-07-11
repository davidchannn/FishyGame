using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public float size = 0.25f;
    public bool fishAlive = true;
    public int fishEaten;
    public Text fishText;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    [SerializeField] private AudioSource munch;
    [SerializeField] public AudioSource background;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            background.Pause();
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame() {
        SceneManager.LoadScene("GameScreen");
    }

    public void resumeGame() {
        background.UnPause();
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitGame() {
        Application.Quit();
    }

    public void addFish()
    {
        fishEaten++;
        fishText.text = fishEaten.ToString();
    }

    public void eat() {
        munch.time = 1.37f;
        munch.Play();
        addFish();
    }

    public void lose() {
        munch.time = 1.37f;
        munch.Play();
        fishAlive = false;
    }
}
