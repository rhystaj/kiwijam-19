using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPingable
{

    [HideInInspector] public Vector3 nextMove;

    [SerializeField] GameManager manager;

    public override void DetectExplosion(int turn)
    {
        base.DetectExplosion(turn);
        GetComponent<SpriteRenderer>().enabled = false;
        manager.GameOver();
    }

    public override void ResetExplodable()
    {
        base.ResetExplodable();
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void Ping(int turn)
    {

        if (Destroyed) return;

        transform.position += nextMove;
    }
}
