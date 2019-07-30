using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public int travel;
    public int scrollSpeed = 2;

    private void Update()
    {
        Zoom();
        
    }

    public void Zoom()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f && travel > -8)
        {
            if (transform.position.y > 1)
            {
                travel = travel - scrollSpeed;
                Camera.main.transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
            }
        }
        else if (d < 0f && travel < 8)
        {
            travel = travel + scrollSpeed;
            Camera.main.transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
            
        }
    }
}