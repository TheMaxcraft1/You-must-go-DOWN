using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // x Movement variables
    private float _xDir;
    [SerializeField] private float speed = 10;

    // y Movement variables
    private float _yDir;
    [SerializeField] private float jumpPower = 5;
    
    // Component variables
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    
    // Ground Detection
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask groundMask;


    private void Awake()
    {
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }
    

    private bool CheckGround()
    {
        
        RaycastHit2D hit;

        hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 0.2f, groundMask);
        
        Color raycolor;
        if (hit.collider != null)
        {
            raycolor = Color.green;
            
        }
        else
        {
            raycolor = Color.red;
        }
        Debug.DrawRay(_boxCollider2D.bounds.center + new Vector3(_boxCollider2D.bounds.extents.x,0), Vector2.down * (_boxCollider2D.bounds.extents.y + 0.2f ),raycolor );
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x,0), Vector2.down * (_boxCollider2D.bounds.extents.y + 0.2f ),raycolor );
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, _boxCollider2D.bounds.extents.y + 0.2f), Vector2.right * (_boxCollider2D.bounds.extents.x * 2),raycolor );

        return hit;
    }

    private void DrawBoxcast()
    {
   
    }

    void Jump()
    {

        if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _yDir = 1;
        }
        else if(!CheckGround() || Input.GetKeyUp(KeyCode.Space))
        {
            _yDir = 0;
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
        _rb.AddForce(new Vector2(_xDir * speed ,_yDir * jumpPower), ForceMode2D.Impulse);
    }
}
