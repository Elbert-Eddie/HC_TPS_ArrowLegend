using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("上方限制")]
    public float top;
    [Header("下方限制")]
    public float bottom;

    private Transform player;

    private void Start()
    {
        player = GameObject.Find("玩家").transform;
    }

    // 在 Update 之後執行 : 適合做攝影機、物件追蹤
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 攝影機追蹤玩家方式
    /// </summary>
    private void Track()
    {
        Vector3 posPlayer = player.position;        // 玩家.座標
        Vector3 posCamera = transform.position;     // 變形.座標

        posPlayer.x = 0;    // 限制 X 在 0
        posPlayer.y = 16;   // 限制 Y 在 16 (原攝影機 Y)
        posPlayer.z += 15;  // 往玩家後面位移

        // z = 數學.夾住(玩家.z，上限，下限) 
        posPlayer.z = Mathf.Clamp(posPlayer.z, top, bottom);

        // 變形.座標 = 三維向量.插值(攝影機, 玩家, 百分比)
        transform.position = Vector3.Lerp(posCamera, posPlayer, 0.5f* Time.deltaTime*speed);
    }
}
