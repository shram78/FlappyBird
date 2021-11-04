using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRoration;
    private Quaternion _minRoration;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRoration = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRoration = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0); // попробуй нью вынести в поля
            transform.rotation = _maxRoration;
            _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force); 
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRoration, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody2D.velocity = Vector2.zero;
    }
}