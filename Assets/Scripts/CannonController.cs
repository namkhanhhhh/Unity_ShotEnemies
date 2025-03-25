using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int maxBulletPoint = 1;

    [SerializeField]
    private float fireForce = 20f;

    private List<GameObject> bulletPool; 
    private Vector3 mousePos;
    private GameObject bullet;

    void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < maxBulletPoint; i++)
        {
            bullet = Instantiate(bulletPrefab); // hàm tạo đạn
            bullet.SetActive(false);// ẩn đạn
            bulletPool.Add(bullet);// thêm vào danh sách đạn
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return; // Nếu game đang Pause, không bắn được
        RotateCannon();
        HandleShooting();
    }

    //xoay cannon
    void RotateCannon ()
    {
        // lấy vị trí con chuột trên bản đồ thế giới
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //tính vị trí quay
        Vector3 direction = mousePos - transform.position;

        //đổi ra độ
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Giới hạn góc quay trong khoảng (180 độ)
        angle = Mathf.Clamp(angle, 0f, 180f);

        //quay súng theo góc tính được
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 180f);
    }

    // Xử lý bắn
    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //bắn đạn
            FireBullet();
        }

    }

    // Hàm bắn đạn
    void FireBullet()
    {
        GameObject bullet = GetBulletFromPool();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            // bắn đạn 
            bullet.GetComponent<Rigidbody2D>().linearVelocity = -firePoint.right * fireForce;
        }

    }

    // Lấy viên đạn từ danh sách
    GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
