using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int points;
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
        spawnHandler.Easy();
    }

    private void Update()
    {
        spawnHandler.SpawnBlocks();
    }

    public void AddPoint()
    {
        points = points + 1;
        pointTMP.text = points.ToString();
    }
}
