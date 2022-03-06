using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct SumPosJob : IJobParallelFor
{
    public NativeArray<Vector3> positions;
    public NativeArray<Vector3> velocities;
    public NativeArray<Vector3> finalPositions;

    public void Execute(int index)
    {
        finalPositions[index] = positions[index] + velocities[index];
    }
}
