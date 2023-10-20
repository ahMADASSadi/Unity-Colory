using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.position = player.transform.position+new Vector3(0,3,-10);
    }
}
