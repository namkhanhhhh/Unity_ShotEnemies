using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    private Vector2 startPosition;
    private float height;

    void Start()
    {
        startPosition = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, height);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}
