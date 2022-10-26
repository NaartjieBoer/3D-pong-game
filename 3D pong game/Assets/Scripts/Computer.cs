using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed = 100f;
    Vector3 direction;

    GameObject ball;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        ball = GameObject.Find("Ball");

        if (_rb == null)
        {
            Debug.LogError("Computer rigidbody is Null");
        }

        if (ball == null)
        {
            Debug.LogError("Game object ball is Null");
        }

        this.transform.position = new Vector3(0,0,22.4f);

    }

    private void FixedUpdate()
    {
        MoveComputer();
    }

    private void MoveComputer()
    {
        Vector3 ballPosition = ball.transform.position;
        Vector3 currentPosition = this.transform.position;

        currentPosition.z = Mathf.Clamp(currentPosition.z, 9.8f, 9.8f);

        var step = _speed * Time.deltaTime;

        _rb.MovePosition(Vector3.MoveTowards(currentPosition, ballPosition, step));

        if (Vector3.Distance(transform.position, ballPosition) < 0.001f)
        {
            ballPosition *= -1.0f;
        }
    }
}

