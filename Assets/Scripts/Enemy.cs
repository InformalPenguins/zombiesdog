using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float wanderSpeed = 2f;

    [SerializeField]
    private float walkSpeed = 2f;

    [SerializeField]
    private float runSpeed = 7f;

    [SerializeField]
    private float chaseDistance = 15f;

    [SerializeField]
    private float wanderRadius = 10f;

    [SerializeField]
    private float wanderTimer = 2f;

    private NavMeshAgent navMeshComponent;

    private FieldOfView fieldOfView;

    private float timer;

    void Start()
    {
        navMeshComponent = GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();
    }

    void Update()
    {
        if (fieldOfView.VisibleTargets.Count == 0)
        {
            WanderAround();
        }
        else
        {
            Transform target = fieldOfView.VisibleTargets[0];

            float distance = Vector3.Distance(target.position, transform.position);

            if (distance > chaseDistance)
            {
                Investigate(target);
            }
            else
            {
                Chase(target);
            }
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

        GetComponent<Renderer>().material.color = Color.white;
    }

    private void Investigate(Transform target)
    {
        navMeshComponent.Resume();
        navMeshComponent.SetDestination(target.position);
        navMeshComponent.speed = walkSpeed;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void Chase(Transform target)
    {
        navMeshComponent.SetDestination(target.position);
        navMeshComponent.speed = runSpeed;
        GetComponent<Renderer>().material.color = Color.red;
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 rand = Random.insideUnitSphere * wanderRadius;
        rand += transform.position;
        return rand;
    }

    public bool HasTargets()
    {
        return fieldOfView.VisibleTargets.Count > 0;
    }
}
