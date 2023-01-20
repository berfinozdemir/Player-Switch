using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CreateTrainCollectables : MonoBehaviour
{
    public List<Transform> transforms;
    public Collectable collectablePrefab;
    public List<Collectable> Collectables;

    private void Start()
    {
        SpawnCollectables();

    }
    void SpawnCollectables()
    {
        foreach (var item in transforms)
        {
            var resource = Instantiate(collectablePrefab, item.position, Quaternion.identity, this.transform);
            Collectables.Add(resource);
            resource.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);
            Debug.Log("col");
        }
    }
}
