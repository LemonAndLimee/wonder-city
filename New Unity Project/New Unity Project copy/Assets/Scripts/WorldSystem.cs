using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldSystem : MonoBehaviour
{
    public GameManagement gameScript;


    public bool savedGameTest = true;


    public GameObject empty;
    public string[] objects;
    public float[] Xpositions;
    public float[] Ypositions;
    public float[] Zpositions;

    public int gold;

    public int population;
    public int residentHappiness;

    public int houses;

    public int[] residents;

    // Start is called before the first frame update
    void Start()
    {
        objects = new string[gameScript.rows*gameScript.columns];
        Xpositions = new float[gameScript.rows * gameScript.columns];
        Ypositions = new float[gameScript.rows * gameScript.columns];
        Zpositions = new float[gameScript.rows * gameScript.columns];

        residents = new int[gameScript.rows*gameScript.columns];
            

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = empty.name;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
