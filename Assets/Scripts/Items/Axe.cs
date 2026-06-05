using System;
using UnityEngine;

public class Axe : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.OnMainButtonPerformed += InputManager_AxeAttack;
    }
    void InputManager_AxeAttack(object sender, EventArgs e)
    {
        
    }
}
