using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public Text scoreText;
    public Text gameOverText;
    public Button playAgain;
    public Button quit;
    private bool gameOver;
    int score;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        gameOver = false;
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        UpdateScore();
        playAgain.onClick.AddListener(PlayAgain);
        quit.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 0)
            {
                quit.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                quit.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(1.5f);
        while (!gameOver)
        {
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
