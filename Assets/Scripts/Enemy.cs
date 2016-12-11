using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float wanderSpeed = 0.5f;

    [SerializeField]
    private float walkSpeed = 2f;

    [SerializeField]
    private float runSpeed = 7f;

    [SerializeField]
    private float sightDistance = 10f;

    [SerializeField]
    private float chaseDistance = 5f;

    [SerializeField]
    private float wanderRadius = 10f;

    [SerializeField]
    private float wanderTimer = 2f;

    private float timer;

    [SerializeField]
    private Transform target;

    private NavMeshAgent navMeshComponent;

    void Start()
    {
        navMeshComponent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance > sightDistance)
        {
            WanderAround();
            GetComponent<Renderer>().material.color = Color.white;
        }

        if (distance < sightDistance && distance > chaseDistance)
        {
            Investigate();
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (distance < chaseDistance)
        {
            Chase();
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void WanderAround()
    {
        timer += Time.deltaTime;

        if (timer > wanderTimer)
        {
            navMeshComponent.SetDestination(GetRandomPoint());
            navMeshComponent.speed = wanderSpeed;
            timer = 0;
        }
    }

    private void Investigate()
    {
        navMeshComponent.Resume();
        navMeshComponent.SetDestination(target.position);
        navMeshComponent.speed = walkSpeed;
    }

    private void Chase()
    {
        navMeshComponent.SetDestination(target.position);
        navMeshComponent.speed = runSpeed;
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 rand = Random.insideUnitSphere * wanderRadius;
        rand += transform.position;
        return rand;
    }
}
