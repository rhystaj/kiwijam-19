using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TurnEventManager : MonoBehaviour
{

    [SerializeField] EventGrid Grid;

    public ICollection<IPingable> pingables;

    [SerializeField] float cooldownSeconds;

    private float cooldown;

    private void Start()
    {
        pingables = new List<IPingable>(Grid.GetComponentsInChildren<IPingable>());
        Debug.Log("Pingables: " + pingables.Count);
    }

    private void OnEnable()
    {
        Debug.Log("Subscribing Take Turn");
        InputManager.OnInput += TakeTurn;
    }

    private void OnDisable()
    {
        InputManager.OnInput -= TakeTurn;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void TakeTurn()
    {

        if (cooldown > 0) return;

        foreach (IPingable pingable in pingables)
            pingable.Ping();

        cooldown = cooldownSeconds;

    }

}
