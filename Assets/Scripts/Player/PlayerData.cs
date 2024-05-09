using UnityEngine;
using System;

[Serializable]
public struct PlayerData
{
  public int health;
  public float speed;
  public States playerState;
  public Vector2 moveDirection;
}
