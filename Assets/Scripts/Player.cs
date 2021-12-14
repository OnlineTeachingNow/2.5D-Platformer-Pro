using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _direction;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] bool _isGrounded;
    [SerializeField] float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_velocity = 20;
    }

    // Update is called once per frame
    void Update()
    {
        /* The following was my super rusty attempt to move the player when pressing the left and right arrow keys.
         * Instead of this nonsense, I will use Jonathan's much more elegant attempt, which gets a reference to the horizontal axis
         * and allows the developer flexibility of using the horizontal axis menu to decide which buttons can be used to
         * move the character. Also, his solution is a LOT simpler and less lines. 
         * 
        //get horizontal input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = new Vector3(1, 0, 0);

        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _direction = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _direction = new Vector3(0, 0, 0);
        }

        //define direction based on that input
        MovePlayer();
        */

        _isGrounded = _controller.isGrounded;

        //get horizontal input
        float _horizontalInput = Input.GetAxis("Horizontal");
        //define direction based on horizontal input
        _direction = new Vector3(_horizontalInput, 0, 0);
        Vector3 _velocity = _direction * _speed;


        //if grounded
        if (_controller.isGrounded == true)
        {
            //do nothing
            //if space bar pressed
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

    /*
    private void MovePlayer()
    {
        _controller.Move(_velocity * _direction * Time.deltaTime);
    }
    */
}
