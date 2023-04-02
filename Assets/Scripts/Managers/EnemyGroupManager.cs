using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    public GameObject FirstGroupOriginal;
  

  public PassiveEgroup CreateEnemyGroup() {
      GameObject NewGroup = Instantiate(FirstGroupOriginal);
      PassiveEgroup GroupScript = NewGroup.GetComponent <PassiveEgroup>();
      return GroupScript;
  }
}
