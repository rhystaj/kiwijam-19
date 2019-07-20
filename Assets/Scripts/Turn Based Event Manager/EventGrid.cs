using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGrid : MonoBehaviour
{

    [SerializeField] int cellSize;

    [SerializeField] Player player;

    private void OnEnable()
    {
        InputManager.OnDirectionInput += OnMove;
    }

    private void OnDisable()
    {
        InputManager.OnDirectionInput -= OnMove;
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(int horizontalMovment, int verticalMovement)
    {

        int deltaX = cellSize * verticalMovement;
        int deltaY = cellSize * horizontalMovment;

        player.nextMove = new Vector3(deltaX, deltaY, 0);

    }

}
