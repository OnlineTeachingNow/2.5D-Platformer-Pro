using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _direction;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;

        //get horizontal input
        float _horizontalInput = Input.GetAxis("Horizontal");
        //define direction based on horizontal input
        _direction = new Vector3(_horizontalInput, 0, 0);
        Vector3 _velocity = _direction * _speed;


        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //jump
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }
            //apply gravity
            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;
        //move based on that direction
        _controller.Move(_velocity * Time.deltaTime);

    }

}
