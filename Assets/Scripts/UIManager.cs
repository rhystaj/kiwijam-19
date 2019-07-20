using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Text failStateText;

    public void ShowFailStateScreen()
    {
        failStateText.enabled = true;
    }

    public void HideFailStateScreen()
    {
        failStateText.enabled = false;
    }


}
