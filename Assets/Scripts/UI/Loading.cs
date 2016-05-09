using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class Loading : MonoBehaviour {
    public Image loadingBar;
    public Text percent;
    AsyncOperation loading;//  비동기 로딩


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        loading = SceneManager.LoadSceneAsync(DataManager.nextSceneName);
        yield return loading;

        Debug.Log("Loading Complete");
        Destroy(gameObject);
    }

    void Update()
    {
        loadingBar.fillAmount = loading.progress;
        percent.text = (((int)loading.progress) * 100).ToString () + "%";
    }

}
