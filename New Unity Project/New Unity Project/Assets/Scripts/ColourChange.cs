using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public Material hover;
    public Material hoverRed;
    public Material def;

    public MeshRenderer meshRenderer;
    public string objName;

    public GroundPlacementController placeScript;

    
    // Start is called before the first frame update
    void Start()
    {
        objName = transform.name;
        meshRenderer = GetComponent<MeshRenderer>();
        placeScript = GameObject.Find("PlacementManager").GetComponent<GroundPlacementController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (placeScript.placeCalled == true)
        {
            if (objName == placeScript.hoverName)
            {
                if (placeScript.canPlace == true)
                {
                    meshRenderer.material = hover;
                }
                else
                {
                    meshRenderer.material = hoverRed;
                }

            }
            else
            {
                meshRenderer.material = def;
            }
        }

        else if (placeScript.flattenCalled == true)
        {
            if (objName == placeScript.hoverName)
            {
                if (placeScript.canFlatten == true)
                {
                    meshRenderer.material = hover;
                }
                else
                {
                    meshRenderer.material = hoverRed;
                }
            }
            else
            {
                meshRenderer.material = def;
            }
        }
        else if (placeScript.placeRoadCalled == true)
        {
            if (objName == placeScript.hoverName)
            {
                if (placeScript.canPlace == true)
                {
                    meshRenderer.material = hover;
                }
                else
                {
                    meshRenderer.material = hoverRed;
                }

            }
            else
            {
                meshRenderer.material = def;
            }
        }
        else
        {
            meshRenderer.material = def;
        }

    }


}
