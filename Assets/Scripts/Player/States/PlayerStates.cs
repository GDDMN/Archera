using UnityEngine;
public abstract class PlayerStates
{
  protected PlayerController _controller;

  public PlayerStates(PlayerController controller)
  {
    _controller = controller;
  }

  public abstract void Start();
  public abstract void Update();
  public abstract void Exit();

}

