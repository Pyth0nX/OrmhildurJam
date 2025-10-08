using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerState player;
    
    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
