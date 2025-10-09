using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoadPath;
    [SerializeField] private string levelName;
    public string LevelName => levelName;

    public void GoToScene()
    {
        SceneManager.LoadScene(ConvertScenePathToName(sceneToLoadPath));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        CompleteScene();
    }

    public void CompleteScene()
    {
        if (GameManager.Instance.CompletedLevel)
        {
            PlayerPrefs.SetInt(levelName, 1);
            Debug.Log($"[OnTriggerEnter2D for LoadScene {gameObject}] level {levelName} has been {PlayerPrefs.GetInt(levelName, 1)} completed");
        }
        GoToScene();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private string ConvertScenePathToName(string sceneToLoadPath)
    {
        int start = sceneToLoadPath.LastIndexOf("/") +1;
        int end = sceneToLoadPath.LastIndexOf(".");

        if (start > 0 && end > start)
        {
            string sceneToLoad = sceneToLoadPath.Substring(start, end - start);
            return sceneToLoad;
        }
        return null;
    }
#if UNITY_EDITOR
    public SceneAsset SceneToLoad
    {
        get
        {
            return AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneToLoadPath);
        }
        set
        {
            sceneToLoadPath = AssetDatabase.GetAssetPath(value);
        }
    }
#endif
}