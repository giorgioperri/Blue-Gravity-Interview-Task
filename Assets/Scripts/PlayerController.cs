using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;

    private float _horizontal;
    private float _vertical;
    private float _diagonalMultiplier = 0.7f;

    public float RunSpeed = 20.0f;

    void Start ()
    {
        _body = gameObject.AddComponent<Rigidbody2D>();
        _body.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Check for diagonal movement
        if (_horizontal != 0 && _vertical != 0) 
        {
            _horizontal *= _diagonalMultiplier;
            _vertical *= _diagonalMultiplier;
        } 

        _body.velocity = new Vector2(_horizontal * RunSpeed, _vertical * RunSpeed);
    }
}
