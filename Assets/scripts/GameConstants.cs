﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
    public static Vector2 PoolStartPosition = new Vector2(0f, -10f);
    public static Vector3 PlayerMissileSpawnLocation = new Vector3(0, -3.6f);
    public static float PlayerMissileSpeedPerSecond = 240f;
    public static float EnemyMissileSpeedPerSecond = 45f;
    public static float GameFloorYPosition = -4.20f;
}
