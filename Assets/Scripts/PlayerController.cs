using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;

    private float _horizontal;
    private float _vertical;
    private float _diagonalMultiplier = 0.7f;

    [SerializeField] private float _runSpeed = 10.0f;
    
    [SerializeField] private float _acceleration = 10.0f;
    [SerializeField] private float _deceleration = 10.0f;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0) 
        {
            _horizontal *= _diagonalMultiplier;
            _vertical *= _diagonalMultiplier;
        }

        Vector2 targetVelocity = new Vector2(_horizontal * _runSpeed, _vertical * _runSpeed);

        _body.velocity = Vector2.Lerp(_body.velocity, targetVelocity, Time.fixedDeltaTime * _acceleration);

        if (_horizontal == 0 && _vertical == 0)
        {
            _body.velocity = Vector2.MoveTowards(_body.velocity, Vector2.zero, Time.fixedDeltaTime * _deceleration);
        }
    }
}
