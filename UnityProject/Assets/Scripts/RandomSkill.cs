using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// [添加元件(類型(任何元件類型))] - 套用此腳本實執行
[RequireComponent(typeof(AudioSource))]
public class RandomSkill : MonoBehaviour
{
    #region 欄位
    [Header("圖片隨機")]
    public Sprite[] spritesRandom;
    [Header("圖片")]
    public Sprite[] sprites;
    [Header("間隔時間"), Range(0f, 1f)]
    public float speed = 0.1f;
    [Header("次數"), Range(1,10)]
    public int count = 3;
    [Header("音效區域")]
    public AudioClip soundRandom;
    public AudioClip soundSkill;
    [Header("r技能名稱")]
    public string[] skillsName = { "連射", "正向箭", "後向箭", "平向箭", "加血", "加傷", "加攻速", "加暴擊" };
    private Image imgSkill;
    private AudioSource aud;
    private Text textSkill;
    #endregion

    private int randomIndex;
    private Button btn;
    private GameObject objSkill;

    private void Start()
    {
        imgSkill = GetComponent<Image>();
        aud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        textSkill = transform.GetChild(0).GetComponent<Text>();     // 變形.取得子物件(索引值)
        objSkill = GameObject.Find("隨機技能");

        StartCoroutine(StartRandom());                              // 啟動協程(開始隨機())

        btn.onClick.AddListener(ChooseSkill);
    }

    /// <summary>
    /// 選取技能
    /// </summary>
    private void ChooseSkill()
    {
        print("選取技能:" + skillsName[randomIndex]);
        objSkill.SetActive(false);              //隨機技能.啟動設定(取消)
    }

    /// <summary>
    /// 開始隨機效果
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartRandom()
    {
        btn.interactable = false;       // 取消互動
        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < spritesRandom.Length; i++)
            {
                imgSkill.sprite = spritesRandom[i];     // 技能圖片.圖片 = 圖片隨機[索引值]
                aud.PlayOneShot(soundRandom, 0.1f);     // 音源.播放一次音效(音效片段,音量)
                yield return new WaitForSeconds(speed);  // 等待
            }
        }
        randomIndex = Random.Range(0, sprites.Length);      // 隨機值 = 隨機.範圍(最小,最大)
        imgSkill.sprite = sprites[randomIndex];             // 技能圖片.圖片 = 技能圖片[隨機值]
        textSkill.text = skillsName[randomIndex];           // 技能文字.文字 = 技能名稱[隨機值]
        aud.PlayOneShot(soundSkill, 0.7f);                  // 音源.播放一次音效(音效片段,音量)
        btn.interactable = true;            // 啟動互動
    }
}
