using UnityEngine;

public class LearnFor : MonoBehaviour
{
    public LearnArray learnArray;

    private void Start()
    {
        // while 當
        // 當 () 布林值為 true 一直執行 {} 敘述
        int count = 50;
        while (count > 0)
        {
            print("while 迴圈：" + count);
            count--;
        }

        // for
        // (初始值; 條件; 迭代器)
        // 條件為 true 時執行 {}
        for (int i =0; i < 10; i++)
        {
            print("for 迴圈：" + i);
        }

        for (int i = 0; i < learnArray.players.Length; i++)
        {
            print(learnArray.players[i].name);
        }
    }
}
