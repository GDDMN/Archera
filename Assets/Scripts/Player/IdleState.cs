using System.Collections.Generic;
using UnityEngine;
public class IdleState : PlayerStates
{
  private PlayerMoveController _controller;

  public override void Exit()
  {
  }

  public override void Start(PlayerMoveController playerController)
  {
    Debug.Log("Set Idle State");

    _controller = playerController;
  }

  public override void Update()
  {
    FindEnemy();

    if (_controller.Enemy != null)
    {
      _controller.SetState(States.FIGHT);
      return;
    }  

  }

  private void FindEnemy()
  {
    _controller.SetEnemy(null);

    List<EnemyController> AllEnemies = _controller.AllEnemies;
    List<EnemyController> LiquidEnemies = new List<EnemyController>();
    RaycastHit hit;

    foreach(var enemy in AllEnemies)
    {
      Ray ray = new Ray(_controller.Transform.position, enemy.gameObject.transform.position - _controller.Transform.position);
      
      if(Physics.Raycast(ray, out hit))
      {
        if (hit.collider.gameObject.GetComponent<EnemyController>() != null)
          LiquidEnemies.Add(enemy);
      }
    }

    if (LiquidEnemies.Count == 0)
    {
      _controller.SetEnemy(null);
      return;
    }

    for(int i=0, j=0;i<LiquidEnemies.Count;i++)
    {
      if (_controller.Enemy == null)
      {
        _controller.SetEnemy(LiquidEnemies[j]);
        j++;
      }

      float newEnemyNear = (LiquidEnemies[i].transform.position - _controller.Transform.position).magnitude;
      float thisNear = (_controller.Enemy.transform.position - _controller.Transform.position).magnitude;
      
      if (thisNear < newEnemyNear)
      {
        _controller.SetEnemy(LiquidEnemies[i]);
      }
    }

    LiquidEnemies.Clear();
  }
}


