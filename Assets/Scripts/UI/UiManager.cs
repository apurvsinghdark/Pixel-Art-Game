using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
    public void OnNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
