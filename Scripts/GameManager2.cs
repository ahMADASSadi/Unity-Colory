using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI highestScore;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button quit;
    [SerializeField] TextMeshProUGUI scoreText;
    public static GameManager2 Instance;
    private int _score = 0;
    private SceneManager _sceneManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            hitEffect = FindObjectOfType<ParticleSystem>();
        }
    }

    private void Start()
    {
        _score = 0;
        scoreText.text = _score.ToString();
        gameOverPanel.SetActive(false);
        playAgain.onClick.RemoveAllListeners();
        playAgain.onClick.AddListener(ReloadSceneTwo);
        quit.onClick.AddListener(LoadMainMenu);
    }

    public void AddScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }


    public void GameOver(GameObject gameObject)
    {
        Destroy(gameObject,.3f);
        StartCoroutine(WaitForSceneLoad());
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }

        finalScore.text = _score.ToString();
        highestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

     IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2.0f);
        gameOverPanel.SetActive(true);
    }

    public void ReloadSceneTwo()
    {
        SceneManager.LoadScene("level2");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}