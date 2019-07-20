using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGrid : MonoBehaviour
{

    [SerializeField] int cellSize;

    [SerializeField] Player player;

    public Player Player { get { return player; } }

    private void OnEnable()
    {
        InputManager.OnDirectionInput += OnMove;
    }

    private void OnDisable()
    {
        InputManager.OnDirectionInput -= OnMove;
    }

    private void OnMove(int horizontalMovment, int verticalMovement)
    {

        int deltaX = cellSize * verticalMovement;
        int deltaY = cellSize * horizontalMovment;

        player.nextMove = new Vector3(deltaX, deltaY, 0);

    }

}
