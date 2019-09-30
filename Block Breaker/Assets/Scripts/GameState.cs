using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // config parameters
    [Range(1f, 2f)] [SerializeField] float gameSpeed = 1.000f;
    [SerializeField] int pointsPerBlockDestroyed = 69;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameSpeedText;
    [SerializeField] bool isAutoPlayEnabled;


    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameState>().Length;
        if (gameStateCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
        gameSpeedText.text = "Game Speed: " + gameSpeed.ToString() + "x";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSpeedUpdate()
    {
        gameSpeed += 0.01f;
        Time.timeScale = gameSpeed;
        gameSpeedText.text = "Game Speed: " + gameSpeed.ToString() + "x";
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
