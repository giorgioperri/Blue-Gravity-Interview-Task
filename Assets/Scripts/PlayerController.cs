using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private Rigidbody2D _body;
    private SpriteRenderer _sprite;
    private Animator _anim;

    private float _horizontal;
    private float _vertical;
    private float _diagonalMultiplier = 0.7f;

    [SerializeField] private float _runSpeed = 10.0f;
    
    [SerializeField] private float _acceleration = 10.0f;
    [SerializeField] private float _deceleration = 10.0f;

    public Item EquippedItem;
    [SerializeField] private SpriteRenderer _itemSprite;
    
    void Awake()
    {
        base.Awake();
        _sprite = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameStates.Gameplay) return;

        if (EquippedItem != null)
        {
            _itemSprite.sprite = EquippedItem.Icon;
            _itemSprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            _itemSprite.color = new Color(1, 1, 1, 0);
        }

        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if(_horizontal != 0 || _vertical != 0)
        {
            _sprite.flipX = _horizontal < 0;
        }

        _anim.SetBool("Walking", _horizontal != 0 || _vertical != 0);
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.CurrentGameState = GameStates.Inventory;
            InventoryController.Instance.OpenInventory();
        }
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
