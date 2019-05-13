using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseLogic : MonoBehaviour
{
    public WorldSystem worldScript;
    public GroundPlacementController placementScript;

    public int houseNumber;

    public int capacity;
    public int residents;

    public int specificResidentHappiness;

    public BoxCollider houseCollider;


    // Start is called before the first frame update
    void Start()
    {
        worldScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldSystem>();
        placementScript = GameObject.Find("PlacementManager").GetComponent<GroundPlacementController>();

        residents = capacity;
        specificResidentHappiness = 100;

        houseCollider = gameObject.GetComponent<BoxCollider>();
        houseCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        worldScript.residents[houseNumber] = residents;

        if (placementScript.flattenCalled == true || placementScript.placeRoadCalled == true)
        {
            houseCollider.enabled = false;
        }
        else
        {
            houseCollider.enabled = true;
        }

    }


}
