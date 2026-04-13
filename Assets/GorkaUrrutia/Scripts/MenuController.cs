using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI points_Text;

    [SerializeField] public GameObject leftSable;
    [SerializeField] public GameObject rightSable;

    [SerializeField] public GameObject rightOrLeft_Toggle;

    [SerializeField] public GameObject maxHealth_Dropbox;

    [SerializeField] public Dropdown health_Dropbox;

    [SerializeField] public Slider Slider;

    [SerializeField] public Text txtOptions;

    private int dificulty = 0;
    private int neededPoints = 20;
    private bool health = false;
    private int maxHealth = 5;
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

        txtOptions.text = "LEVEL " +levelSelected + " OPTIONS";
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

    public void SetMaxPoints()
    {
        neededPoints = (int)Slider.value;
        print(neededPoints);
    }

    public void SetHealth()
    {
        health = !health;
        print(health);
    }

    public void SetMaxHealth()
    {
        if (health_Dropbox.value == 0)
        {
            maxHealth = 5;
        }else if (health_Dropbox.value == 1)
        {
            maxHealth = 3;
        }
        else
        {
            maxHealth = 1;
        }
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
        SceneManager.LoadScene("Level"+ levelSelected);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("dificulty", dificulty);
        PlayerPrefs.SetInt("maxPoints", neededPoints);
        PlayerPrefs.SetInt("levelSelected", levelSelected);
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
