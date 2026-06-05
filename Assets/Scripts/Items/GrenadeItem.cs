using System;
using UnityEngine;

public class GrenadeItem : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.OnMainButtonPerformed += InputManager_ThrowGrenade;
    }
    void InputManager_ThrowGrenade(object sender, EventArgs e)
    {
        
    }
}
