using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
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

    // Animation
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }
    

    private bool CheckGround()
    {
        
        RaycastHit2D hit;

        hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 0.2f, groundMask);

        DrawBoxcast(hit);
     
        return hit;
    }

    private void DrawBoxcast(RaycastHit2D hit)
    {
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

    }

    void Jump()
    {
        

        if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _yDir = 1;
            anim.SetBool("isGrounded", false);
        }
        else if(!CheckGround() || Input.GetKeyUp(KeyCode.Space))
        {
            _yDir = 0;
            anim.SetBool("isGrounded", true);
            
        }
    }

   /*
    MAKE THIS HAPPEN 
    void DownImpulse()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("S is being pressed");
            _r
        }
    }
    */

    void XMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _xDir = -1;
            _sr.flipX = true;
            anim.SetFloat("xDir", math.abs(_xDir));   
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _xDir = 1;
            _sr.flipX = false;
            anim.SetFloat("xDir", math.abs(_xDir));   
        }
        else
        {
            _xDir = 0;
            anim.SetFloat("xDir", math.abs(_xDir));   
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
        //DownImpulse();
    }
}
