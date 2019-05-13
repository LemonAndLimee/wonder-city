using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldLogic : MonoBehaviour
{
    public WorldSystem worldScript;
    public int gold;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        gold = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        worldScript.gold = gold;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            AddTaxes(worldScript.population, worldScript.residentHappiness);
            timer = 60;
        }
    }

    public void AddTaxes(int population, int happiness)
    {
        gold += population * happiness;
    }
}
