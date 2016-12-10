using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float sightDistance;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 2f, transform.forward, out hit, sightDistance))
        {
            if (hit.transform.tag == "Player")
            {
                GetComponent<Renderer>().material.color = new Color(100f, 100f, 100f);
                Debug.Log("hit " + hit.transform.gameObject.name);
                Debug.DrawRay(new Vector3(transform.position.x, 2f, transform.position.z), hit.transform.localPosition, Color.cyan);
            }
        }
    }


    // Update is called once per frame
    //void Update()
    //{
    //    RaycastHit[] hits;
    //    hits = Physics.SphereCastAll(transform.position, sightDistance, transform.forward);

    //    for (int i = 0; i < hits.Length; i++)
    //    {
    //        RaycastHit hit = hits[i];
    //        Debug.Log("hit " + hit.transform.gameObject.name);

    //        Debug.DrawRay(transform.position, hit.transform.position, Color.cyan);
    //    }
    //}
}
