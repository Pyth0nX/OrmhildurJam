using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static int HorizontalHash = Animator.StringToHash("horizontal");
    private static int VerticalHash = Animator.StringToHash("vertical");
    
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public void Input(Vector2 incomingVector)
    {
        _animator.SetFloat(HorizontalHash, incomingVector.x);
        _animator.SetFloat(VerticalHash, incomingVector.y);
    }
}
