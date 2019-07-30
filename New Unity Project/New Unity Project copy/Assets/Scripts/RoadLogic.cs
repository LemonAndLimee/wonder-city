using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLogic : MonoBehaviour
{
    public WorldSystem worldScript;
    public GameManagement gameScript;

    public GameObject empty;

    public GameObject road;
    public GameObject roadVertical;
    public GameObject cornerRoad;
    public GameObject cornerRoadLeftBottom;
    public GameObject cornerRoadRightTop;
    public GameObject cornerRoadRightBottom;
    public GameObject fourCornerRoad;
    public GameObject threeWayRoad;
    public GameObject threeWayRoadLeft;
    public GameObject threeWayRoadUpwards;
    public GameObject threeWayRoadDown;

    public GameObject left;
    public GameObject right;
    public GameObject top;
    public GameObject bottom;

    public bool leftRoad;
    public bool rightRoad;
    public bool topRoad;
    public bool bottomRoad;

    public GameObject currentRoad;
    public Vector3 currentPos;

    public Vector3 highwayConnect;

    
    // Start is called before the first frame update
    void Start()
    {
        highwayConnect = GameObject.Find("HighwayConnect").transform.position;
        highwayConnect.x += 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForBorders();

    }


    public void CheckForBorders()
    {
        for (int i = 0; i < worldScript.objects.Length; i++)
        {
            left = empty;
            right = empty;
            top = empty;
            bottom = empty;



            if (worldScript.objects[i] == "road" || worldScript.objects[i] == "roadVertical" || worldScript.objects[i] == "cornerRoad" || worldScript.objects[i] == "cornerRoadRightTop" || worldScript.objects[i] == "cornerRoadRightBottom" || worldScript.objects[i] == "cornerRoadLeftBottom" || worldScript.objects[i] == "3wayRoad" || worldScript.objects[i] == "3wayRoadUpwards" || worldScript.objects[i] == "3wayRoadLeft" || worldScript.objects[i] == "3wayRoadDown" || worldScript.objects[i] == "4cornerRoad")
            {


                GameObject parent = GameObject.Find(i.ToString());

                GroundBorders groundScript = parent.GetComponent<GroundBorders>();

                if (groundScript.edgeType != "Left" & groundScript.edgeType != "TopLeft" & groundScript.edgeType != "BottomLeft")
                {
                    left = GameObject.Find((i - 1).ToString());
                }
                if (groundScript.edgeType != "Right" & groundScript.edgeType != "TopRight" & groundScript.edgeType != "BottomRight")
                {
                    right = GameObject.Find((i + 1).ToString());
                }
                if (groundScript.edgeType != "Top" & groundScript.edgeType != "TopLeft" & groundScript.edgeType != "TopRight")
                {
                    top = GameObject.Find((i - gameScript.columns).ToString());
                }
                if (groundScript.edgeType != "Bottom" & groundScript.edgeType != "BottomLeft" & groundScript.edgeType != "BottomRight")
                {
                    bottom = GameObject.Find((i + gameScript.rows).ToString());
                }

                if (GameObject.Find("Road" + i).transform.position == highwayConnect)
                {
                    leftRoad = true;
                    SpecificRoadLogic roadScript = GameObject.Find("Road" + i).GetComponent<SpecificRoadLogic>();
                    roadScript.isHighwayConnected = true;
                }
                else if (GameObject.Find("Road" + System.Convert.ToInt32(left.name)) != null)
                {
                    leftRoad = true;
                }
                else
                {
                    leftRoad = false;
                }
                if (GameObject.Find("Road" + System.Convert.ToInt32(right.name)) != null)
                {
                    rightRoad = true;
                }
                else
                {
                    rightRoad = false;
                }
                if (GameObject.Find("Road" + System.Convert.ToInt32(top.name)) != null)
                {
                    topRoad = true;
                }
                else
                {
                    topRoad = false;
                }
                if (GameObject.Find("Road" + System.Convert.ToInt32(bottom.name)) != null)
                {
                    bottomRoad = true;
                }
                else
                {
                    bottomRoad = false;
                }

                currentRoad = GameObject.Find("Road" + i);
                currentPos = new Vector3(0, 0, 0);

                CheckForHighway();

                //covers left, left+right, left+right+top, left+right+top+bottom
                //also left+top, left+top+bottom
                //left+bottom
                if (leftRoad == true)
                {



                    //placement snapping
                    if (rightRoad == true)
                    {
                        if (topRoad == true)
                        {
                            if (bottomRoad == true)
                            {
                                if (worldScript.objects[i] != "4cornerRoad")
                                {
                                    currentPos = currentRoad.transform.position;
                                    Destroy(currentRoad);
                                    currentRoad = Instantiate(fourCornerRoad);
                                    currentRoad.transform.position = currentPos;
                                    worldScript.objects[i] = "4cornerRoad";
                                    currentRoad.name = "Road" + i;
                                }
                            }
                            else
                            {
                                if (worldScript.objects[i] != "3wayRoadUpwards")
                                {
                                    currentPos = currentRoad.transform.position;
                                    Destroy(currentRoad);
                                    currentRoad = Instantiate(threeWayRoadUpwards);
                                    currentRoad.transform.position = currentPos;
                                    worldScript.objects[i] = "3wayRoadUpwards";
                                    currentRoad.name = "Road" + i;
                                }
                            }
                        }
                        else if (bottomRoad == true)
                        {
                            if (worldScript.objects[i] != "3wayRoadDown")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(threeWayRoadDown);
                                currentRoad.transform.position = currentPos;
                                worldScript.objects[i] = "3wayRoadDown";
                                currentRoad.name = "Road" + i;
                            }
                        }
                        else
                        {
                            if (worldScript.objects[i] != "road")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(road);
                                currentRoad.transform.position = currentPos;
                                worldScript.objects[i] = "road";
                                currentRoad.name = "Road" + i;
                            }
                        }
                    }
                    else if (topRoad == true)
                    {
                        if (bottomRoad == true)
                        {
                            if (worldScript.objects[i] != "3wayRoadLeft")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(threeWayRoadLeft);
                                currentRoad.transform.position = currentPos;
                                currentRoad.name = "Road" + i;
                                worldScript.objects[i] = "3wayRoadLeft";
                            }
                        }
                        else
                        {
                            if (worldScript.objects[i] != "cornerRoad")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(cornerRoad);
                                currentRoad.transform.position = currentPos;
                                currentRoad.name = "Road" + i;
                                worldScript.objects[i] = "cornerRoad";
                            }
                        }
                    }
                    else if (bottomRoad == true)
                    {
                        if (worldScript.objects[i] != "cornerRoadLeftBottom")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(cornerRoadLeftBottom);
                            currentRoad.transform.position = currentPos;
                            worldScript.objects[i] = "cornerRoadLeftBottom";
                            currentRoad.name = "Road" + i;
                        }
                    }
                    else
                    {
                        if (worldScript.objects[i] != "road")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(road);
                            currentRoad.transform.position = currentPos;
                            worldScript.objects[i] = "road";
                            currentRoad.name = "Road" + i;
                        }
                    }
                }

                //covers right, right+top, right+top+bottom
                //right+bottom
                else if (rightRoad == true)
                {
                    if (topRoad == true)
                    {
                        if (bottomRoad == true)
                        {
                            if (worldScript.objects[i] != "3wayRoad")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(threeWayRoad);
                                currentRoad.transform.position = currentPos;
                                worldScript.objects[i] = "3wayRoad";
                                currentRoad.name = "Road" + i;
                            }
                        }
                        else
                        {
                            if (worldScript.objects[i] != "cornerRoadRightTop")
                            {
                                currentPos = currentRoad.transform.position;
                                Destroy(currentRoad);
                                currentRoad = Instantiate(cornerRoadRightTop);
                                currentRoad.transform.position = currentPos;
                                worldScript.objects[i] = "cornerRoadRightTop";
                                currentRoad.name = "Road" + i;
                            }
                        }
                    }
                    else if (bottomRoad == true)
                    {
                        if (worldScript.objects[i] != "cornerRoadRightBottom")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(cornerRoadRightBottom);
                            currentRoad.transform.position = currentPos;
                            worldScript.objects[i] = "cornerRoadRightBottom";
                            currentRoad.name = "Road" + i;
                        }
                    }
                    else
                    {
                        if (worldScript.objects[i] != "road")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(road);
                            currentRoad.transform.position = currentPos;
                            worldScript.objects[i] = "road";
                            currentRoad.name = "Road" + i;
                        }
                    }
                }

                //covers top, top+bottom
                else if (topRoad == true)
                {
                    if (bottomRoad == true)
                    {
                        if (worldScript.objects[i] != "roadVertical")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(roadVertical);
                            currentRoad.transform.position = currentPos;
                            currentRoad.name = "Road" + i;
                            worldScript.objects[i] = "roadVertical";
                        }
                    }
                    else
                    {
                        if (worldScript.objects[i] != "roadVertical")
                        {
                            currentPos = currentRoad.transform.position;
                            Destroy(currentRoad);
                            currentRoad = Instantiate(roadVertical);
                            currentRoad.transform.position = currentPos;
                            currentRoad.name = "Road" + i;
                            worldScript.objects[i] = "roadVertical";
                        }
                    }
                }

                //covers bottom
                else if (bottomRoad == true)
                {
                    if (worldScript.objects[i] != "roadVertical")
                    {
                        currentPos = currentRoad.transform.position;
                        Destroy(currentRoad);
                        currentRoad = Instantiate(roadVertical);
                        currentRoad.transform.position = currentPos;
                        currentRoad.name = "Road" + i;
                        worldScript.objects[i] = "roadVertical";
                    }
                }
            }
        }
    }

    public void CheckForHighway()
    {
        SpecificRoadLogic specificRoadLogic = currentRoad.GetComponent<SpecificRoadLogic>();

        if (leftRoad == true)
        {

            if (currentRoad.transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (GameObject.Find("Road" + System.Convert.ToInt32(left.name)).transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (GameObject.Find("Road" + System.Convert.ToInt32(left.name)).GetComponent<SpecificRoadLogic>().isHighwayConnected == true)
            {
                //SpecificRoadLogic leftRoadScript = GameObject.Find("Road" + System.Convert.ToInt32(left.name)).GetComponent<SpecificRoadLogic>();
                specificRoadLogic.isHighwayConnected = true;
            }
        }
        else if (rightRoad == true)
        {
            SpecificRoadLogic rightRoadScript = GameObject.Find("Road" + System.Convert.ToInt32(right.name)).GetComponent<SpecificRoadLogic>();
            if (currentRoad.transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (GameObject.Find("Road" + System.Convert.ToInt32(right.name)).transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (rightRoadScript.isHighwayConnected == true)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
        }
        else if (topRoad == true)
        {
            SpecificRoadLogic topRoadScript = GameObject.Find("Road" + System.Convert.ToInt32(top.name)).GetComponent<SpecificRoadLogic>();
            if (currentRoad.transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (GameObject.Find("Road" + System.Convert.ToInt32(top.name)).transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (topRoadScript.isHighwayConnected == true)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
        }
        else if (bottomRoad == true)
        {
            SpecificRoadLogic bottomRoadScript = GameObject.Find("Road" + System.Convert.ToInt32(bottom.name)).GetComponent<SpecificRoadLogic>();
            if (currentRoad.transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (GameObject.Find("Road" + System.Convert.ToInt32(bottom.name)).transform.position == highwayConnect)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
            else if (bottomRoadScript.isHighwayConnected == true)
            {
                specificRoadLogic.isHighwayConnected = true;
            }
        }
        else
        {
            specificRoadLogic.isHighwayConnected = false;
        }
    }
}
