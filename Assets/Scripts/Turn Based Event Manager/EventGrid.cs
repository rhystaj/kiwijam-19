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

        Vector3 playerNextPostion = new Vector3(player.transform.position.x + deltaX, player.transform.position.y + deltaY,
            player.transform.position.z);

        foreach (Wall wall in GetComponentsInChildren<Wall>())
        {

            Vector3 wallDistance = playerNextPostion - wall.transform.position;

            
            if(wallDistance.x < cellSize/ 2 || wallDistance.y < cellSize/2)
            {
                player.nextMove = Vector3.zero;
                return;
            }

        }

        player.nextMove = new Vector3(deltaX, deltaY, 0);

    }

}
