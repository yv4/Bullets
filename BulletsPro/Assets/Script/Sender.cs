using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public BelletObject bullet;

    public float currentAngle = 0;//当前发射角度
    public float currentAngleVelocity = 0;//当前角速度
    public BulletPool pool;
    private float currentTime = 0;

    private void Awake()
    {
        pool = new BulletPool();
        pool.bullet = bullet;

        currentAngle = bullet.InitRotation;//初始旋转
        currentAngleVelocity = bullet.SenderAngleVelocity;//初始角速度
    }

    private void FixedUpdate()
    {
        //v=a*t
        currentAngleVelocity = Mathf.Clamp(currentAngleVelocity+bullet.SenderAngleVelocity * Time.fixedDeltaTime,
            -bullet.SenderMaxAgnleVelocity,
            bullet.SenderMaxAgnleVelocity
            );
        //更新角度
        currentAngle += currentAngleVelocity * Time.fixedDeltaTime;
        //限制角度
        if(Mathf.Abs(currentAngle)>720)
        {
            currentAngle -= Mathf.Sign(currentAngle)*360;
            Send(currentAngle);
        }

        //更新时间
        currentTime += Time.fixedDeltaTime;
        
        if(currentTime>bullet.SendInterval)
        {
            Debug.Log("发射时间:" + currentTime);
            currentTime -= bullet.SendInterval;//修正误差
            SendByCount(bullet.Count,currentAngle);
        }
    }

    private void SendByCount(int count,float angle)
    {
        float temp = count % 2 == 0 ? angle + bullet.LineAngle / 2 : angle;

        //遍历每一条线
        for (int i=0;i<count;i++)
        {
            temp += Mathf.Pow(-1, i) * i * bullet.LineAngle;
            Send(temp);
        }
    }

    private void Send(float angle)
    {
        var bh = pool.GetItem();
        bh.gameObject.transform.position = transform.position;
        bh.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

   
}
