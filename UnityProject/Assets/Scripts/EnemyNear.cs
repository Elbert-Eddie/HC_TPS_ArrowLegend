using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(DelayAttack());      // 啟動協程
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.attackDelay);

        RaycastHit hit;     // 射線碰撞資訊 - 存放射線碰到的內容

        // out 存放參數資訊
        // 物理.射線碰撞(中心點，方向，長度)
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward,out hit, data.attackRange))
        {
            print("打到了" + hit.collider.gameObject);
            // 取得玩家元件.受傷方法(怪物.攻擊力)
            hit.collider.GetComponent<Player>().Hit(data.attack);
        }
    }

    // Ctrl + M O 摺疊
    // Ctrl + M L 展開

    // 事件 : 繪製圖示
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;       // 圖示.顏色 = 顏色

        // 前方 : transform.forward
        // 右方 : transform.right
        // 上方 : transform.up

        // 圖示.繪製射線(中心點，方向)
        Gizmos.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward*data.attackRange);
    }
}
