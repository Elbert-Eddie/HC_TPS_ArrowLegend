﻿using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(1, 200)]
    public float speed = 20;

    private Joystick joy;
    private Transform target; 
    private Rigidbody rig;
    private Animator ani;
    #endregion

    private LevelManager levelManager;  // 關卡管理器

    #region 事件
    private void Start()
    {     
        rig = GetComponent<Rigidbody>();                                 // 剛體欄位 = 取得原件<泛型>()
        ani = GetComponent<Animator>();
        // target = GameObject.Find("目標").GetComponent<Transform>();   // 寫法1
        target = GameObject.Find("目標").transform;                      // 寫法2
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
        levelManager = FindObjectOfType<LevelManager>();                 // 透過類型尋找物件
    }

    private void FixedUpdate()
    {
        Move();
    }

    // 觸發事件 : 碰到勾選 IsTrigger 物件執行一次
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "傳送區域")
        {
            levelManager.StartCoroutine("LoadLevel");
        }
    }

    #endregion

    #region 方法
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

        posTarget.y = posPlayer.y;      // 目標.y = 玩家.y(避免吃土)

        transform.LookAt(posTarget);    // 變形.看著(座標)

        // 水平 1 、 -1
        // 垂直 1 、 -1
        // 動畫控制器.設定布林值(參數名稱，布林值)
        ani.SetBool("跑步開關", h != 0 || v != 0);
    }

    private void Attack()
    {
        ani.SetTrigger("攻擊觸發");  // 播放攻擊動畫 SetTrigger("參數名稱")
    }

    private void Hit(float damage)
    {

    }

    private void Dead()
    {
        ani.SetBool("死亡動畫", true);  // 播放死亡動畫 SetBool("參數名稱", 布林值)
    }
    #endregion
}
