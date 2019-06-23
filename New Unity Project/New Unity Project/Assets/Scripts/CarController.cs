using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CarController : MonoBehaviour
{
    public bool upwards;
    public int rows;
    public Material redMaterial;
    public Material blueMaterial;
    public Material[] materials;

    private void Start()
    {
        Renderer ren = gameObject.GetComponent<Renderer>();
        materials = ren.materials;
        int ran = Random.Range(1, 3);
        if (ran == 1)
        {
            materials[0] = redMaterial;
        }
        else if (ran == 2)
        {
            materials[0] = blueMaterial;
        }

        ren.materials = materials;
    }

    void FixedUpdate()
    {
        if (upwards == true)
        {
            DriveUp();
        }
        else
        {
            DriveDown();
        }
    }

    public void DriveUp()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + (2f * Time.deltaTime)
        );

        if (transform.position.z >= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DriveDown()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - (2f * Time.deltaTime)
        );

        if (transform.position.z <= -rows)
        {
            Destroy(gameObject);
        }
    }
}
