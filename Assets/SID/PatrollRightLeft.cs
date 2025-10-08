using UnityEngine;

public class PatrolRightLeft : MonoBehaviour
{
    [Header("Movement Settings")]
    public float distance = 3f;        // How far to move right/left
    public float minSpeed = 1f;        // Minimum movement speed
    public float maxSpeed = 3f;        // Maximum movement speed

    [Header("Sprites")]
    public GameObject rightSprite;     // Shown when moving right
    public GameObject leftSprite;      // Shown when moving left

    private Vector3 startPos;
    private bool goingRight = true;
    private float currentSpeed;

    void Start()
    {
        startPos = transform.position;

        // Start with a random speed
        currentSpeed = Random.Range(minSpeed, maxSpeed);

        // Initial sprite state
        if (rightSprite != null) rightSprite.SetActive(true);
        if (leftSprite != null) leftSprite.SetActive(false);
    }

    void Update()
    {
        if (goingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                startPos + new Vector3(distance, 0, 0), currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos + new Vector3(distance, 0, 0)) < 0.01f)
            {
                goingRight = false;
                currentSpeed = Random.Range(minSpeed, maxSpeed); // pick new speed
                ToggleSprites(false); // now show left sprite
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                startPos, currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                goingRight = true;
                currentSpeed = Random.Range(minSpeed, maxSpeed); // pick new speed
                ToggleSprites(true); // now show right sprite
            }
        }
    }

    void ToggleSprites(bool movingRight)
    {
        if (rightSprite != null) rightSprite.SetActive(movingRight);
        if (leftSprite != null) leftSprite.SetActive(!movingRight);
    }
}
