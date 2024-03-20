using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create BulletAsset")]
public class BelletObject : ScriptableObject
{
    [Header("�ӵ���ʼλ��")]
    public float LifeCycle = 5;//��������
    public float LinearVelocity = 0;//���ٶ�
    public float Acceleration = 0;//�߼��ٶ�
    public float AngleVelocity = 0;//���ٶ�
    public float AngleAcceleration = 0;//�Ǽ��ٶ�
    public float MaxVelocity = int.MaxValue;//����ٶ�

    [Header("��������ʼλ��")]
    public float InitRotation = 0;//��ʼ��ת��
    public float SenderAngleVelocity = 0;//���������ٶ�
    public float SenderMaxAgnleVelocity = int.MaxValue;//�����ٶ�
    public float SenderAngleAcceleration = 0;
    public int Count = 0;//�ӵ�����
    public float LineAngle = 30;//�ӵ��н�
    public float SendInterval = 0.1f;//�ӵ����

    [Header("Ԥ����")]
    public GameObject Prefab;

}
