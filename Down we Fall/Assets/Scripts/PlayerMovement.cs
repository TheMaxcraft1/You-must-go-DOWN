using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir;
    private float yDir;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float jumpPower = 5;
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            yDir = 1;
            print("Space is getting down");
        }
        else
        {
            yDir = 0;
        }
    }

    void XMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            xDir = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xDir = 1;
        }
        else
        {
            xDir = 0;
        }
    }
    void Update()
    {
        XMovement();
        Jump();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(xDir * _speed ,yDir * jumpPower));
    }
}
