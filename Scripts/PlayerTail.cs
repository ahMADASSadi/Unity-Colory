using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    [SerializeField] float lifeTime = 4f;
    [SerializeField] float startTime;
    private float timeBetweenSpawn;
    [SerializeField] private GameObject followPrefab;
    private PlayerControllerLevel1 _playerLevel1;
    private PlayerControllerLevel2 _playerLevel2;

    private void Awake()
    {
        _playerLevel1 = GetComponent<PlayerControllerLevel1>();
        _playerLevel2 = GetComponent<PlayerControllerLevel2>();
    }

    private void Update()
    {
        if (timeBetweenSpawn <= 0 && !_playerLevel1.isGrounded)
        {
            GameObject follow = Instantiate(followPrefab, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTime;
            Destroy(follow, lifeTime);
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}