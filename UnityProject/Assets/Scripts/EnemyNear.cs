using UnityEngine;

public class EnemyNear : Enemy
{
    public override void Move()
    {
        agent.SetDestination(player.position);      // 代理器.設定目的地(玩家.座標)
        ani.SetBool("跑步開關",true);               // 開起跑步開關
    }
}
