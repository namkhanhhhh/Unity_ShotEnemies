using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerController.score += 1;
            GameController gameController = FindAnyObjectByType<GameController>();
            if (gameController != null)
        {
            gameController.SendMessage("UpdateScoreDisplay");
        }


            rb.linearVelocity = Vector2.zero;

            StartCoroutine(ExplosionEffect());
            
        }
    }

    IEnumerator ExplosionEffect()
    {
        yield return new WaitForSeconds(0.21f);
        gameObject.SetActive(false);
    }
}
