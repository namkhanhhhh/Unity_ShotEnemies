using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedA, speedB;
    [SerializeField]
    public Vector3 positionEnemy = new Vector3(0, 0, 0); //vị trí ban đầu enemy

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomSpeed(speedA, speedB);
    }

    void Update()
    {
        EnemyDirect();
    }

    void EnemyDirect()
    {
        // Di chuyển enemy xuống theo trục Y
        rb.AddForce(new Vector3(positionEnemy.x,
                                -positionEnemy.y * speed * Time.deltaTime,
                                positionEnemy.z));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {

            // Tìm PlayerController và trừ HP ngay lập tức
            PlayerController player = FindFirstObjectByType<PlayerController>(); // Tìm player đầu tiên

            if (player != null)
            {
                player.ReduceHP(20);
            }

            Debug.Log("chạm đáy");
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            Debug.Log("enemy bị trúng đạn!");
            gameObject.SetActive(false);
        }
    }

    //random speed
    public void randomSpeed(float a, float b)
    {
        speed = Random.Range(a, b);
    }
}
