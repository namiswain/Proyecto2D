using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveBehaviour _movebehaviour;
    private Vector2 _direction;
    private Animator _animation;
    public void Awake()
    {
        _animation = GetComponent<Animator>();
        _movebehaviour = GetComponent<MoveBehaviour>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _animation.SetInteger("State", 0);
            _movebehaviour.move(Vector2.up);
        }
        if(Input.GetKey(KeyCode.S))
        {
            _animation.SetInteger("State", 1);
            _movebehaviour.move(Vector2.down);
        }
        if(Input.GetKey(KeyCode.A))
        {
            _animation.SetInteger("State", 2);
            _movebehaviour.move(Vector2.left);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _animation.SetInteger("State", 2);
            _movebehaviour.move(Vector2.right);
        }
        if(!Input.anyKey)
        {
            _animation.SetInteger("State", 0); 
        }
    }
}
