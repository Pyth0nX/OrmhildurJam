using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerState player;

    public Camera[] _cameras;
    
    public static GameManager Instance;
    
    private bool hasCompletedLevel = false;
    public bool CompletedLevel => hasCompletedLevel;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    public void SwapCamera(int levelIndex, int prevLevelIndex)
    {
        if (prevLevelIndex == -1) prevLevelIndex = levelIndex - 1;
        if (prevLevelIndex != -1) _cameras[prevLevelIndex].gameObject.SetActive(false);
        _cameras[levelIndex].gameObject.SetActive(true);
    }

    public void CompleteLevel()
    {
        hasCompletedLevel = true;
    }
}
