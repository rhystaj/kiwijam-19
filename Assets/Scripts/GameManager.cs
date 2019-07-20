using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] EventGrid grid;
    [SerializeField] TurnEventManager turnEventManager;

    [SerializeField] Vector2 playerStartPosition;

    private void OnEnable()
    {
        InputManager.OnReset += ResetLevel;
    }

    private void OnDisable()
    {
        InputManager.OnReset -= ResetLevel;
    }

    private void Start()
    {
        Vector3 playerPosition = grid.Player.transform.position;
        playerStartPosition = new Vector2(playerPosition.x, playerPosition.y);   
    }

    public void ResetLevel()
    {

        turnEventManager.ResetTurns();

        Vector3 playerPosition = new Vector3(playerStartPosition.x, playerStartPosition.y, 0);
        grid.Player.transform.position = playerPosition;

        foreach (Barrel barrel in grid.GetComponentsInChildren<Barrel>())
            barrel.ResetBarrel();
    }



}
