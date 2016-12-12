using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningIcon : MonoBehaviour
{
    private Enemy parentEnemy;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        parentEnemy = GetComponentInParent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);

        spriteRenderer.enabled = parentEnemy.HasTargets();
    }
}
