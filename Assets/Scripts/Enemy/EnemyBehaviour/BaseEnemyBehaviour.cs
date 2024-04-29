using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyBehaviour 
{
  protected EnemyController _enemy;

  public BaseEnemyBehaviour(EnemyController enemy)
  {
    _enemy = enemy;
  }

  public abstract void Start();

  public abstract void Tick();

  public abstract void Exit();
}


