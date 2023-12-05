using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRange : MonoBehaviour
{
    public Action<Collider> OnRangeIn;
    public Action<Collider> OnRangeStay;
    public Action<Collider> OnRangeOut;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OnRangeIn?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnRangeStay?.Invoke(other);
        Debug.Log("stay");
    }

    private void OnTriggerExit(Collider other)
    {
        OnRangeOut?.Invoke(other);
        Debug.Log("exit");
    }
}
