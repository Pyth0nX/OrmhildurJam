using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LoadScene levelSelector;
    
    void Start()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(AttemptSelectLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(AttemptSelectLevel);
    }

    public void AttemptSelectLevel()
    {
        var levelName = levelSelector.LevelName;
        var hasLevelBeenCompleted = PlayerPrefs.GetInt(levelName, 0) == 1;
        
        Debug.Log($"[AttempSelectLevel] attempting to select level for {levelName} it is {hasLevelBeenCompleted} completed based on {PlayerPrefs.GetInt(levelName, 0)}");
        if (hasLevelBeenCompleted)
        {
            Debug.Log($"[AttempSelectLevel] level {levelName} has been completed");
            return;
        }
        
        levelSelector.GoToScene();
    }
}
