using UnityEngine;

public class Player : MonoBehaviour
{
     [Header("移動速度"), Range(1, 200)]
    public float speed = 20;

    private Joystick joy;
    private Transform target; 
    private Rigidbody rig;

    private void Start()
    {     
        rig = GetComponent<Rigidbody>();                                 // 剛體欄位 = 取得原件<泛型>()
        // target = GameObject.Find("目標").GetComponent<Transform>();   // 寫法1
        target = GameObject.Find("目標").transform;                      // 寫法2
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動玩家方法
    /// <summary>
    private void Move()
    {
        float h = joy.Horizontal;
        float v = joy.Vertical;
        rig.AddForce(-h * speed, 0, -v * speed);
        // 取得此物件變型原件
        // 原本寫法 GetComponent<Transform>()
        // 簡寫 transform

        Vector3 posPlayer = transform.position;                                 // 取得玩家.座標
        Vector3 posTarget = new Vector3(posPlayer.x - h, 0, posPlayer.z - v);   // 目標座標 = 新 三維向量(玩家.x - 搖桿.x, y, 玩家.z - 搖桿.z)

        target.position = posTarget;                                            // 目標.座標 = 目標座標
    }
}
