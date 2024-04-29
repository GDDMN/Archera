using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : EnemyController
{

  [SerializeField] private EnemyBehaviourController _controller;

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
