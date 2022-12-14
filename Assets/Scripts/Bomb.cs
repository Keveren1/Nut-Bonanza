using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float movementSpeed;
    public int DamageValue;

    void Update()
    {
            transform.Translate(new Vector3(movementSpeed , 0, 0));   
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
