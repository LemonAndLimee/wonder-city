using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;

    public NavMeshSurface surface;
    public GameObject cube;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButton(0))
            {
                agent.SetDestination(hit.point);
            }

        }
        if (Input.GetKeyDown("e"))
        {
            GameObject obj =  Instantiate(cube);
        }

        surface.BuildNavMesh();
    }
}
