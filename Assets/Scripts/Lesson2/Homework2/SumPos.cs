using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class SumPos : MonoBehaviour
{
    public NativeArray<Vector3> positions;
    public NativeArray<Vector3> velocities;
    public NativeArray<Vector3> finalPositions;

    private SumPosJob sumPosJob;
    private JobHandle jobHandle;

    private void Start()
    {
        positions = new NativeArray<Vector3>(10, Allocator.Persistent);
        velocities = new NativeArray<Vector3>(10, Allocator.Persistent);
        finalPositions = new NativeArray<Vector3>(10, Allocator.Persistent);

        for (int i = 0; i < 10; i++)
        {
            positions[i] = Random.insideUnitSphere * Random.Range(0, 20);
            velocities[i] = Random.insideUnitSphere * Random.Range(0, 20);
        }

        sumPosJob = new SumPosJob()
        {
            positions = positions,
            velocities = velocities,
            finalPositions = finalPositions
        };

        jobHandle = sumPosJob.Schedule(finalPositions.Length,0);
        jobHandle.Complete();

        for(int i = 0; i < finalPositions.Length; i++)
        {
            Debug.Log($"{positions[i]} + {velocities[i]} = {finalPositions[i]}");
        }

        positions.Dispose();
        velocities.Dispose();
        finalPositions.Dispose();
    }
}
