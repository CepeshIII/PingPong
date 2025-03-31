using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        var sceneLoader = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None);
        foreach (var loader in sceneLoader)
        {
            if(loader != this)
            {
                if(sceneLoader != null)
                {
                    //Destroy( sceneLoader );
                }
            }
            else
            {
                DontDestroyOnLoad(loader);
            }
        }
    }

    public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = currentSceneIndex + 1;

        LoadScene(nextSceneIndex);
    }


    public void LoadScene(int nextSceneIndex)
    {
        var countOfScene = SceneManager.sceneCountInBuildSettings;

        if (countOfScene > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        LoadScene(0);
    }

    public void LoadGameOverScene(string playerName = "")
    {
        PlayerPrefs.SetString("lostPlayerName", playerName);
        LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
