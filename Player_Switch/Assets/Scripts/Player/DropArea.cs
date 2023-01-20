using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;

public class DropArea : MonoBehaviour
{
    public int CollectedResourceCount;
    public Transform FirstPos;
    public Stashable StashablePrefab;
    public Collectable CollectablePrefab;
    public Action AllResourcesTaken;
    private void Update()
    {
        if (CollectedResourceCount == 0)
            AllResourcesTaken?.Invoke();
    }
    public void Drain(Stashable stashable)
    {
        CollectedResourceCount++;

        stashable.DrainStashable(FirstPos);
        var collectable = Instantiate(CollectablePrefab, transform);
        
        collectable.transform.DOJump(FirstPos.position, 3, 1, 1).SetSpeedBased(true);//.OnComplete(()=> Destroy(collectable.gameObject));
        CollectedResourceCount++;
        
    }
    public Collectable CreateStashable()
    {
        ResourceTaken();
        return Instantiate(CollectablePrefab, transform);
    }
    public void ResourceTaken()
    {
        CollectedResourceCount--;
    }
    public void PaymentCompleted()
    {
       
    }
   
}
