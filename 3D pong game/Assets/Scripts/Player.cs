using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private float _speed = 10.0f;
    private Vector3 _direction;
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
        _rb = GetComponent<Rigidbody>();

        if (_rb == null)
        {
            Debug.LogError("Player rigid body script is nulls");
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        _direction = GetWorldPositionFromMouse() * _speed * Time.deltaTime;
        _direction.x = Mathf.Clamp(_direction.x, -10f, 10f);
        _direction.y = Mathf.Clamp(_direction.y, -7f, 9f);

        _rb.MovePosition(_direction);
    }

    private Vector3 GetWorldPositionFromMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _mainCamera.nearClipPlane + 14.8f;

        return _mainCamera.ScreenToWorldPoint(mousePos);
    }
}