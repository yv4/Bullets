using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create BulletAsset")]
public class BelletObject : ScriptableObject
{
    [Header("子弹初始位置")]
    public float LifeCycle = 5;//生命周期
    public float LinearVelocity = 0;//线速度
    public float Acceleration = 0;//线加速度
    public float AngleVelocity = 0;//角速度
    public float AngleAcceleration = 0;//角加速度
    public float MaxVelocity = int.MaxValue;//最大速度

    [Header("发射器初始位置")]
    public float InitRotation = 0;//初始旋转角
    public float SenderAngleVelocity = 0;//发射器角速度
    public float SenderMaxAgnleVelocity = int.MaxValue;//最大角速度
    public float SenderAngleAcceleration = 0;
    public int Count = 0;//子弹数量
    public float LineAngle = 30;//子弹夹角
    public float SendInterval = 0.1f;//子弹间隔

    [Header("预制体")]
    public GameObject Prefab;

}
