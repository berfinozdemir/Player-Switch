using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Stashable : MonoBehaviour
{
    public void CollectStashable(Transform target)
    {
        // var targetPos = stashParent.position + Vector3.up * pos;
        //transform.localPosition = target;

        transform.parent = target;
        transform.DOLocalJump(Vector3.zero, 1, 1, .5f).SetSpeedBased(true).OnComplete(() => {
            transform.localRotation = Quaternion.identity;
            //OnCompleteCollect?.Invoke();
        });



        //transform.parent = stashParent;
        //transform.DOLocalJump(target, 1, 1, 1).SetSpeedBased(true).OnComplete(() => {
        //    transform.localRotation = Quaternion.identity;
        //    //OnCompleteCollect?.Invoke();
        //});
    }
    public void PayStashable(Transform target, Action onCompletePay)
    {
        transform.DOLocalJump(target.position, 1, 1, 1).SetSpeedBased(true).OnComplete(() => {
            transform.localRotation = Quaternion.identity;
            onCompletePay?.Invoke();
            Destroy(gameObject);
        });
    }
    //public void DrainStashable(Transform target)
    //{
    //    transform.DOLocalJump(target.position, 2, 1, 3).SetSpeedBased(false).OnComplete(() => {
    //        transform.localRotation = Quaternion.identity;
    //        Destroy(gameObject);
    //    });
    //}

}
