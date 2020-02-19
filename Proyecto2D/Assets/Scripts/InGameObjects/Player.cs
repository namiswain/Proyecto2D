using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveBehaviour _movebehaviour;
    private Vector2 _direction;
    private Animator _animation;
    private SpriteRenderer _spriterenderer;
    public bool Teclado;
    private float  _HorizontalAxis;
    private float  _VerticalAxis;
    private bool XButton;
    private bool R1Button;
    private bool Run;
    public void Awake()
    {
        _animation = GetComponent<Animator>();
        _movebehaviour = GetComponent<MoveBehaviour>();
        _spriterenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(Teclado == true)
        {         
            _HorizontalAxis = Input.GetAxis("Horizontal");
            _VerticalAxis = Input.GetAxis("Vertical");
            Run = Input.GetKey(KeyCode.LeftShift);
            R1Button = Input.GetKey(KeyCode.Space);
        }

        if(Teclado == false)
        {         
            _HorizontalAxis = Input.GetAxis("HorizontalPS4");
            _VerticalAxis = Input.GetAxis("VerticalPS4");
            XButton = Input.GetKey(KeyCode.Joystick1Button1);
        }

        if (_HorizontalAxis != 0 || _VerticalAxis != 0)
        {
            _animation.SetFloat("Pos X", _HorizontalAxis);
            _animation.SetFloat("Pos Y", _VerticalAxis);
            _animation.SetBool("Move", true);
        }
        else
            _animation.SetBool("Move", false);

        if(_HorizontalAxis < 0 && (_VerticalAxis < 0.5f || _VerticalAxis > -0.5f))
            _spriterenderer.flipX = true;
        else if(_HorizontalAxis > 0 || _VerticalAxis > 0.5f || _VerticalAxis < -0.5f)
            _spriterenderer.flipX = false;
        
        if((XButton == true) || (Run == true))
        {
            _movebehaviour.Speed = 5f;
        }
        else
        {
            _movebehaviour.Speed = 3f;
        }
        if(R1Button == true)
        {
            _animation.SetBool("Shot", true);
        }
        else if(R1Button == false && _animation.GetBool("Shot") == true)
        {
            GameObject arrow = Instantiate(shotprefab, shotPoint.position)
        }
        _movebehaviour.move(new Vector2(_HorizontalAxis, _VerticalAxis));
    }
}
