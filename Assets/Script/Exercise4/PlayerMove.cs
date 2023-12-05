using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] GameObject destinationPrefab;
    private Transform targetPos;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();

        //GetPath();
        InitLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickToMove();
        }

        if (agent.hasPath)
        {
            DrawPath();
        }
    }

    private void ClickToMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            SetDestination(hit.point);
        }
    }

    private void SetDestination(Vector3 target)
    {
        agent.SetDestination(target);
    }

    void DrawPath()
    {
        line.positionCount = agent.path.corners.Length;
        line.SetPosition(0, transform.position);
        if (agent.path.corners.Length < 2)
        {
            return;
        }
        
        for(int i=1;i< agent.path.corners.Length; ++i)
        {
            Vector3 positionPoint = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            line.SetPosition(i, positionPoint);
        }

        //Debug.Log(path.corners.Length);
        //line.SetPositions(path.corners);
    }

    private void GetPath()
    {
        line.SetPosition(0, transform.position);
    }

    private void InitLine()
    {
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.positionCount = 0;
    }
}
