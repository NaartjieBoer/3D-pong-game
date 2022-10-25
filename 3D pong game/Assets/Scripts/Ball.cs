using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed = 1.0f;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (_rb == null)
        {
            Debug.LogError("Ball ridigbody is NULL");
        }

        //direction = Vector3.back * _speed * Time.deltaTime;
        _rb.velocity = Vector3.back * _speed * Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //_lastVelocity = _rb.velocity;
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
            _velocity = Vector3.Reflect(-other.relativeVelocity, other.contacts[0].normal);
            _rb.velocity = _velocity.normalized * _speed * Time.deltaTime;
        }
    }
}
