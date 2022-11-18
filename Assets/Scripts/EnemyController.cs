using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 FinalDestination;
    public int Health;
    public int DamageValue;
    public float DamageCooldwon;
    public float movementSpeed;
    private bool isStopped;

    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 )
        {
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null)
        {
            isStopped = false;
        }
        else
        {
            collision.gameObject.GetComponent<SquirrelController>().ReceiveDamage(DamageValue);
            yield return new WaitForSeconds(DamageCooldwon);
            StartCoroutine(Attack(collision));
        }
    }

    IEnumerator Attack2(Collider2D collision)
    {
        if (collision == null)
        {
            isStopped = false;
        }
        else
        {
            collision.gameObject.GetComponent<Tree>().ReceiveDamage(DamageValue);
            yield return new WaitForSeconds(DamageCooldwon);
            StartCoroutine(Attack(collision));
        }
    }

    public void ReceiveDamage(int Damage)
    {
        if(Health - Damage <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
            
        }
        else
        {
            Health = Health - Damage;
        }
    }
}
