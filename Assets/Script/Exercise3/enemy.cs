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


    private bool inRange = false;
    [SerializeField] float radius = 3;

    private bool notCooldown = true;
    [SerializeField] float cooldownTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckInRange())
        {
            agent.SetDestination(transform.position);
            if (notCooldown)
            {
                notCooldown = false;
                Attack();
            }
        }
        else
        {
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

    private void OnCollisionExit(Collision collision)
    {
        rig.velocity = Vector3.zero;
    }
}
