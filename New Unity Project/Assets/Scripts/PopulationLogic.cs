using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationLogic : MonoBehaviour
{
    public WorldSystem worldScript;

    public int population;
    public int residentHappiness;

    public Text residentHappinessText;
    public Text populationText;

    // Start is called before the first frame update
    void Start()
    {
        residentHappiness = 100;
        population = 0;
    }

    // Update is called once per frame
    void Update()
    {
        worldScript.population = population;
        worldScript.residentHappiness = residentHappiness;

        residentHappinessText.text = residentHappiness + "%";
        populationText.text = population.ToString();

        population = TotalPopulation();
    }

    public int TotalPopulation()
    {
        int total = 0;

        for (int i = 0; i < worldScript.residents.Length; i++)
        {
            total += worldScript.residents[i];
        }

        return total;
    }
}
