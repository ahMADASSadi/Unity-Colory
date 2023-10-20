using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    private void Update()
    {
        transform.position += Vector3.left * (MoveSpeed * Time.deltaTime);
    }
}