using UnityEngine;

public class HPCanvasController : MonoBehaviour
{
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    [SerializeField] GameObject heart4;
    [SerializeField] GameObject heart5;

    void Start()
    {
        switch (GameManager.instance.maxHealth)
        {
            case 5:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(false);
                heart5.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
                break;
            default:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
                break;
        }
    }

    void Update()
    {
        if (GameManager.instance.health < 5)// 4
        {
            if (GameManager.instance.health < 4)//3
            {
                if (GameManager.instance.health < 3)//2
                {
                    if (GameManager.instance.health < 2)//1
                    {
                        if (GameManager.instance.health < 1)
                        {
                            heart1.SetActive(false);
                        }
                        heart2.SetActive(false);
                    }
                    heart3.SetActive(false);
                }
                heart4.SetActive(false);
            }
            heart5.SetActive(false);
        }
    }
}
