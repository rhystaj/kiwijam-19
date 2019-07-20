using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : IPingable
{
    public override void DetectExplosion(int turn)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void Ping(int turn)
    {
        
    }

    public override void ResetExplodable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
