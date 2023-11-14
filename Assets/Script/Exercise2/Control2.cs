using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control2 : MonoBehaviour
{
    [SerializeField] GameObject ball;
    Vector3 startPos;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        pos = startPos;

        for (int i = 0; i < 11; ++i)
        {

            pos.x = startPos.x + i;
            for(int j = 0; j < 11; ++j)
            {
                pos.z = startPos.z + j;
                Instantiate(ball, pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
