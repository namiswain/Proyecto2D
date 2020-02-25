using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePass : MonoBehaviour
{
    public Collider2D LayerChanger1;
    public Collider2D LayerChanger2;
    public Collider2D Play;
    public List<Collider2D> Fence;
    public Collider2D BridgeCol;
    public List<Collider2D> Border;
    public SpriteRenderer _spriterenderer;
    public void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();
    }
    public void Bridge()
    {
        if(Play.IsTouching(LayerChanger1))
        {
            _spriterenderer.sortingOrder = 9;
        }
        if(Play.IsTouching(LayerChanger2))
        {
            _spriterenderer.sortingOrder = 12;
        }
        ///////////////////el puto bridge//////////////////
        if(BridgeCol.IsTouching(Play) && (_spriterenderer.sortingOrder == 12))
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

    }
}
