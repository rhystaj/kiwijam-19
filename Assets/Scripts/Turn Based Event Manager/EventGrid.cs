using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGrid : MonoBehaviour
{

    [SerializeField] Vector2Int gridSize;

    [SerializeField] int cellSize;

    [SerializeField] Player player;

    private Explodable[,] cells;

    private Vector2 PlayerGridLocation
    {
        get
        {
            return CalculateGridLocation(player.transform.position);
        }
    }


    public Player Player { get { return player; } }

    private void OnEnable()
    {
        InputManager.OnDirectionInput += OnMove;
    }

    private void OnDisable()
    {
        InputManager.OnDirectionInput -= OnMove;
    }

    private void Start()
    {

        cells = new Explodable[(int)gridSize.y, (int)gridSize.x];

        foreach(Explodable explodable in GetComponentsInChildren<Explodable>())
        {

            Vector2 gridLocation = CalculateGridLocation(explodable.transform.position);

            if(!(explodable is Player))
                cells[(int)gridLocation.y, (int)gridLocation.x] = explodable;

            explodable.transform.position = CalculatePositionFromGridLocation((int)gridLocation.y, (int)gridLocation.x);

        }

    }

    private Vector2 CalculateGridLocation(Vector3 positionVector)
    {

        int gridRow = (int)(positionVector.y / cellSize) + (gridSize.y / 2);
        int gridColumn = (int)(positionVector.x / cellSize) + (gridSize.x / 2);

        return new Vector2(gridColumn, gridRow);

    }

    private Vector3 CalculatePositionFromGridLocation(int gridRow, int gridColumn)
    {
        return new Vector3((gridColumn - (gridSize.y / 2)) * cellSize, (gridRow - (gridSize.x / 2)) * cellSize, 0);
    }

    private void OnMove(int horizontalMovment, int verticalMovement)
    {


        Vector2 nextPlayerLocation = PlayerGridLocation + new Vector2(horizontalMovment, verticalMovement);
        Explodable explodableInDestination = cells[(int)nextPlayerLocation.y, (int)nextPlayerLocation.x];

        if (explodableInDestination != null && !explodableInDestination.Destroyed)
        {
            player.nextMove = Vector3.zero;
            return;
        }

        float deltaX = horizontalMovment * cellSize;
        float deltaY = verticalMovement * cellSize;

        player.nextMove = new Vector3(deltaX, deltaY, 0);

    }

}
