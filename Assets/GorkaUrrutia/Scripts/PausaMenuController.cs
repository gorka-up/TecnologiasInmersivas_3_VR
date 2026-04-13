using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenuController : MonoBehaviour
{
    public void Exit()
    {
        GameManager.instance.Exit();
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("VRMenu");
    }
    public void Continue()
    {
        GameManager.instance.Reanudar();
    }
}
