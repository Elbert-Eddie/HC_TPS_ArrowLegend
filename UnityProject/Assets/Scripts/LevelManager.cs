using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("是否一開始顯示隨機技能")]
    public bool showRandomSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    [Header("隨機技能介面")]
    public GameObject randomSkill;

    private Animator door;

    private void Start()
    {
        door = GameObject.Find("門").GetComponent<Animator>();

        if (autoOpenDoor) Invoke("OpenDoor",10);        // 延遲調用("方法名稱",延遲時間)
        if (showRandomSkill) ShowRandomSkill();
    }

    /// <summary>
    /// 顯示隨機技能介面
    /// </summary>
    private void ShowRandomSkill()
    {
        randomSkill.SetActive(true);
    }

    /// <summary>
    /// 播放開門動畫
    /// </summary>
    private void OpenDoor()
    {
        door.SetTrigger("開門");      // 動畫控制器.設定觸發("參數名稱")
    }
}
