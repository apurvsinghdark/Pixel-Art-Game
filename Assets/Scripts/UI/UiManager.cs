using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Animator transition;

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
        StartCoroutine(LoadNext(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void LoadNextScene(int _buildIndex)
    {
        SceneManager.LoadScene(_buildIndex);
    }

    IEnumerator LoadNext(int buildIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        LoadNextScene(buildIndex);
    }
}
