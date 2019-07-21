using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TurnEventManager : MonoBehaviour
{

    [SerializeField] EventGrid Grid;

    public ICollection<IPingable> pingables;

    private int turnNumber = 0;

    private float cooldown;

    private void Start()
    {
        pingables = new List<IPingable>(Grid.GetComponentsInChildren<IPingable>());
        Debug.Log("Pingables: " + pingables.Count);
    }

    private void OnEnable()
    {
        InputManager.OnInput += TakeTurn;
    }

    private void OnDisable()
    {
        InputManager.OnInput -= TakeTurn;
    }

    private void Update()
    {

    }

    private void TakeTurn()
    {

        foreach (IPingable pingable in pingables)
            pingable.Ping(turnNumber);
        turnNumber++;

    }

    public void ResetTurns()
    {
        turnNumber = 0;
    }

}
