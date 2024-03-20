using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private ObjectPool<BulletBehaviour> pool;
    public BelletObject bullet;

    public BulletPool()
    {
        pool = new ObjectPool<BulletBehaviour>(OnCreateItem,OnGetItem,OnReleaseItem,OnDestroyItem);
    }

    public BulletBehaviour GetItem()
    {
        return pool.Get();
    }

    public void ReleaseItem(BulletBehaviour bh)
    {
        pool.Release(bh);


    }

    private BulletBehaviour OnCreateItem()
    {
        var bh = GameObject.Instantiate(bullet.Prefab).AddComponent<BulletBehaviour>();
        InitBullet(bh);
        bh.pool = this;
        return bh;
    }

    private void InitBullet(BulletBehaviour bh)
    {
        bh.LinearVelocity = bullet.LinearVelocity;
        bh.AngleAcceleration = bullet.AngleAcceleration;
        bh.AngleVelocity = bullet.AngleVelocity;
        bh.LifeTime = bullet.LifeCycle;
        bh.MaxVelocity = bullet.MaxVelocity;
    }

    private void OnDestroyItem(BulletBehaviour bh)
    {
        GameObject.Destroy(bh.gameObject);
    }

    private void OnReleaseItem(BulletBehaviour bh)
    {
        bh.gameObject.SetActive(false);
    }

    private void OnGetItem(BulletBehaviour bh)
    {
        InitBullet(bh);
        bh.gameObject.SetActive(true);
    }

}
