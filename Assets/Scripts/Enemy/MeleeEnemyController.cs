using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : EnemyController
{
  [SerializeField] private PlayerMoveController _player;


  private void Awake()
  {
    _navAgent = GetComponent<NavMeshAgent>();
  }

  private void Update()
  {
    FindWayToPlayer();
    _animator.SetFloat("Speed", _navAgent.speed);
  }

  private void FindWayToPlayer()
  {
    if (_player == null)
      return;

    _navAgent.SetDestination(_player.Transform.position);
  }
}
