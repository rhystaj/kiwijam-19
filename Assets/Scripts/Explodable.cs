using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explodable : MonoBehaviour
{
    public abstract void DetectExplosion(int turn);

    public abstract void ResetExplodable();

}
