using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float LinearVelocity=0;//线速度
    public float Acceleration = 0;//线加速度
    public float AngleVelocity = 0;//角速度
    public float AngleAcceleration = 0;//角加速度
    public float MaxVelocity = int.MaxValue;//最大速度
    public float LifeTime = 5;

    public BulletPool pool;

    //0.02秒执行一次 一秒50次
    private void FixedUpdate()
    {
        //更新当前的线速度和角速度
        LinearVelocity = Mathf.Clamp(LinearVelocity+Acceleration * Time.fixedDeltaTime,-MaxVelocity,MaxVelocity);
        AngleVelocity += AngleAcceleration * Time.fixedDeltaTime;
        //更新子弹位置
        transform.Translate(LinearVelocity * Vector2.right * Time.fixedDeltaTime,Space.Self);
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,1) * AngleVelocity * Time.deltaTime);
        //生命结束销毁物体
        LifeTime -= Time.deltaTime;
        if(LifeTime<=0)
        {
            Destroy(gameObject);
        }
    }

}
