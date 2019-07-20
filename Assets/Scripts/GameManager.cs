using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] EventGrid grid;
    [SerializeField] TurnEventManager turnEventManager;
    [SerializeField] UIManager uiManager;

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
        uiManager.HideFailStateScreen();

        Vector3 playerPosition = new Vector3(playerStartPosition.x, playerStartPosition.y, 0);
        grid.Player.transform.position = playerPosition;

        Debug.Log("Explodables to Reset: " + grid.GetComponentsInChildren<Explodable>().Length);

        foreach (Explodable explodable in grid.GetComponentsInChildren<Explodable>()) {
            Debug.Log("Explodable: " + explodable.name); 
            explodable.ResetExplodable();
        }
            
    }

    public void GameOver()
    {
        uiManager.ShowFailStateScreen();
    }

}
