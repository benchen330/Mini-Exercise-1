using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] float speed;
    [SerializeField] GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.y = 0;
        dir = dir.normalized;
        rig.velocity =
            dir * speed;
    }
}
