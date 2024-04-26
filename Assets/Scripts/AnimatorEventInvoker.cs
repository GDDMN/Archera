using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimatorEventInvoker : MonoBehaviour
{
  public event Action OnShoot;

  public void InvokeShootingEvent()
  {
    OnShoot.Invoke();
  }
}
