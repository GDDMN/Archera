using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : EnemyController
{
  private BaseEnemyBehaviour ActiveState;


  private void Awake()
  {
    WalkEnemyBehaviour walk = new WalkEnemyBehaviour(this);
    ActiveState = walk;
    _navAgent = GetComponent<NavMeshAgent>();
  }

  private void Update()
  {
    ActiveState.Tick();
  }


}
