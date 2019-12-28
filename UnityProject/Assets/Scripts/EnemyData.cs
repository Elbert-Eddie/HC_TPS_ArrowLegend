using UnityEngine;

// 建立素材選項(檔案名稱，選項名稱)
[CreateAssetMenu(fileName = "敵人資料", menuName = "Elbert/EnemyData")]
public class EnemyData : ScriptableObject       // 腳本化物件 將資料儲存於 Project
{
    [Header("血量"), Range(100, 3000)]
    public float hp = 100;
    [Header("攻擊力"), Range(1, 1000)]
    public float attack = 10;
    [Header("移動速度"), Range(0, 200)]
    public float speed = 1.5f;
    [Header("攻擊冷卻時間"), Range(1, 10)]
    public float cd = 3.5f;
}
