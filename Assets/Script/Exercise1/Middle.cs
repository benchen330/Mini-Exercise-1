using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    //private float speed = 100f;
    private float speed = 50f;


    private bool animate = false;
    private int direction = 1;

    [SerializeField] GameObject buttom = null;
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
            transform.RotateAround(buttom.transform.position, buttom.transform.right, speed * Time.deltaTime * direction);
            //transform.RotateAround(buttom.transform.position, rotateAxis, speed * Time.deltaTime * direction);
            //transform.RotateAround(buttom.transform.position, rotateAxis, speed);
        }
    }



    public void setAnimate()
    {
        animate = !animate;
    }

    public void setDirection()
    {
        direction *= -1;
    }
}
