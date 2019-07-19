using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TurnEventManager : MonoBehaviour
{

    public ICollection<IPingable> pingables;

    private void OnEnable()
    {
        InputManager.OnInput += TakeTurn;
    }

    private void TakeTurn()
    {
        foreach (IPingable pingable in pingables)
            pingable.Ping();
    }

}
