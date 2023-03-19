using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 10;
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
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

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(xDir * _speed ,0));
    }
}
