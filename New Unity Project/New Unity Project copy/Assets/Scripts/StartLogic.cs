using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLogic : MonoBehaviour
{
    public GameManagement gameScript;

    public GameObject canvas;
    public GameObject loadButton;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript.saveExists == false)
        {
            loadButton.SetActive(false);
        }
    }

    public void Play()
    {
        canvas.SetActive(false);
        gameScript.LoadWorld();
        gameScript.gameStarted = true;
        gameScript.HighwayBuild();
    }

    public void New()
    {
        canvas.SetActive(false);
        gameScript.gameStarted = true;
        gameScript.SaveWorld();
        gameScript.TerrainBuild();
    }
}
