using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class IPingable : Explodable
{
    public abstract void Ping(int turn);
}
