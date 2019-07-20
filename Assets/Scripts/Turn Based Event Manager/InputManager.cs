using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void InputReception();
    public static event InputReception OnInput;
    public static event InputReception OnReset;

    public delegate void DirectionInput(int verticalMovement, int horizontalMovement);
    public static event DirectionInput OnDirectionInput;

    void Update()
    {

        int verticalMovement = GetAxisDirection("Vertical");
        int horizontalMovement = GetAxisDirection("Horizontal");

        if (Input.GetKey(KeyCode.R)) {
            OnReset();
        }

        if (verticalMovement != 0 || horizontalMovement != 0)
        {

            OnDirectionInput(horizontalMovement, verticalMovement);
            OnInput();
        }

    }

    private int GetAxisDirection(string axis)
    {

        float axisValue = Input.GetAxis(axis);

        if (axisValue > 0) return 1;
        else if (axisValue < 0) return -1;
        else return 0;

    }

}
