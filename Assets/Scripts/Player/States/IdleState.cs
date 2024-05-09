using System.Collections.Generic;
using UnityEngine;
public class IdleState : PlayerStates
{

  public IdleState(PlayerController controller) : base(controller) 
  {

  }

  public override void Exit()
  {
  }

  public override void Start()
  {
    Debug.Log("Set Idle State");
  }

  public override void Update()
  {
    Aiming();

    if (_controller.Enemy != null)
    {
      _controller.SetState(States.FIGHT);
      return;
    }  

  }

  private void Aiming()
  {
    _controller.SetEnemy(null);

    List<EnemyController> AllEnemies = _controller.AllEnemies;
    List<EnemyController> LiquidEnemies = new List<EnemyController>();

    LiquidEnemies = FindVisiableEnemies(AllEnemies);

    if (LiquidEnemies.Count == 0)
    {
      _controller.SetEnemy(null);
      return;
    }

    FindNearEnemy(LiquidEnemies);
    LiquidEnemies.Clear();
  }

  private List<EnemyController> FindVisiableEnemies(List<EnemyController> AllEnemies)
  {
    List<EnemyController> LiquidEnemies = new List<EnemyController>();
    RaycastHit hit;

    foreach (var enemy in AllEnemies)
    {
      Ray ray = new Ray(_controller.Transform.position, enemy.gameObject.transform.position - _controller.Transform.position);

      if (Physics.Raycast(ray, out hit))
      {
        if (hit.collider.gameObject.GetComponent<EnemyController>() != null)
          LiquidEnemies.Add(enemy);
      }
    }

    return LiquidEnemies;
  }

  private void FindNearEnemy(List<EnemyController> LiquidEnemies)
  {
    for (int i = 0, j = 0; i < LiquidEnemies.Count; i++)
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
  }
}


