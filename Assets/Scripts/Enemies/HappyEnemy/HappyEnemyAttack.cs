using System;
using UnityEngine;

public class HappyEnemyAttack : MonoBehaviour
{
    HappyEnemy happyEnemy;
    bool attacking = false;
    void Start()
    {
        happyEnemy = GetComponent<HappyEnemy>();
        happyEnemy.OnAttackStateCurrent += HappyEnemy_Attack;
        happyEnemy.OnAttackStateStopped += HappyEnemy_StopAttack;
    }
    void Update()
    {
        if (!attacking) return;
    }
    void HappyEnemy_Attack(object sender, EventArgs e)
    {
        attacking = true;
    }
    void HappyEnemy_StopAttack(object sender, EventArgs e)
    {
        attacking = false;
    }
}
