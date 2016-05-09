using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainToGameButton : MonoBehaviour
{


    public string nextSceneName;

    public void NextScene()
    {

        DataManager.nextSceneName = nextSceneName;
        SceneManager.LoadScene("Loading");

    }

}
