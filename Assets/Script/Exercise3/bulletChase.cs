using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletChase : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed = 3.5f;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        setDirection();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void setDirection()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = target.transform.position;
        Vector3 v = p2 - p1;

        v.y = 0;
        dir = v.normalized;
    }
}
