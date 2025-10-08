using UnityEngine;

public class FlipSide : MonoBehaviour
{
    // Instant flip on X axis when pressing left/right
    Vector3 baseScale;
    bool facingRight;

    void Start()
    {
        baseScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        facingRight = transform.localScale.x >= 0f;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0 && !facingRight) Flip(true);
        else if (moveX < 0 && facingRight) Flip(false);
    }

    void Flip(bool toRight)
    {
        facingRight = toRight;
        Vector3 target = baseScale;
        target.x = toRight ? Mathf.Abs(baseScale.x) : -Mathf.Abs(baseScale.x);
        transform.localScale = target; // instant flip
    }
}