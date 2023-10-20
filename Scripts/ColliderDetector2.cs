using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColliderDetector2 : MonoBehaviour
{
    private GameManager2 _gameManager;
    private SpriteRenderer _renderer;
    [SerializeField] private ParticleSystem hitEffect;
    List<string> colorsTag = new List<string> { "Red", "Yellow", "Green", "Blue" };
    [SerializeField] List<Color> colors = new List<Color>();
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager2>();
        hitEffect = FindObjectOfType<ParticleSystem>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Tag")
        {
            Debug.Log("Tag");
            Destroy(other.gameObject);
            ColorAndTagChanger(gameObject);
            return; 
        }

        if (other.gameObject.tag=="Star")
        {
            GameManager2.Instance.AddScore();
            Destroy(other.gameObject);
        }

        
        else if(gameObject.tag!=other.gameObject.tag)
        {
            hitEffect.transform.position = gameObject.transform.position;
            hitEffect.GetComponent<ParticleSystem>().Play();
            _gameManager.GameOver(gameObject);
        }
    }
    public void ColorAndTagChanger(GameObject gameObject)
    {
        var item = Random.Range(0, colorsTag.Count);
        gameObject.tag = colorsTag[item];
        _renderer.color = colors[item];
    }
}