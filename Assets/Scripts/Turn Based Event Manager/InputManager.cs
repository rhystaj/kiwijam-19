using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void InputReception();
    public static event InputReception OnInput;
    public static event InputReception OnReset;

    public delegate bool DirectionInput(int verticalMovement, int horizontalMovement);
    public static event DirectionInput OnDirectionInput;

    private bool blockInput;

    void Update()
    {


        

        int verticalMovement = 0;
        int horizontalMovement = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow)) verticalMovement = 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) verticalMovement = -1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) horizontalMovement = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) horizontalMovement = 1;

        if (Input.GetKeyDown(KeyCode.R)) {
            OnReset();
            blockInput = true;
        }

        if (verticalMovement != 0 || horizontalMovement != 0)
        {

            blockInput = true;

            if(OnDirectionInput(horizontalMovement, verticalMovement))
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
