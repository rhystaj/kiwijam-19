using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : IPingable
{

    public bool Active { get; private set; }

    public override void DetectExplosion(int turn)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        base.DetectExplosion(turn);
    }

    public override void Ping(int turn)
    {
        
    }

    public override void ResetExplodable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        base.ResetExplodable();    
    }

}
