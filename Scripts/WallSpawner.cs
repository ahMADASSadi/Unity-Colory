using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private float lifeTime = 8f;
    private float maxTime;
    [SerializeField] private float time;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private float startTime;
    [SerializeField] private float endTime;
    GameObject _wall;

    private void Start()
    {
        time = 1;
    }

    private void Update()
    {
        maxTime = Random.Range(startTime, endTime);
        if (time > maxTime)
        {
            _wall = Instantiate(wallPrefab);
            _wall.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
            time = 0;
        }

        time += Time.deltaTime;
        Destroy(_wall, lifeTime);
    }
}
