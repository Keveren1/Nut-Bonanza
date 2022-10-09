using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;
    [SerializeField]
    protected float currentVelocity = 3;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 movementImput)
    {
        rigidbody2d.velocity = movementImput.normalized * currentVelocity;
    }

    public void Jump(Vector2 jumpImput){
        rigidbody2d.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
}
