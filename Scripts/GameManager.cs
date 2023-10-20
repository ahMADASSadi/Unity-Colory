using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    // [SerializeField] Image backGroundImage;
    [SerializeField] private ParticleSystem hitEffect;
    private int _randomIndex;
    [SerializeField] Color[] colorsToChange;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI highestScore;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button quit;
    [SerializeField] TextMeshProUGUI scoreText;
    public static GameManager Instance;
    private int _score = 0;
    private SceneManager _sceneManager;
    private WallSpawner _wallSpawner;
    private StarSpawner _pointSpawner;
    private SpinningWallSpawner _spinningWallSpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            hitEffect = FindObjectOfType<ParticleSystem>();
            _wallSpawner = FindObjectOfType<WallSpawner>();
            _pointSpawner = FindObjectOfType<StarSpawner>();
            _spinningWallSpawner = FindObjectOfType<SpinningWallSpawner>();
            _randomIndex = Random.Range(0, colorsToChange.Length);
            ChangeBackgroundColor();
        }
    }

    private void Start()
    {
        _score = 0;
        scoreText.text = _score.ToString();
        gameOverPanel.SetActive(false);
        playAgain.onClick.RemoveAllListeners();
        playAgain.onClick.AddListener(ReloadSceneOne);
        quit.onClick.AddListener(LoadMainMenu);
    }


    public void AddScoreAndApplyColor()
    {
        ApplyColor();
        _score++;
        scoreText.text = _score.ToString();
    }
    public void AddScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }

    private void ApplyColor()
    {
        _randomIndex = Random.Range(0, colorsToChange.Length);
        ChangeBackgroundColor();
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
        Destroy(_wallSpawner);
        Destroy(_pointSpawner);
        Destroy(_spinningWallSpawner);
    }

   public void ReloadSceneOne()
    {
        SceneManager.LoadScene("level1");
    }
   public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ChangeBackgroundColor()
    {
        mainCamera.backgroundColor = colorsToChange[_randomIndex];
        // backGroundImage.color = colorsToChange[_randomIndex];
    }
}