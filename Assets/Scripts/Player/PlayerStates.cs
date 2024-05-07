using UnityEngine;
public abstract class PlayerStates
{
  public abstract void Start(PlayerController playerController);
  public abstract void Update();
  public abstract void Exit();

}

