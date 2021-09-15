using UnityEngine;

public class CollectionBehavior : MonoBehaviour
{
    public CollectableSO collectedObj;
    
    // Start is called before the first frame update
    void Start()
    {
        if (collectedObj.collected)
        {
            Destroy(gameObject);
        }   
    }
}
