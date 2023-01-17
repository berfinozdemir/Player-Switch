using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrainResource : MonoBehaviour
{
    private float nextTimeToPay = 0;
    private float paymentDelay = 0.1f;
    public int XSize, YSize, space;
    public List<Collectable> drianedCollectables;
    public Collectable collectablePrefab;
    public Transform DrainPoint;
    public List<Vector3> Positions;
    private void Start()
    {
        CreateResourcePositions();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Station"))
        {
            StartDrain();
        }
    }
    void StartDrain()
    {
        while(drianedCollectables.Count < Positions.Count)
        {
            CreateResource();
        }
    }
    void CreateResource()
    {
        var col = Instantiate(collectablePrefab, transform.position, Quaternion.identity, DrainPoint);
        col.transform.DOJump(GetPos(), 1, 1, 1).SetSpeedBased(true).OnComplete(() => {
            transform.localRotation = Quaternion.identity;
        });
        drianedCollectables.Add(col);
        nextTimeToPay = Time.time + paymentDelay;
    }
    void CreateResourcePositions()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < XSize; i++)
        {
            for (int j = 0; j < YSize; j++)
            {
                pos = DrainPoint.position + Vector3.right * space * i + Vector3.forward * j * space;

                Positions.Add(pos);
            }
        }
    }
    int index = 0;
    Vector3 GetPos()
    {
        var newPos = Positions[index];
        index++;
        return newPos;
    }


}
