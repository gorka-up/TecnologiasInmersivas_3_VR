using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    [Header("Difficulty")]
    [SerializeField]
    public Difficulty actualDifficulty;

    public int points;
    public Canvas cameraCanvas;
    public TextMeshProUGUI pointTMP;

    public Canvas worldCanvas;
    public Button easyButton, mediumButton, hardButton;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetEasy();
    }

    void Update()
    {
        
    }   

    public void SetEasy()
    {
        actualDifficulty = Difficulty.Easy;
        easyButton.colors.Equals(Color.green);
        mediumButton.colors.Equals(Color.gray);
        hardButton.colors.Equals(Color.gray);
    }
    public void SetMedium()
    {
        actualDifficulty = Difficulty.Medium;
        easyButton.colors.Equals(Color.gray);
        mediumButton.colors.Equals(Color.yellow);
        hardButton.colors.Equals(Color.gray);
    }
    public void SetHard()
    {
        actualDifficulty = Difficulty.Hard;
        easyButton.colors.Equals(Color.gray);
        mediumButton.colors.Equals(Color.gray);
        hardButton.colors.Equals(Color.red);
    }

    public void AddPoint()
    {
        points = points + 1;
        pointTMP.text = points.ToString();
    }
}
