using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject highwayGround;
    public GameObject highwayRoad;
    public GameObject highwayRoadHorizontal;
    public GameObject highwayRoadJunction;

    public GameObject ground;
    public int rows;
    public int columns;
    public Vector3 groundPos;
    public Vector3 lastGroundPos;
    public int groundCount;

    public SimpleMouseRotator mouseRotatorScript;

    public bool saveExists = false;

    public GameObject[] existingHouses;
    public GameObject[] existingRoads;
    public GameObject[] existingTerrain;

    public GameObject prefab;
    public GameObject currentObject;

    public GameObject House1;
    public GameObject House2;

    public GameObject terrainPrefab;
    public GameObject tree;
    public GameObject tree1;
    public GameObject tree2;

    public GameObject road;
    public GameObject roadVertical;
    public GameObject cornerRoad;
    public GameObject cornerRoadLeftBottom;
    public GameObject cornerRoadRightTop;
    public GameObject cornerRoadRightBottom;
    public GameObject threeWayRoad;
    public GameObject threeWayRoadLeft;
    public GameObject threeWayRoadUpwards;
    public GameObject threeWayRoadDown;
    public GameObject fourCornerRoad;

    public RoadLogic roadScript;

    public WorldSystem worldScript;
    public GoldLogic goldScript;
    public PopulationLogic populationScript;

    public GroundPlacementController placementScript;

    public bool gameStarted = false;

    public float timer;

    public int houseCapacity;

    public void SaveWorld()
    {
        SaveLogic.SaveWorld(worldScript);
    }

    public void LoadWorld()
    {
        WorldData data = SaveLogic.LoadWorld();

        worldScript.objects = data.objects;
        worldScript.Xpositions = data.Xpositions;
        worldScript.Ypositions = data.Ypositions;
        worldScript.Zpositions = data.Zpositions;

        goldScript.gold = data.gold;
        populationScript.population = data.population;
        populationScript.residentHappiness = data.residenthappiness;

        placementScript.houses = data.houses;

        worldScript.residents = data.residents;

        existingHouses = GameObject.FindGameObjectsWithTag("Build");

        for (int i = 0; i < existingHouses.Length; i++)
        {
            Destroy(existingHouses[i]);
        }
        existingRoads = GameObject.FindGameObjectsWithTag("Road");

        for (int i = 0; i < existingRoads.Length; i++)
        {
            Destroy(existingRoads[i]);
        }
        existingTerrain = GameObject.FindGameObjectsWithTag("Terrain");

        for (int i = 0; i < existingHouses.Length; i++)
        {
            Destroy(existingTerrain[i]);
        }

        for (int i = 0; i < worldScript.objects.Length; i++)
        {
            if (data.objects[i] == "House1")
            {
                prefab = House1;
                houseCapacity = 5;
            }
            else if (data.objects[i] == "House2")
            {
                prefab = House2;
                houseCapacity = 8;
            }
            else if (data.objects[i] == "tree")
            {
                prefab = tree;
            }
            else if (data.objects[i] == "tree1")
            {
                prefab = tree1;
            }
            else if (data.objects[i] == "tree2")
            {
                prefab = tree2;
            }
            else if (data.objects[i] == "road")
            {
                prefab = road;
            }
            else if (data.objects[i] == "cornerRoad")
            {
                prefab = cornerRoad;
            }
            else if (data.objects[i] == "cornerRoadLeftBottom")
            {
                prefab = cornerRoadLeftBottom;
            }
            else if (data.objects[i] == "cornerRoadRightTop")
            {
                prefab = cornerRoadRightTop;
            }
            else if (data.objects[i] == "cornerRoadRightBottom")
            {
                prefab = cornerRoadRightBottom;
            }
            else if (data.objects[i] == "3wayRoad")
            {
                prefab = threeWayRoad;
            }
            else if (data.objects[i] == "3wayRoadLeft")
            {
                prefab = threeWayRoadLeft;
            }
            else if (data.objects[i] == "3wayRoadUpwards")
            {
                prefab = threeWayRoadUpwards;
            }
            else if (data.objects[i] == "3wayRoadDown")
            {
                prefab = threeWayRoadDown;
            }
            else if (data.objects[i] == "4cornerRoad")
            {
                prefab = fourCornerRoad;
            }
            else if (data.objects[i] == "roadVertical")
            {
                prefab = roadVertical;
            }
            else
            {
                prefab = null;
            }

            if (prefab != null)
            {
                currentObject = Instantiate(prefab);
                currentObject.transform.SetPositionAndRotation(new Vector3(data.Xpositions[i], data.Ypositions[i], data.Zpositions[i]), currentObject.transform.rotation);
                if (prefab == House1 || prefab == House2)
                {
                    HouseLogic houseScript = currentObject.GetComponent<HouseLogic>();
                    houseScript.capacity = houseCapacity;
                    houseScript.houseNumber = i;
                }
                if (prefab.tag == "Road")
                {
                    currentObject.name = "Road" + i;
                }
                if (currentObject.tag == "Terrain")
                {
                    currentObject.name = "Tree" + i;
                }

            }

        }
    }

    void Start()
    {
        groundCount = 0;

        WorldData data = SaveLogic.LoadWorld();

        saveExists = data.savedGame;

        mouseRotatorScript.enabled = false;

        GroundBuild();
        HighwayBuild();
    }

    void Update()
    {
        if (gameStarted == true)
        {
            timer += Time.deltaTime;

            if (timer >= 5)
            {
                SaveWorld();
                timer = 0;

            }
        }

        if (Input.GetMouseButton(1))
        {
            mouseRotatorScript.enabled = true;
        }
        else
        {
            mouseRotatorScript.enabled = false;
        }


    }

    public void TerrainBuild()
    {
        for (int i = 0; i < worldScript.objects.Length; i++)
        {
            int number = Random.Range(1, 8);
            if (number == 3)
            {
                number = Random.Range(1, 4);
                if (number == 1)
                {
                    terrainPrefab = tree;
                }
                if (number == 2)
                {
                    terrainPrefab = tree1;
                }
                if (number == 3)
                {
                    terrainPrefab = tree2;
                }

                GameObject[] groundPieces = GameObject.FindGameObjectsWithTag("Ground");
                Vector3 pos = groundPieces[i].transform.position;

                currentObject = Instantiate(terrainPrefab);
                currentObject.transform.SetPositionAndRotation(new Vector3(pos.x, currentObject.transform.position.y, pos.z), transform.rotation);

                worldScript.Xpositions[i] = currentObject.transform.position.x;
                worldScript.Ypositions[i] = currentObject.transform.position.y;
                worldScript.Zpositions[i] = currentObject.transform.position.z;
                worldScript.objects[i] = terrainPrefab.name;

                TreeLogic treeScript = currentObject.GetComponent<TreeLogic>();
                treeScript.treeNumber = i;

                currentObject.name = "Tree" + treeScript.treeNumber;
            }
        }
    }
    
    public void GroundBuild()
    {
        for (int r = 0; r < rows; r++)
        {
            lastGroundPos.x = 0;
            groundPos.z = lastGroundPos.z - 1;
            for (int c = 0; c < columns; c++)
            {
                groundPos.x = lastGroundPos.x + 1;

                currentObject = Instantiate(ground);
                currentObject.transform.position = groundPos;
                currentObject.transform.name = groundCount.ToString();
                groundCount++;
                lastGroundPos.x = groundPos.x;

                GroundBorders borderScript = currentObject.GetComponent<GroundBorders>();

                if (r == 0)
                {
                    if (c == 0)
                    {
                        borderScript.edgeType = "TopLeft";
                    }
                    else if (c == columns - 1)
                    {
                        borderScript.edgeType = "TopRight";
                    }
                    else
                    {
                        borderScript.edgeType = "Top";
                    }

                }
                else if (r == rows - 1)
                {
                    if (c == 0)
                    {
                        borderScript.edgeType = "BottomLeft";
                    }
                    else if (c == columns - 1)
                    {
                        borderScript.edgeType = "BottomRight";
                    }
                    else
                    {
                        borderScript.edgeType = "Bottom";
                    }

                }
                else if (c == 0)
                {
                    borderScript.edgeType = "Left";
                }
                else if (c == columns - 1)
                {
                    borderScript.edgeType = "Right";
                }
                else
                {
                    borderScript.edgeType = "Main";
                }
            }
            lastGroundPos.z = groundPos.z;
        }

        Camera.main.transform.position = new Vector3(columns/2, 8, -rows);


    }

    public void HighwayBuild()
    {
        int median = (rows - 1) / 2;
        GameObject zero = GameObject.Find("0");
        Vector3 lastPos = new Vector3(zero.transform.position.x - (1), zero.transform.position.y, zero.transform.position.z + (1));
        for (int i = 0; i < rows; i++)
        {
            Vector3 currentPos = new Vector3(lastPos.x, lastPos.y, lastPos.z - 1);
            GameObject current = Instantiate(highwayGround);
            current.transform.position = currentPos;
            current.name = "HighwayGround" + i;

            if (i == median)
            {
                GameObject currentRoad = Instantiate(highwayRoadHorizontal);
                currentRoad.transform.position = new Vector3(currentPos.x, currentPos.y + 0.5030645f, currentPos.z);
                currentRoad.name = "HighwayConnect";
            }

            lastPos = currentPos;
        }

        lastPos = new Vector3(zero.transform.position.x - (2), zero.transform.position.y, zero.transform.position.z + (1));
        for (int i = 0; i < rows; i++)
        {
            Vector3 currentPos = new Vector3(lastPos.x, lastPos.y, lastPos.z - 1);
            GameObject current = Instantiate(highwayGround);
            current.transform.position = currentPos;
            current.name = "HighwayGround" + (rows + i);

            if (i == median)
            {
                GameObject currentRoad = Instantiate(highwayRoadJunction);
                currentRoad.transform.position = new Vector3(currentPos.x, currentPos.y + 0.5030645f, currentPos.z);
                currentRoad.name = "Highway" + (rows + i);
            }
            else
            {
                GameObject currentRoad = Instantiate(highwayRoad);
                currentRoad.transform.position = new Vector3(currentPos.x, currentPos.y + 0.5030645f, currentPos.z);
                currentRoad.name = "Highway" + (rows + i);
            }

            lastPos = currentPos;
        }
    }


}
