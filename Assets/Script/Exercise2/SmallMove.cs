using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMove : MonoBehaviour
{
    private Rigidbody rig;

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
        //Stop();
    }

    void Stop()
    {
        rig.velocity = Vector3.zero;
    }

    private void OnCollisionExit(Collision collision)
    {
        rig.velocity = Vector3.zero;
    }

}
