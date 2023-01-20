using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public List<Vector3> StashPositions;
    public int XAmount;
    public int YAmount;
    public int ZAmount;
    public float Space;

    public Transform FirstStashPoint;
    public Transform test;

    public List<Stashable> CollectedObjects;
    private void Start()
    {
        CreateStashPositions();
        //foreach (var item in StashPositions)
        //{
        //    var ball = Instantiate(test, item, Quaternion.identity);
        //    ball.transform.SetParent(this.transform);
        //}
    }
    void CreateStashPositions()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < XAmount; i++)
        {
            for (int j = 0; j < YAmount; j++)
            {
                for (int k = 0; k < ZAmount; k++)
                {
                    pos = FirstStashPoint.localPosition + Vector3.right * Space * i + Vector3.forward * k * Space + Vector3.up * Space * j;
                    StashPositions.Add(pos);
                    //Instantiate(test, pos, Quaternion.identity, this.transform);
                }

            }
        }
    }
    private int index;
    Vector3 GetStashPos()
    {
        var newPos = StashPositions[index];
        index++;
        return newPos;
    }
    public void TakeResource(Collectable collectedObj)
    {
        if (CollectedObjects.Count >= XAmount * YAmount * ZAmount) return;
        var stashable = collectedObj.Collect();
        stashable.CollectStashable(this.transform,GetStashPos());
        CollectedObjects.Add(stashable);
    }
    public Stashable RemoveStash()
    {
        if (CollectedObjects.Count <= 0)
            return null;

        var stashable = CollectedObjects[CollectedObjects.Count - 1];

        CollectedObjects.Remove(stashable);
        index--;
        stashable.transform.parent = null;

        return stashable;
    }
    public bool IsStashFull()
    {
        if (CollectedObjects.Count >= XAmount * YAmount * ZAmount)
            return true;
        else return false;
    }
}
