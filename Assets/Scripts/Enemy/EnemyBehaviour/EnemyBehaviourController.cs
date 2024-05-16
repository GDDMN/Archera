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


  public List<BaseEnemyBehaviour> Behaviours => _behaviourList; 

  public void Initialize(EnemyController enemy)
  {
    foreach(var beh in _behaviourList)
    {
      beh.Initialize(enemy);
    }

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
    _activeState = _behaviourList.Find(beh => beh.EnemyState == _activeState.NextEnemyState);
    _activeState.Start();
  }

  public EnemyBehaviourController Clone()
  {
    EnemyBehaviourController controller = Instantiate(this);
    controller.Behaviours.Clear();

    foreach (var node in this.Behaviours)
      controller.Behaviours.Add(node.Clone());

    return controller;
  }
}
