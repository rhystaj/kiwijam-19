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
        manager.GameOver();
    }

    public override void Ping(int turn)
    {

        if (Destroyed) return;

        transform.position += nextMove;
    }
}
