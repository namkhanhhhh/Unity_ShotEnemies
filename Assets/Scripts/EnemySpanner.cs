using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemyprefab;
    [SerializeField]
    private int maxEnemy = 20;// Giới hạn số enemy tối đa
    [SerializeField]
    private float spanEnemyTime = 1.5f;// Khoảng thời gian sinh enemy
    [SerializeField]
    private float XRange, YRange; //Vị trí sinh(trên màn hình)

    //danh sach enemy
    private List<GameObject> enemyPool = new List<GameObject>();
    private float time = 0;
    private EnemyController enemyController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //khởi tạo enemy
        for (int i = 0; i < maxEnemy; i++)
        {
            GameObject enemy = Instantiate(Enemyprefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spanEnemyTime)
        {
            //sinh enemy
            SpanEnemy();
            time = 0;
        }
    }

    //sinh enemy theo thời gian
    void SpanEnemy()
    {
        GameObject enemy = GetInActiveEnemy();
        if (enemy != null)
        {
            //random vi tri 
            enemy.transform.position = new Vector3(
                    transform.position.x + Random.Range(-XRange,XRange),
                    transform.position.y + Random.Range(-YRange,YRange),
                    transform.position.z);

            //hiển thị enemy
            enemy.SetActive(true);

            //random speed
            enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.randomSpeed(1.5f, 3.2f);
            }
        }
    }

    // lấy enemy từ danh sách
    public GameObject GetInActiveEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }
}
