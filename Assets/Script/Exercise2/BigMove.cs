using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMove : MonoBehaviour
{
    private Rigidbody rig;
    public float speed = 3f;
    float horizontalMove;
    float verticalMove;

    [SerializeField] GameObject bullet = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();

        //InvokeRepeating("Attack", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        //Move2();
    }

    private void FixedUpdate()
    {
        Move1();
    }

    void Move1()
    {
        rig.velocity =
               new Vector3(horizontalMove * speed, 0, verticalMove * speed);
    }

    void Move2()
    {
        // up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        // down
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        // right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        // left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }

    private void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 90, 0));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 180, 0));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, -90, 0));
    }
}


