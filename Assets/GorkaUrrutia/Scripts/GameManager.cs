using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int points;
    int objetivePoints;

    bool isActiveHealth = false;

    public int maxHealth = 0;
    public int health = 0;

    public bool pausaActive = false;

    [SerializeField] SpawnHandler spawnHandler;

    [SerializeField] public TextMeshProUGUI point_Text;

    [SerializeField] public GameObject leftSable;
    [SerializeField] public GameObject rightSable;

    [SerializeField] public GameObject pausaMenu;

    [SerializeField] public GameObject gameOverMenu;
    [SerializeField] public GameObject winText;
    [SerializeField] public GameObject loseText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        print(pausaActive);
        Reanudar();
        print(pausaActive);

        gameOverMenu.SetActive(false);

        if (PlayerPrefs.GetInt("dualSable") == 0)
        {
            if (PlayerPrefs.GetInt("rightSable") == 1)
            {
                rightSable.SetActive(true);
                leftSable.SetActive(false);
            }
            else
            {
                rightSable.SetActive(false);
                leftSable.SetActive(true);
            }
        }
        else
        {
            rightSable.SetActive(true);
            leftSable.SetActive(true);
        }
        objetivePoints = PlayerPrefs.GetInt("maxPoints");
        points = 0;

        if (PlayerPrefs.GetInt("health") == 1)
        {
            isActiveHealth = true;
            maxHealth = PlayerPrefs.GetInt("maxHealth");
            health = maxHealth;
        }
        else
        {
            isActiveHealth = false;
            maxHealth = 0;
            health = maxHealth;
        }
    }


    private void FixedUpdate()
    {
        if (isActiveHealth)
        {
            if (health <= 0)
            {
                GameOver(false);
            }
        }
        if (points < objetivePoints)
        {
            switch (PlayerPrefs.GetInt("levelSelected"))
            {
                case 1:
                    spawnHandler.SpawnBlocks();
                    break;

                case 2:
                    spawnHandler.SpawnBlocks2();
                    break;

                case 3:
                    spawnHandler.SpawnBlocks3();
                    break;
            }
        }
        else
        {
            GameOver(true);
        }

    }

    public void AddPoint(int point)
    {
        points = points + point;
        point_Text.text = points.ToString();
    }


    public void Pausar()
    {
        Time.timeScale = 0f;
        pausaActive = true;
        pausaMenu.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        pausaActive = false;
        pausaMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoseHp()
    {
        health -= 1;
    }

    public void DestroyAllBlocks()
    {
        GameObject[] bloques = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject bloque in bloques)
        {
            Destroy(bloque);
        }
    }

    public void DestroyAllParticles()
    {
        ParticleSystem[] particles = FindObjectsByType<ParticleSystem>(FindObjectsSortMode.None);

        foreach (ParticleSystem ps in particles)
        {
            Destroy(ps.gameObject);
        }
    }

    public void GameOver(bool win)
    {
        DestroyAllBlocks();
        DestroyAllParticles();
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        if (win)
        {
            winText.SetActive(true);
            loseText.SetActive(false);
        }
        else
        {
            winText.SetActive(false);
            loseText.SetActive(true);
        }
    }
}
