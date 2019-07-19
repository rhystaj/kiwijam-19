using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void InputReception();
    public static event InputReception OnInput;

    public delegate void DirectionInput(int verticalMovement, int horizontalMovement);
    public static event DirectionInput OnDirectionInput;

    void Update()
    {

        int verticalMovement = (int)Input.GetAxis("Vertical");
        int horizontalMovement = (int)Input.GetAxis("Horizontal");

        if (verticalMovement != 0 && horizontalMovement != 0)
            OnDirectionInput(verticalMovement, horizontalMovement);

        OnInput();

    }

}
