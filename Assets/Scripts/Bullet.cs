using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float ttl = 5f;

    [SerializeField]
    private float movementSpeed = 50f;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
            movementSpeed = value;
        }
    }

    void Start()
    {
        Destroy(gameObject, ttl);
    }
}
