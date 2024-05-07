using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtable
{



  public abstract void Hurt(int damage);

  public abstract void Death();
}

