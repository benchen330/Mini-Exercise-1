using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    private float Tspeed = 0.5f;
    private float Rspeed = 100f;

    private bool animate = false;

    private bool goTop = true;
    private float originY;
    private float change = 0;

    // Start is called before the first frame update
    void Start()
    {
        originY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            if (goTop)
            {
                change += Tspeed * Time.deltaTime;
                transform.Translate(transform.up * Tspeed * Time.deltaTime, Space.World);


                //transform.Translate(0, Tspeed * Time.deltaTime, 0);
            }
            else
            {
                change -= Tspeed * Time.deltaTime;
                transform.Translate(-transform.up * Tspeed * Time.deltaTime, Space.World);


                //transform.Translate(0, -Tspeed * Time.deltaTime, 0);
            }

            //if (transform.position.y - originY >= 0.5f)
            //{
            //    goTop = false;
            //}

            //if (transform.position.y - originY <= 0)
            //{
            //    goTop = true;
            //}

            if (change >= 0.5f)
            {
                goTop = false;
            }

            if (change <= 0f)
            {
                goTop = true;
            }


        }
    }


    public void setAnimate()
    {
        animate = !animate;
    }
}
