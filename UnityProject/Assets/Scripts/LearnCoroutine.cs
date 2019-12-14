using UnityEngine;
using System.Collections;   // 引用 系統.集合 API

public class LearnCoroutine : MonoBehaviour
{
    // 傳回類型 IEnumerator 傳回等待時間
    public IEnumerator DelayEffect()
    {
        print("開始協程");

        yield return new WaitForSeconds(3);     // 傳回 新 等待秒數(秒)

        print("三秒後");

        yield return new WaitForSeconds(3);

        print("再三秒後");

    }

    private void Start()
    {
        // 啟動協程(協程名稱())
        StartCoroutine(DelayEffect());
    }
}
