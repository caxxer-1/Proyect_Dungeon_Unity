using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.OnMainButtonPerformed += InputManager_SwordAttack;
    }
    void InputManager_SwordAttack(object sender, EventArgs e)
    {
        
    }
}
