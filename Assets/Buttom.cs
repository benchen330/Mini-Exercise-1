using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    private float Tspeed = 1f;
    private float Rspeed = 50f;


    private bool animate1 = false; // rotate
    private bool animate2 = false; // traslate
    private int direction = 1;

    private bool goRight = false;
    private float originX;
    private float change = 0;

    private Vector3 rotateAxis = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        originX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (animate1)
        {
            transform.RotateAround(transform.position, rotateAxis, Rspeed * Time.deltaTime * direction);
        }

        if (animate2)
        {
            if (goRight)
            {
                change += Tspeed * Time.deltaTime;
                transform.Translate(transform.right * Tspeed * Time.deltaTime, Space.World);

                //transform.Translate(Tspeed * Time.deltaTime, 0, 0, Space.World);
            }
            else
            {
                change -= Tspeed * Time.deltaTime;
                transform.Translate(-transform.right * Tspeed * Time.deltaTime, Space.World);

                //transform.Translate(-Tspeed * Time.deltaTime, 0, 0, Space.World);
            }

            //if (transform.position.x - originX >= 1)
            //{
            //    goRight = false;
            //}

            //if (transform.position.x - originX <= -1)
            //{
            //    goRight = true;
            //}

            if (change >= 1f)
            {
                goRight = false;
            }

            if (change <= -1f)
            {
                goRight = true;
            }
        }
    }



    public void setAnimate1()
    {
        animate1 = !animate1;
    }

    public void setAnimate2()
    {
        animate2 = !animate2;
    }

    public void setDirection()
    {
        direction *= -1;
    }
}
