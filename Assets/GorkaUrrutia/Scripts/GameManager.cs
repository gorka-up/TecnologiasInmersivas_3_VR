using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int points;
    public int objetivePoints = 20;
    public Canvas cameraCanvas;
    public TextMeshProUGUI pointTMP;
    public TextMeshProUGUI countDownTMP;


    public Canvas worldCanvas;
    public Button easyButton, mediumButton, hardButton, startButton;

    [SerializeField] SpawnHandler spawnHandler;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {   
        //Recibir datos de las opciones
        spawnHandler.Easy();
    }

    private void FixedUpdate()
    {
        //Spawn blocks
    }

    public void AddPoint(int point)
    {
        points = points + point;
        //pointTMP.text = points.ToString(); CAMBIARLO A MENU IN WORLD
    }
}
