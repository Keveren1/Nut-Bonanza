using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    public int Health;
    public int DamageValue;

    private bool dead = false;

    public UnityEvent OnDie { get; set; }

    public UnityEvent OnGetHit { get; set; }

    

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health--;
            OnGetHit.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }

    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void ReceiveDamage(int Damage)
    {
        if (Health - Damage <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
       
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(DamageValue);
            Destroy(this.gameObject);
        }
    }

}


