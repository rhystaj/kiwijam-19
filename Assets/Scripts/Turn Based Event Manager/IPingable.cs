using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class IPingable : Explodable
{

    [SerializeField] float pingDelay;

    public void RegisterToPing(int turn)
    {
        StartCoroutine(PingAfterDelay(pingDelay,turn));
    }

    private IEnumerator PingAfterDelay(float delay, int turn)
    {
        yield return new WaitForSeconds(delay);
        Ping(turn);
    }

    public abstract void Ping(int turn);
}
