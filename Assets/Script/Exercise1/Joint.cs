using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    private float Rspeed = 50f;
    private bool animate = false; // rotate

    private Vector3 rotateAxis = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            transform.Rotate(Rspeed * Time.deltaTime * rotateAxis);
        }
    }

    public void setAnimate()
    {
        animate = !animate;
    }
}
