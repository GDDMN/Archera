using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  protected NavMeshAgent _navAgent;

  [SerializeField] protected Animator _animator;
  [SerializeField] protected Transform _attackPoint;
  [SerializeField] protected PlayerController _player;
  [SerializeField] private EnemyBehaviourController _controller;

  public PlayerController Player => _player;
  public Vector3 AttackPointPos => _attackPoint.position;
  public Animator Animator => _animator;
  public NavMeshAgent Agent => _navAgent;


  private void Awake()
  {
    _navAgent = GetComponent<NavMeshAgent>();
    _controller.Initialize(this);
  }

  private void Update()
  {
    _controller.Tick();
  }


}
