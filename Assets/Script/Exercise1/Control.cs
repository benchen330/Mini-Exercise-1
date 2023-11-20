using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public bool topAnimate = false;
    public bool middleAnimate = false;
    public bool buttomAnimate = false;

    [SerializeField] GameObject top = null;
    [SerializeField] GameObject middle1= null;
    [SerializeField] GameObject middle2 = null;
    [SerializeField] GameObject middle3 = null;
    [SerializeField] GameObject buttom = null;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // input 1 -> on/off top
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //topAnimate = !topAnimate;
            top.GetComponent<Top>().setAnimate();
        }

        // input 2 -> on/off middle
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //middleAnimate = !middleAnimate;
            middle1.GetComponent<Middle>().setAnimate();
            middle2.GetComponent<Middle>().setAnimate();
            middle3.GetComponent<Middle>().setAnimate();
        }

        // input 3 -> switch middle rotate direction
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //middleAnimate = !middleAnimate;
            middle1.GetComponent<Middle>().setDirection();
            middle2.GetComponent<Middle>().setDirection();
            middle3.GetComponent<Middle>().setDirection();
        }

        // input 4 -> on/off buttom rotate
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //buttomAnimate = !buttomAnimate;
            buttom.GetComponent<Buttom>().setAnimate1();
        }

        // input 5 -> switch buttom rotate direction
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //buttomAnimate = !buttomAnimate;
            buttom.GetComponent<Buttom>().setDirection();
        }

        // input 6 -> on/off buttom translate
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //buttomAnimate = !buttomAnimate;
            buttom.GetComponent<Buttom>().setAnimate2();
        }


        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //buttomAnimate = !buttomAnimate;
            middle3.GetComponent<Joint>().setAnimate();
        }
    }

    public bool getTop()
    {
        return topAnimate;
    }

    public bool getMiddle()
    {
        return middleAnimate;
    }

    public bool getButtom()
    {
        return buttomAnimate;
    }
}
