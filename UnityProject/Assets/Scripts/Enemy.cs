using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;         // 敵人資料

    protected NavMeshAgent agent;     // 導覽代理器
    protected Transform player;       // 玩家變形
    protected Animator ani;

    protected float timer;             // 計時器

    protected void Start()
    {
        // 先取得原件
        ani = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
        player = GameObject.Find("玩家").transform;
        agent.SetDestination(player.position);
    }

    private void Update()
    {
        Move();
    }

    // protected 不允許外部類別存取，允許子類別存取
    protected virtual void Attack()
    {
        timer = 0;                          // 計時器歸零
        ani.SetTrigger("攻擊觸發");         // 攻擊動畫
    }

    // virtual 虛擬 : 讓子類別可以複寫
    protected virtual void Move()
    {
        agent.SetDestination(player.position);      // 代理器.設定目的地(玩家.座標)

        Vector3 posTarget = player.position;    // 區域變數 目標座標 = 玩家.座標
        posTarget.y = transform.position.y;     // 目標座標.y = 本身.y
        transform.LookAt(posTarget);            // 看著(目標座標)

        if (agent.remainingDistance <= 1.5f)    // 如果 距離 <=
        {
            Wait();
        }
        else
        {
            agent.isStopped = false;             // 代理器.是否停止 = 否
            ani.SetBool("跑步開關", true);     // 開啟跑步開關
        }
    }

    protected virtual void Wait()
    {
        agent.isStopped = true;             // 代理器.是否停止 = 是
        agent.velocity = Vector3.zero;      // 代理器.加速度 = 零
        ani.SetBool("跑步開關", false);     // 關閉跑步開關

        if (timer <= data.cd)               // 如果 計時器 <= 冷卻時間
        {
            timer += Time.deltaTime;        // 時間累加
        }
        else
        {
            Attack();                       // 否則 計時器 > 冷卻時間 攻擊
        }
    }

    private void Hit()
    {
        
    }

    private void Dead()
    {

    }
}
