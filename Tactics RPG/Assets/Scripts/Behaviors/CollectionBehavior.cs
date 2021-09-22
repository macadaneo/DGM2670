using System;
using UnityEngine;

public class CollectionBehavior : MonoBehaviour
{
    private GameObject art;
    private SpriteRenderer artSpriteRenderer;
    public CollectableSO collectedObj;
    public CollectionsSO collection;

    void Awake()
    {
     ConfigCollectable();
    }

    public void SwapCollectable(CollectableSO collectable)
    {
        collectedObj = collectable;
        ConfigCollectable();
    }
    
    private void ConfigCollectable()
    {
        art = GetComponent<Transform>().gameObject;
        artSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (artSpriteRenderer != null)
        {
            //artSpriteRenderer.sprite = collectedObj.art2D;
            //artSpriteRenderer.color = collectedObj.artColorTint;
        }
        EnableDisableCollectable(!collectedObj.collected);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        collection.Collect(collectedObj);
        EnableDisableCollectable(false);
    }


    private void EnableDisableCollectable(bool value)
    {
        //ArticulationBody.SetActive(value);
        GetComponent<Collider>().enabled = value;
    }
}
