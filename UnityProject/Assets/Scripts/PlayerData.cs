﻿using UnityEngine;

[CreateAssetMenu(fileName ="玩家資料", menuName ="Elbert/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("血量")]
    public float hp = 200;
}
