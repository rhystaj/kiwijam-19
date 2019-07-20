using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPingable
{

    [HideInInspector] public Vector3 nextMove;

    [SerializeField] GameManager manager;

    public override void DetectExplosion(int turn)
    {
        Debug.Log("Player Dead");
        //manager.ResetLevel();
    }

    public override void ResetExplodable()
    {
        
    }

    public override void Ping(int turn)
    {
        Debug.Log("Moving Player.");
        transform.position += nextMove;
    }
}
