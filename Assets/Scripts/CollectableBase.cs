using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    public Action OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        Collect();
        OnCollected();
    }

    protected abstract void Collect();
}
