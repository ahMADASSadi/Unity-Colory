using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerControllerLevel2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpSpeed = 650;
    private int zero = 0;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.gravityScale = gravityScale;
            Jump();
        }
    }

    void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(x: zero, y: jumpSpeed));
    }
}