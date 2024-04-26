using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ProjectileData
{
  public float Speed;
  public int Damage;
}


public class Projectile : MonoBehaviour
{
  [SerializeField] private ProjectileData _data;
  private Vector3 _direction;

  public void Init(Vector3 startPos, Vector3 targetPos)
  {
    _direction = targetPos - startPos;
    Quaternion rotation = Quaternion.LookRotation(_direction, Vector3.up);
    transform.rotation = rotation;

    Destroy(this.gameObject, 1f);
  }

  public void Update()
  {
    transform.position += _direction * (_data.Speed * Time.deltaTime);
  }
}
