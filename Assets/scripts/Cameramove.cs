using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    bool _thrusting;
    bool _reversing;
    bool _left;
    bool _right;
    float _turnDirection;
    Rigidbody _rigidbody;
    float turnSpeed = 1.0f;
    float thrustSpeed = 3.5f;

    private void Awake()
    {
        Time.timeScale = 1;
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()

    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        _reversing = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        // rotatates player
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = 1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }


    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(this.transform.forward * this.thrustSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(0, _turnDirection * this.turnSpeed , 0);
        }
        if (_reversing)
        {
            _rigidbody.AddForce(this.transform.forward * -this.thrustSpeed);
        }
        
        //this.transform.right * this.thrustSpeed;
    }
}
