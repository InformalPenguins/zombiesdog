using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private Light shootLight;

    public GameObject Bullet
    {
        get
        {
            return bullet;
        }
        set
        {
            bullet = value;
        }
    }

    private void Start()
    {
        shootLight = GetComponentInChildren<Light>();
    }

    private void LateUpdate()
    {
        if (shootLight.enabled)
        {
            StartCoroutine(DisableShootLight());
        }
    }

    private IEnumerator DisableShootLight()
    {
        yield return new WaitForSeconds(0.05f);
        shootLight.enabled = false;
    }
}
