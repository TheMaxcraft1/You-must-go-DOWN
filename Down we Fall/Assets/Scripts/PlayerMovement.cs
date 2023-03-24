using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // x Movement variables
    private float _xDir;
    [SerializeField] private float speed = 10;

    // y Movement variables
    private bool _canJump;
    private float _yDir;
    [SerializeField] private float jumpPower = 5;
    
    // Component variables
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    
    // Ground Detection
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundMask;
    
    
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private bool CheckGround()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(feet.position, Vector2.down, 0.2f, groundMask);

        return hit;
    }

    void Jump()
    {
        print(CheckGround());
        Debug.DrawRay(feet.position, Vector2.down * 0.2f, Color.green);
        if (CheckGround() && Input.GetKey(KeyCode.Space))
        {
            _yDir = 1;
            _canJump = false;
        }
        else
        {
            _yDir = 0;
            _canJump = true;
        }
    }

    void XMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _xDir = -1;
            _sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _xDir = 1;
            _sr.flipX = false;
        }
        else
        {
            _xDir = 0;
        }
    }
    void Update()
    {
        XMovement();
        Jump();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_xDir * speed ,_yDir * jumpPower));
    }
}
