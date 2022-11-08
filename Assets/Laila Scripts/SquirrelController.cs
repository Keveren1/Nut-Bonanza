using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    public int Health;
    public GameObject bomb; 
    public List<GameObject> enemies;
    public GameObject toAttack;
    public float attackCooldown;
    private float attackTime;
    public int DamageValue;
    public bool isAttacking;

    private void Update()
    {
        if (enemies.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
        }
        else if (enemies.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }

        if (isAttacking)
        {
            if (attackTime <= Time.time)
            {
                GameObject bombInstance = Instantiate(bomb, transform);
                bombInstance.GetComponent<Bomb>().DamageValue = DamageValue;
                attackTime = Time.time + attackCooldown;
            }
        }
    }
    public void ReceiveDamage(int Damage)
    {
        if (Health - Damage <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Health = Health - Damage;
        }
    }
}
