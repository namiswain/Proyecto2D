using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveBehaviour _movebehaviour;
    private Vector2 _direction;
    private Animator _animation;
    public SpriteRenderer _spriterenderer;
    public bool Teclado;
    private float  _HorizontalAxis;
    private float  _VerticalAxis;
    private bool XButton;
    ///////////////COLLIDER LAYER CHANGER/////////////
    public Collider2D LayerChanger1;
    public Collider2D LayerChanger2;
    public Collider2D Play;
    ///////////////////BRIDGE//////////////////////
    public List<Collider2D> Fence;
    public Collider2D Bridge;
   public List<Collider2D> Border;

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
        
        if(XButton == true)
        {
            _movebehaviour.Speed = 4.5f;
        }
        else
        {
            _movebehaviour.Speed = 3f;
        }
        
        if(Play.IsTouching(LayerChanger1))
        {
            _spriterenderer.sortingOrder = 9;
        }
        if(Play.IsTouching(LayerChanger2))
        {
            _spriterenderer.sortingOrder = 12;
        }
        ///////////////////el puto bridge//////////////////
        if(Bridge.IsTouching(Play) && (_spriterenderer.sortingOrder == 12))
        {
            for (int i = 0; i < Fence.Count; i++)
            {
                Fence[i].enabled = false;
            }            
            Border[0].enabled = true;
            Border[1].enabled = true;
            Border[2].enabled = false;
            Border[3].enabled = false;
        }
        else
        {
            for (int i = 0; i < Fence.Count; i++)
            {
                Fence[i].enabled = true;
            }
            Border[0].enabled = false;
            Border[1].enabled = false;
            Border[2].enabled = true;
            Border[3].enabled = true;
        }
        _movebehaviour.move(new Vector2(_HorizontalAxis, _VerticalAxis));
    }
}
