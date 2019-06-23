using System;
using UnityEngine;
using UnityEngine.UI;

public class GroundPlacementController : MonoBehaviour
{
    public WorldSystem worldScript;

    public GameObject prefab;
    public int price;
    public GoldLogic goldScript;

    public GameObject currentObject;

    public GameObject hoverObject;
    public string hoverName;

    public bool placeCalled;
    public bool hasSpawned;
    public bool placeRoadCalled;
    public bool flattenCalled;

    public int houses;
    public HouseLogic houseScript;
    public int houseCapacity;

    public bool canPlace;
    public bool canFlatten;

    public TabsLogic tabsScript;

    public int treeFlattenPrice;

    public GameObject road;
    public GameObject cornerRoad;
    public GameObject threeWayRoad;
    public GameObject fourCornerRoad;

    public RoadLogic roadScript;


    private void Start()
    {
        houses = 0;

        treeFlattenPrice = 50;
    }

    void Update()
    {
        if (placeCalled == true)
        {
            Place();
        }
        else if (placeCalled == false)
        {
            if (flattenCalled == true)
            {
                Flatten();
            }
            else if (placeRoadCalled == true)
            {
                PlaceRoad();
            }
            else
            {
                hoverName = "";
                hoverObject = null;
                ObjectUI();
            }

        }

        worldScript.houses = houses;


    }

    public void Place()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (hasSpawned == false)
        {
            currentObject = Instantiate(prefab);
            hasSpawned = true;
        }

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            hoverObject = GameObject.Find(hit.transform.name);
            hoverName = hit.transform.name;

            if (hoverObject.tag == "Ground")
            {
                int i = System.Convert.ToInt32(hit.transform.name);
                if (worldScript.objects[i] == "Empty")
                {
                    canPlace = true;
                }
                else
                {
                    canPlace = false;
                }
            }
            else
            {
                canPlace = false;
            }


            currentObject.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.792f, hit.transform.position.z);



        }
        else
        {
            hoverName = "";
            hoverObject = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (canPlace == true)
                {

                    int i = System.Convert.ToInt32(hit.transform.name);
                    Debug.Log(i);

                    worldScript.objects[i] = prefab.name;

                    if (currentObject.tag == "Build")
                    {
                        houseScript = currentObject.GetComponent<HouseLogic>();
                        houseScript.houseNumber = i;
                        houseScript.capacity = houseCapacity;
                        houses++;

                        currentObject.name = prefab.name;



                        worldScript.Xpositions[i] = currentObject.transform.position.x;
                        worldScript.Ypositions[i] = currentObject.transform.position.y;
                        worldScript.Zpositions[i] = currentObject.transform.position.z;
                    }

                    if (currentObject.name == "flat2grey(Clone)")
                    {
                        currentObject.transform.SetPositionAndRotation(new Vector3(currentObject.transform.position.x - 0.216f, currentObject.transform.position.y - 0.052f, currentObject.transform.position.z - 0.312f), currentObject.transform.rotation);
                    }


                    goldScript.gold -= price;
                }

            }

            placeCalled = false;
            hasSpawned = false;
        }
    }

    public void ObjectUI()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (hit.transform.tag == "Build")
                {
                    houseScript = hit.transform.GetComponent<HouseLogic>();
                    tabsScript.ShowHouseUI(houseScript);
                }
            }



        }
    }

    public void Flatten()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            hoverObject = GameObject.Find(hit.transform.name);
            hoverName = hit.transform.name;

            if (hoverObject.tag == "Ground")
            {
                int i = System.Convert.ToInt32(hit.transform.name);
                if (worldScript.objects[i] == "tree" || worldScript.objects[i] == "tree1" || worldScript.objects[i] == "tree2")
                {
                    canFlatten = true;
                }
                else if (worldScript.objects[i] == "Empty")
                {
                    canFlatten = true;
                }
                else
                {
                    canFlatten = false;
                }
            }
            else
            {
                canFlatten = false;
            }


        }
        else
        {
            hoverName = "";
            hoverObject = null;
        }

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (canFlatten == true)
                {

                    int i = System.Convert.ToInt32(hit.transform.name);

                    if (worldScript.objects[i] == "tree" || worldScript.objects[i] == "tree1" || worldScript.objects[i] == "tree2")
                    {
                        if (goldScript.gold - treeFlattenPrice >= 0)
                        {
                            GameObject target = GameObject.Find("Tree" + i);
                            Destroy(target);
                            worldScript.objects[i] = "Empty";
                            goldScript.gold -= treeFlattenPrice;
                        }

                    }



                }

            }

        }
    }

    public void PlaceRoad()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            hoverObject = GameObject.Find(hit.transform.name);
            hoverName = hit.transform.name;

            if (hoverObject.tag == "Ground")
            {
                int i = System.Convert.ToInt32(hit.transform.name);
                if (worldScript.objects[i] == "Empty")
                {
                    canPlace = true;
                }
                else
                {
                    canPlace = false;
                }
            }
            else
            {
                canPlace = false;
            }


        }
        else
        {
            hoverName = "";
            hoverObject = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (canPlace == true)
                {
                    transform.SetPositionAndRotation(new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5030645f, hit.transform.position.z), transform.rotation);

                    int i = System.Convert.ToInt32(hit.transform.name);
                    Debug.Log(i);
                    worldScript.Xpositions[i] = transform.position.x;
                    worldScript.Ypositions[i] = transform.position.y;
                    worldScript.Zpositions[i] = transform.position.z;


                    currentObject = Instantiate(prefab);
                    worldScript.objects[i] = prefab.name;
                    currentObject.transform.SetPositionAndRotation(transform.position, transform.rotation);

                    currentObject.name = "Road" + i;




                }

            }

        }
    }

}