using UnityEngine;
public abstract class PlayerStates
{
  public abstract void Start(PlayerMoveController playerController);
  public abstract void Update();
  public abstract void Exit();

}

