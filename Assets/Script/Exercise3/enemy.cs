using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rig;
    [SerializeField] GameObject target;
    [SerializeField] GameObject bullet;

    private bool toAttack = false;
    [SerializeField] float radius = 3;
    [SerializeField] float angle;

    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstructionMask;

    [SerializeField] attackRange mAttackRange;

    private bool notCooldown = true;
    [SerializeField] float cooldownTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();

        mAttackRange.OnRangeStay += CheckToAttack;
        mAttackRange.OnRangeOut += ToChase;
    }


    // Update is called once per frame
    void Update()
    {
        //if (CheckInRange())
        //{
        //    agent.SetDestination(transform.position);
        //    if (notCooldown)
        //    {
        //        notCooldown = false;
        //        Attack();
        //    }
        //}
        //else
        //{
        //    Move();
        //}

        
        if (toAttack)
        {
            //agent.SetDestination(transform.position);
            agent.speed = 0;
            FaceTarget(target.transform.position);
            //agent.updatePosition = false;
            //agent.updateRotation = false;
            if (notCooldown)
            {
                notCooldown = false;
                Attack();
            }
        }
        else
        {
            agent.speed = 3.5f;
            //agent.updatePosition = true;
            //agent.updateRotation = true;
            Move();
        }
    }

    private void Move()
    {
        agent.SetDestination(target.transform.position);
    }

    private void Attack()
    {
        GameObject mBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        mBullet.GetComponent<bulletChase>().setTarget(target);
        Invoke("Cooldown", cooldownTime);
    }

    private void Cooldown()
    {
        notCooldown = true;
    }

    private bool CheckInRange()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = target.transform.position;
        Vector3 v = p2 - p1;

        if (v.magnitude < radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckToAttack(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 p1 = transform.position;
            Vector3 p2 = target.transform.position;

            Vector3 dir = (p2 - p1).normalized;

            RaycastHit hit;
            bool hasHitObstacle = Physics.Raycast(p1, dir, out hit, Vector3.Distance(p1, p2), obstructionMask);

            if (hasHitObstacle)
            {
                toAttack = false;
                Debug.Log("ray hit obstacle");
            }
            else
            {
                toAttack = true;
            }
        }
        
    }

    private void ToChase(Collider other)
    {
        toAttack = false;
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        rig.velocity = Vector3.zero;
    }
}
