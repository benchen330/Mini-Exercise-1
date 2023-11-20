using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] float speed = 3f;
    private Vector3 dir;

    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody>();

        dir = transform.forward;
        Debug.Log(dir);
        //rig.velocity = speed * dir;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        
        //transform.Translate(dir * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
