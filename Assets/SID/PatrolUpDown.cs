using UnityEngine;

public class PatrolUpDown : MonoBehaviour
{
    [Header("Movement Settings")]
    public float distance = 3f;        // How far down to move from the start position
    public float minSpeed = 1f;        // Minimum movement speed
    public float maxSpeed = 3f;        // Maximum movement speed
    public bool startGoingDown = true; // true = begin by moving down (matches your original behavior)

    [Header("Sprites")]
    public GameObject frontSprite;     // Shown when moving down
    public GameObject backSprite;      // Shown when moving up

    private Vector3 startPos;
    private bool movingUp;
    private float currentSpeed;

    void Start()
    {
        startPos = transform.position;
        movingUp = !startGoingDown; // if startGoingDown == true, movingUp starts false (so it goes down first)
        PickRandomSpeed();
        SetSprites(movingUp);
    }

    void Update()
    {
        float step = currentSpeed * Time.deltaTime;

        // TARGET: either the original startPos (moving up) or startPos - distance (moving down)
        Vector3 target = movingUp ? startPos : startPos - Vector3.up * distance;

        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // reached endpoint → flip direction, pick a new random speed and update sprites
            movingUp = !movingUp;
            PickRandomSpeed();
            SetSprites(movingUp);
        }
    }

    void PickRandomSpeed()
    {
        currentSpeed = Mathf.Max(0.0001f, Random.Range(minSpeed, maxSpeed));
    }

    void SetSprites(bool goingUp)
    {
        // explicit enable/disable to avoid drift
        if (frontSprite != null) frontSprite.SetActive(!goingUp); // front visible when moving down
        if (backSprite != null) backSprite.SetActive(goingUp);   // back visible when moving up
    }
}
