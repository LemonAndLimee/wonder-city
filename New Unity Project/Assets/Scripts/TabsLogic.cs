using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsLogic : MonoBehaviour
{
    public Text goldCounter;
    public GoldLogic goldScript;

    public Animation bottomTabAnimation;
    public bool bottomTabUp;

    public GroundPlacementController placementScript;

    public GameObject House1;
    public Text House1Price;
    public Button House1Button;
    public Image House1Image;
    public int house1Price;

    public GameObject House2;
    public Text House2Price;
    public Button House2Button;
    public Image House2Image;
    public int house2Price;

    public Canvas houseUI;
    public Text residentCount;
    public Text residentHappinessText;
    public Text houseUITitle;

    public GameObject road;


    // Start is called before the first frame update
    void Start()
    {
        bottomTabUp = false;
        house1Price = 500;
        house2Price = 1500;

        houseUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        goldCounter.text = "$" + goldScript.gold;
        House1Price.text = "$" + house1Price;
        House2Price.text = "$" + house2Price;

        House1Active();
        House2Active();

        if (Input.GetKeyDown("e"))
        {
            ToggleRoad();
        }
    }

    public void ShowHouseUI(HouseLogic localHouseScript)
    {
        houseUI.enabled = true;
        residentCount.text = "Residents: " + localHouseScript.residents;
        residentHappinessText.text = "Resident Happiness: " + localHouseScript.specificResidentHappiness + "%";
        string houseName = localHouseScript.gameObject.name;
        if (houseName == "House1(Clone)")
        {
            houseUITitle.text = "Level 1 House";
        }
        else if (houseName == "House2(Clone)")
        {
            houseUITitle.text = "Level 2 House";
        }

    }
    public void HideHouseUI()
    {
        houseUI.enabled = false;
    }


    public void ToggleHouseTab()
    {
        if (bottomTabUp == false)
        {
            bottomTabAnimation.PlayQueued("BottomTabAnimation");
            bottomTabUp = true;
        }
        else if (bottomTabUp == true)
        {
            bottomTabAnimation.PlayQueued("BottomTabHide");
            bottomTabUp = false;
        }

    }

    public void House1Active()
    {
        if (goldScript.gold - house1Price < 0)
        {
            House1Button.interactable = false;
            House1Image.color = new Color32(70, 70, 70, 255);
            House1Price.color = new Color32(179, 179, 179, 255);
        }
        else
        {
            House1Button.interactable = true;
            House1Image.color = new Color32(255, 255, 255, 255);
            House1Price.color = new Color32(204, 137, 0, 255);
        }
    }
    public void AddHouse1()
    {
        if (goldScript.gold - house1Price >= 0)
        {
            placementScript.placeCalled = true;
            placementScript.prefab = House1;
            placementScript.price = house1Price;
            placementScript.houseCapacity = 5;
            ToggleHouseTab();
        }
    }

    public void House2Active()
    {
        if (goldScript.gold - house2Price < 0)
        {
            House2Button.interactable = false;
            House2Image.color = new Color32(70, 70, 70, 255);
            House2Price.color = new Color32(179, 179, 179, 255);
        }
        else
        {
            House2Button.interactable = true;
            House2Image.color = new Color32(255, 255, 255, 255);
            House2Price.color = new Color32(204, 137, 0, 255);
        }
    }
    public void AddHouse2()
    {
        if (goldScript.gold - house2Price >=0)
        {
            placementScript.placeCalled = true;
            placementScript.prefab = House2;
            placementScript.price = house2Price;
            placementScript.houseCapacity = 8;
            ToggleHouseTab();
        }
    }

    public void ToggleRoad()
    {
        if (placementScript.placeRoadCalled == false)
        {
            placementScript.placeRoadCalled = true;
            placementScript.prefab = road;
        }
        else if (placementScript.placeRoadCalled == true)
        {
            placementScript.placeRoadCalled = false;
        }
    }

    public void ToggleFlatten()
    {
        if (placementScript.flattenCalled == false)
        {
            placementScript.flattenCalled = true;
        }
        else if (placementScript.flattenCalled == true)
        {
            placementScript.flattenCalled = false;
        }

    }
}
