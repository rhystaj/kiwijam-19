using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explodable : MonoBehaviour
{

    public bool Destroyed { get; protected set; }

    public virtual void DetectExplosion(int turn)
    {
        Destroyed = true;
    }

    public virtual void ResetExplodable()
    {
        Destroyed = false;
    }

}
