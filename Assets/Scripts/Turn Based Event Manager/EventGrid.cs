using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGrid : MonoBehaviour
{

    [SerializeField] int cellSize;

    [SerializeField] MonoBehaviour player;

    private void OnEnable()
    {
        InputManager.OnDirectionInput += OnMove;
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
        
    }

}
