using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    public Stashable stashablePrefab;
    private void Update()
    {
        
    }
    public Stashable Collect()
    {
        var stashable = Instantiate(stashablePrefab, null);
        stashable.transform.position = transform.position + Vector3.up * 1.5f;
        GetComponent<Collider>().enabled = false;
        transform.localScale = Vector3.zero;
        StartCoroutine(SetActiveRoutine());
        return stashable;
    }

    private IEnumerator SetActiveRoutine()
    {
        yield return new WaitForSeconds(5f);
        transform.DOScale(Vector3.one,.5f).SetEase(Ease.OutBack, 2.5f);
        GetComponent<Collider>().enabled = true;
    }
}
