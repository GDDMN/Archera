using UnityEngine;

public class FightState : PlayerStates
{
  private PlayerMoveController _controller;

  public override void Exit()
  {
    _controller.SetState(States.IDLE);
  }

  public override void Start(PlayerMoveController playerController)
  {
    Debug.Log("Set Fight State");

    _controller = playerController;
  }

  public override void Update()
  {
    RotateToEnemy();
  }

  private void RotateToEnemy()
  {

  }
}


