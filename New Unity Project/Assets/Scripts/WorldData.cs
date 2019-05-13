using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData
{
    public string[] objects;
    public float[] Xpositions;
    public float[] Ypositions;
    public float[] Zpositions;

    public int gold;

    public bool savedGame;

    public int population;
    public int residenthappiness;

    public int houses;

    public int[] residents;

    public WorldData (WorldSystem worldScript)
    {
        objects = worldScript.objects;
        Xpositions = worldScript.Xpositions;
        Ypositions = worldScript.Ypositions;
        Zpositions = worldScript.Zpositions;

        gold = worldScript.gold;

        savedGame = worldScript.savedGameTest;

        population = worldScript.population;
        residenthappiness = worldScript.residentHappiness;

        houses = worldScript.houses;

        residents = worldScript.residents;
        
    }
}
