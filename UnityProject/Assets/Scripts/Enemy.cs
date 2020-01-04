using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyData data;         // 敵人資料

    public NavMeshAgent agent;     // 導覽代理器
    public Transform player;       // 玩家變形
    public Animator ani;

    public float timer;             // 計時器

    private void Start()
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

    public virtual void Attack()
    {

    }

    // virtual 虛擬 : 讓子類別可以複寫
    public virtual void Move()
    {
       
    }

    public virtual void Wait()
    {

    }

    private void Hit()
    {
        
    }

    private void Dead()
    {

    }
}
