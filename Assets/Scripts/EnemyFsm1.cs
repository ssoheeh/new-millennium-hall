using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFsm1 : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public EnemyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    private NavMeshAgent agent;
    public float lastShootTime;
    public GameObject bulletPrefab;
    public float fireRate;
    public bool gobase = false;
    public float lastDetectionTime;


    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;


            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 180, 0));
        }
    }
    void ShootBase()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;


            Instantiate(bulletPrefab,transform.position, Quaternion.Euler(0, 40, 0));
        }
    }

    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    private void Awake()
    {
        baseTransform = GameObject.Find("PlayerBase").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer)
        {
            //StartCoroutine(ChasePlayer());
            ChasePlayer();

        }
        else
        {
            AttackPlayer();
        }
    }

    void GoToBase()
    {

        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        ShootBase();
        //print("AttackBase");
    }

    void ChasePlayer()
    {
        agent.isStopped = false;

        if (sightSensor.detectedObject == null)
        {
            // sightSensor.detectedObject가 null이면서 10초가 지났을 때
            if (Time.time - lastDetectionTime > 10f)
            {
                currentState = EnemyState.GoToBase;
                return;
            }
            print("ChasePlayer - Object is null");
        }
        else
        {
            // sightSensor.detectedObject가 있을 때
            lastDetectionTime = Time.time; // 감지된 시간 업데이트
            agent.SetDestination(sightSensor.detectedObject.transform.position);

            float distanceToPlayer = Vector3.Distance(transform.position,
                sightSensor.detectedObject.transform.position);

            if (distanceToPlayer < playerAttackDistance)
            {
                currentState = EnemyState.AttackPlayer;
            }
            print("ChasePlayer - Object is detected");
        }
    }

    void AttackPlayer()
    {
        agent.isStopped = true;

        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();


        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }

    }

}
