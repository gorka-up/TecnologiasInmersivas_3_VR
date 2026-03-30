using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int points;
    public int objetivePoints;

    [SerializeField] SpawnHandler spawnHandler;

    [SerializeField] public TextMeshProUGUI point_Text;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        spawnHandler.SpawnBlocks();
    }

    public void AddPoint(int point)
    {
        points = points + point;
        point_Text.text = points.ToString();
    }
}
