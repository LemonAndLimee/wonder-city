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

    public GameObject Flat;
    public Text flatPriceUI;
    public Button flatButton;
    public Image flatImage;
    public int flatPrice;

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
        flatPrice = 500;
        house2Price = 1500;

        houseUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        goldCounter.text = "$" + goldScript.gold;
        flatPriceUI.text = "$" + flatPrice;
        House2Price.text = "$" + house2Price;

        FlatActive();
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
        if (houseName == "Flat1")
        {
            houseUITitle.text = "Level 1 Apartment";
        }
        else if (houseName == "House2")
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

    public void FlatActive()
    {
        if (goldScript.gold - flatPrice < 0)
        {
            flatButton.interactable = false;
            flatImage.color = new Color32(70, 70, 70, 255);
            flatPriceUI.color = new Color32(179, 179, 179, 255);
        }
        else
        {
            flatButton.interactable = true;
            flatImage.color = new Color32(255, 255, 255, 255);
            flatPriceUI.color = new Color32(204, 137, 0, 255);
        }
    }
    public void AddFlat()
    {
        if (goldScript.gold - flatPrice >= 0)
        {
            placementScript.placeCalled = true;
            placementScript.prefab = Flat;
            placementScript.price = flatPrice;
            placementScript.houseCapacity = 20;
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
