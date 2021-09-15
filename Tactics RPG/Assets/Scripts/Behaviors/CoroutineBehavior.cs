using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public bool canRun = true;
    public float holdTime = 2f;
    public UnityEvent startEvent;
    
    private WaitForSeconds wfs;
    
    private IEnumerator Start()
    {
        wfs = new WaitForSeconds(holdTime);
        while (canRun)
        {
            yield return wfs;
            startEvent.Invoke();
        }
    }
}
