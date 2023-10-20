using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem touchEffect;

    private void Awake()
    {
        touchEffect = FindObjectOfType<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchEffect.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,1));
            touchEffect.Play();
        }
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("level1");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("level2");
    }
}
