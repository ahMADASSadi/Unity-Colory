using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private int startTime;
    [SerializeField] private int maxTime;
    float timeBetweenSpawns;
    [SerializeField] private GameObject starPrefab;
    private float time = 0;
    GameObject _point;
    private void Update()
    {
        timeBetweenSpawns = Random.Range(startTime, maxTime);
        if (time >= timeBetweenSpawns)
        {
            _point = Instantiate(starPrefab,
                (transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0)),
                Quaternion.identity);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
