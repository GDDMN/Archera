using System.Collections.Generic;
using UnityEngine;


public enum BehaviourState
{
  DISABLE,
  ACTIVE,
  COMPLETE
}


[CreateAssetMenu(fileName = "EnemyBehaviourGroup", menuName = "EnemyBehaviour/BehaviourGroup")]
public class EnemyBehaviourController : ScriptableObject
{
  [SerializeField] private List<BaseEnemyBehaviour> _behaviourList = new List<BaseEnemyBehaviour>();
  private BaseEnemyBehaviour _activeState;


  public void Initialize(EnemyController enemy)
  {
    foreach(var beh in _behaviourList)
      beh.Initialize(enemy);

    _activeState = _behaviourList.Find(beh => beh.BehaviourState == BehaviourState.DISABLE);
    _activeState.Start();
  }

  public void Tick()
  {
    BehaviourState StetaActiveBeh = _activeState.Tick();

    if (StetaActiveBeh == BehaviourState.COMPLETE)
      SwitchState();

  }

  private void SwitchState()
  {
    _activeState = _behaviourList.Find(beh => beh.BehaviourState == BehaviourState.DISABLE);
    _activeState.Start();
  }
}
