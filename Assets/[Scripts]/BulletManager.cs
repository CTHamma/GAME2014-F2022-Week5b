using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Bullet Properties")]
    public Queue<GameObject> bulletPool;
    public GameObject bulletPrefab;
    public int bulletNumber = 50;
    public Transform bulletParent;
    public int bulletCount = 0;
    public int activeBullets = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

    void BuildBulletPool()
    {
       for (int i = 0; i < bulletNumber; i++)
        {
            CreateBullet();
        }

        bulletCount = bulletPool.Count;
    }

    void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.SetParent(bulletParent);
        bulletPool.Enqueue(bullet);
    }

    public GameObject GetBullet(Vector2 position, BulletDirection direction)
    {
        if (bulletPool.Count < 1)
        {
            CreateBullet();
        }

        var bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = position;
        bullet.GetComponent<BulletBehaviour>().SetDirection(direction);

        // stats
        bulletCount = bulletPool.Count;
        activeBullets++;

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);

        //stats
        bulletCount = bulletPool.Count;
        activeBullets--;
    }
}
