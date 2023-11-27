using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rig;
    public float speed = 3f;
    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
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
}
