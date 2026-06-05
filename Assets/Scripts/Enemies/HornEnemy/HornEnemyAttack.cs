using System;
using UnityEngine;

public class HornEnemyAttack : MonoBehaviour
{
    HornEnemy hornEnemy;
    bool attacking = false;
    void Start()
    {
        hornEnemy = GetComponent<HornEnemy>();
        hornEnemy.OnAttackStateCurrent += HornEnemy_Attack;
        hornEnemy.OnAttackStateStopped += HornEnemy_StopAttack;
    }
    void Update()
    {
        if (!attacking) return;
    }
    void HornEnemy_Attack(object sender, EventArgs e)
    {
        attacking = true;
    }
    void HornEnemy_StopAttack(object sender, EventArgs e)
    {
        attacking = false;
    }
}
