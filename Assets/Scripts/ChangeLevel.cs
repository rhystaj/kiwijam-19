using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{

    public string Level;

    private void OnMouseDown()
    {
        Application.LoadLevel(Level);
    }
}
