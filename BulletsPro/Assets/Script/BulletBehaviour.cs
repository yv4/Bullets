using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float LinearVelocity=0;//���ٶ�
    public float Acceleration = 0;//�߼��ٶ�
    public float AngleVelocity = 0;//���ٶ�
    public float AngleAcceleration = 0;//�Ǽ��ٶ�
    public float MaxVelocity = int.MaxValue;//����ٶ�
    public float LifeTime = 5;

    public BulletPool pool;

    //0.02��ִ��һ�� һ��50��
    private void FixedUpdate()
    {
        //���µ�ǰ�����ٶȺͽ��ٶ�
        LinearVelocity = Mathf.Clamp(LinearVelocity+Acceleration * Time.fixedDeltaTime,-MaxVelocity,MaxVelocity);
        AngleVelocity += AngleAcceleration * Time.fixedDeltaTime;
        //�����ӵ�λ��
        transform.Translate(LinearVelocity * Vector2.right * Time.fixedDeltaTime,Space.Self);
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,1) * AngleVelocity * Time.deltaTime);
        //����������������
        LifeTime -= Time.deltaTime;
        if(LifeTime<=0)
        {
            Destroy(gameObject);
        }
    }

}
