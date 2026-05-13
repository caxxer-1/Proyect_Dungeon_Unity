using System;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] GameObject melee;
    [SerializeField] GameObject distance;
    bool meleeActive = true;
    bool distanceActive = true;
    void Start()
    {
        InputManager.Instance.OnMeleePerformed += InputManager_Melee;
        InputManager.Instance.OnDistancePerformed += InputManager_DistanceShot;
    }
    void InputManager_Melee(object sender, EventArgs e)
    {
        meleeActive = !meleeActive;
        melee.SetActive(meleeActive);
    }
    void InputManager_DistanceShot(object sender, EventArgs e)
    {
        distanceActive = !distanceActive;
        distance.SetActive(distanceActive);
    }
}
