﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPingable
{

    [HideInInspector] public Vector3 nextMove;

    public override void Ping(int turn)
    {
        Debug.Log("Moving Player.");
        transform.position += nextMove;
    }
}
