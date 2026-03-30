using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI points_Text;

    [SerializeField] public GameObject leftSable;
    [SerializeField] public GameObject rightSable;

    [SerializeField] public GameObject rightOrLeft_Toggle;

    [SerializeField] public GameObject maxHealth_Dropbox;

    private int dificulty = 0;
    private int neededPoints = 20;
    private bool health = false;
    private int maxHealth = 0;
    private bool dualSable = true;
    private bool isRightSable = false;

    private int levelSelected = 1;

    private void Update()
    {
        if (!dualSable)
        {
            rightOrLeft_Toggle.SetActive(true);
            if (isRightSable)
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
            rightOrLeft_Toggle.SetActive(false);
            rightSable.SetActive(true);
            leftSable.SetActive(true);
        }

        if (health)
        {
            maxHealth_Dropbox.SetActive(true);
        }
        else
        {
            maxHealth_Dropbox.SetActive(false);
        }

        points_Text.text = neededPoints.ToString();
    }

    public void SetEasy()
    {
        dificulty = 0;
        print(dificulty);
    }
    public void SetNormal()
    {
        dificulty = 1;
        print(dificulty);
    }
    public void SetHard()
    {
        dificulty = 2;
        print(dificulty);
    }

    public void SetMaxPoints(int points)
    {
        neededPoints = points;
        print(neededPoints);
    }

    public void SetHealth()
    {
        health = !health;
        print(health);
    }

    public void SetMaxHealth(int hp)
    {
        maxHealth = hp;
        print(maxHealth);
    }
    public void SetDualSable()
    {
        dualSable = !dualSable;
        print(dualSable);
    }

    public void SetRightSable()
    {
        isRightSable = !isRightSable;
        print(isRightSable);
    }

    public void SelectLvl(int lvl)
    {
        levelSelected = lvl;
    }

    public void GoToLevel()
    {
        SaveData();
        switch (levelSelected) {
            case 1:
                PlayerPrefs.SetInt("selectedLevel", levelSelected);
                SceneManager.LoadScene("Level1");
                break;

            case 2:
                PlayerPrefs.SetInt("selectedLevel", levelSelected);
                SceneManager.LoadScene("Level2");
                break;

            default:
                PlayerPrefs.SetInt("selectedLevel", 1);
                SceneManager.LoadScene("Level1");
                break;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("dificulty", dificulty);
        PlayerPrefs.SetInt("maxPoints", neededPoints);
        if (health)
        {
            PlayerPrefs.SetInt("health", 1);
            PlayerPrefs.SetInt("maxHealth", maxHealth);
        }
        else
        {
            PlayerPrefs.SetInt("health", 0);
            PlayerPrefs.SetInt("maxHealth", 0);
        }

        if (dualSable)
        {
            PlayerPrefs.SetInt("dualSable", 1);
        }
        else
        {
            if (isRightSable)
            {
                PlayerPrefs.SetInt("dualSable", 0);
                PlayerPrefs.SetInt("rightSable", 1);
            }
            else
            {
                PlayerPrefs.SetInt("dualSable", 0);
                PlayerPrefs.SetInt("rightSable", 0);
            }
        }
    }
}
