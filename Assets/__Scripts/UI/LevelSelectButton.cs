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

    private void AttemptSelectLevel()
    {
        var levelName = levelSelector.LevelName;
        PlayerPrefs.GetInt(levelName, 0);
        if (PlayerPrefs.GetInt(levelName, 0) != 1) return;
        levelSelector.GoToScene();
    }
}
