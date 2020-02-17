using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void move()
    {
        _rb.MovePosition(new Vector2(transform.position.x + _speed * Time.deltaTime * _direction.x , transform.position.y + _speed * Time.deltaTime * _direction.y));
    }
    public void move(Vector2 NewDirection)
    {
        _rb.MovePosition(new Vector2(transform.position.x + _speed * Time.deltaTime * NewDirection.x , transform.position.y + _speed * Time.deltaTime * NewDirection.y));
    }
}
