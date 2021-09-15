using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectionsSO : CollectableSO
{
  public List<CollectableSO> collection;

  public void Collect(CollectableSO obj)
  {
    collection.Add(obj);
    collected = true;
  }
}
