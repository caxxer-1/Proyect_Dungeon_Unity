using System;
using System.Collections;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    PlayerStatesManager playerStatesManager;
    [SerializeField] GameObject sword;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject grenade;
    GameObject[] items;
    void Start()
    {
        InputManager.Instance.OnSwitchItemPerformed += InputManager_SwitchItem;
        playerStatesManager = GetComponent<PlayerStatesManager>();
        items = new GameObject[] {sword, axe, grenade};
        foreach (GameObject item in items) item.SetActive(false);
    }
    void InputManager_SwitchItem(object sender, EventArgs e)
    {
        StartCoroutine(OffsetForStateManager());
    }
    IEnumerator OffsetForStateManager()
    {
        yield return new WaitForSeconds(.01f);
        foreach (GameObject item in items) item.SetActive(false);
        switch (playerStatesManager.GetPlayerInventoryState())
        {
            case PlayerStatesManager.PlayerInventoryState.Sword:
                items[0].SetActive(true);
            break;
            case PlayerStatesManager.PlayerInventoryState.Axe:
                items[1].SetActive(true);
            break;
            case PlayerStatesManager.PlayerInventoryState.Grenade:
                items[2].SetActive(true);
            break;
        }
    }
}
