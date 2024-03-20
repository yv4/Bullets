using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public BelletObject bullet;

    public float currentAngle = 0;//��ǰ����Ƕ�
    public float currentAngleVelocity = 0;//��ǰ���ٶ�
    public BulletPool pool;
    private float currentTime = 0;

    private void Awake()
    {
        pool = new BulletPool();
        pool.bullet = bullet;

        currentAngle = bullet.InitRotation;//��ʼ��ת
        currentAngleVelocity = bullet.SenderAngleVelocity;//��ʼ���ٶ�
    }

    private void FixedUpdate()
    {
        //v=a*t
        currentAngleVelocity = Mathf.Clamp(currentAngleVelocity+bullet.SenderAngleVelocity * Time.fixedDeltaTime,
            -bullet.SenderMaxAgnleVelocity,
            bullet.SenderMaxAgnleVelocity
            );
        //���½Ƕ�
        currentAngle += currentAngleVelocity * Time.fixedDeltaTime;
        //���ƽǶ�
        if(Mathf.Abs(currentAngle)>720)
        {
            currentAngle -= Mathf.Sign(currentAngle)*360;
            Send(currentAngle);
        }

        //����ʱ��
        currentTime += Time.fixedDeltaTime;
        
        if(currentTime>bullet.SendInterval)
        {
            Debug.Log("����ʱ��:" + currentTime);
            currentTime -= bullet.SendInterval;//�������
            SendByCount(bullet.Count,currentAngle);
        }
    }

    private void SendByCount(int count,float angle)
    {
        float temp = count % 2 == 0 ? angle + bullet.LineAngle / 2 : angle;

        //����ÿһ����
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
