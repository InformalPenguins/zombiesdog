using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField]
    private float ttl = 5f;

    void Start()
    {
        Destroy(gameObject, ttl);
    }
}
