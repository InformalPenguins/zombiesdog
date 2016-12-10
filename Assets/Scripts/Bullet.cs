using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float ttl = 5f;

    [SerializeField]
    private float movementSpeed = 50f;

    [SerializeField]
    private Transform onDestroyEmitter;

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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 8: // terrain
            case 9: // buildings
                DestroyWithEmitter();
                break;
        }
    }

    private void DestroyWithEmitter()
    {
        Instantiate(onDestroyEmitter, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
