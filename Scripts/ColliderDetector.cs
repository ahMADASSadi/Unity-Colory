using UnityEngine;
using TMPro;
public class ColliderDetector: MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private ParticleSystem hitEffect;
    private void Awake()
    {
        hitEffect = FindObjectOfType<ParticleSystem>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            // GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
            hitEffect.Play();
            // DontDestroyOnLoad(hitEffect);
            GameManager.Instance.GameOver(gameObject);
        }

        if (other.gameObject.tag == "Star")
        {
            GameManager.Instance.AddScoreAndApplyColor();
            Destroy(other.gameObject,.02f);
        }
    }
}