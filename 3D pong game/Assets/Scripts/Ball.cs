using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed = 1.0f;
    private Vector3 _velocity;
    [SerializeField]
    public float airDensity = 0.1f;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (_rb == null)
        {
            Debug.LogError("Ball ridigbody is NULL");
        }

        _rb.velocity = Vector3.back * _speed * Time.deltaTime;
        
    }

    void FixedUpdate()
    {
        var direction = Vector3.Cross(_rb.angularVelocity, _rb.velocity);
        var magnitude = 4 / 3f * Mathf.PI * airDensity * Mathf.Pow(1.75f, 3);
        _rb.AddForce(magnitude * direction);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _velocity = Vector3.Reflect(-other.relativeVelocity, other.contacts[0].normal);
            _rb.velocity = _velocity.normalized * _speed * Time.deltaTime;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            _velocity = Vector3.Reflect(-other.relativeVelocity, other.contacts[0].normal);
            _rb.velocity = _velocity.normalized * _speed * Time.deltaTime;
        }
    }
}

//old code
/*
         if (other.gameObject.CompareTag("Wall"))
        {
            _velocity = Vector3.Reflect(-other.relativeVelocity, other.contacts[0].normal);
            _rb.velocity = _velocity.normalized * _speed * Time.deltaTime;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            _velocity = Vector3.Reflect(-other.relativeVelocity, other.contacts[0].normal);
            _rb.velocity = _velocity.normalized * _speed * Time.deltaTime;
        }
 */
