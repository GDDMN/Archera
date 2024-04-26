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
    if (_controller.Enemy != null)
      _controller.SetState(States.FIGHT);

  }
}


