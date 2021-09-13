using UnityEngine;

public class InstancingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnInstance(GameObject obj)
    {
        Instantiate(obj);
    }
}
