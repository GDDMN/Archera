using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : MonoBehaviour
{
  protected NavMeshAgent _navAgent;

  [SerializeField] protected Animator _animator;
  [SerializeField] protected Transform _attackPoint;
  [SerializeField] protected PlayerMoveController _player;

  public PlayerMoveController Player => _player;
  public Vector3 AttackPointPos => _attackPoint.position;
  public Animator Animator => _animator;
  public NavMeshAgent Agent => _navAgent;
}
