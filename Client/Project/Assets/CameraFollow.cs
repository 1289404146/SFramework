using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //摄像机
    private Transform m_Transform;
    //人物主角
    private Transform player_Transform;

    private Vector3 offset;
    private float X=0f;
    private float Y= 6.95f;
    private float Z= -4.35f;

    void Start()
    {
        m_Transform = Camera.main.transform;
        player_Transform = transform;
        //offset是摄像机相对于人物主角的相对位置
        offset = new Vector3(X, Y, Z);
    }

    void LateUpdate()
    {
        //直接改变摄像机的位置（这种方式比较生硬，建议使用下一种插值的方式）
        //m_Transform.position = player_Transform.position + offset;

        //插值的方式控制摄像机的跟随
        m_Transform.position = Vector3.Lerp(m_Transform.position, player_Transform.position + offset, Time.deltaTime * 2);
    }
}
