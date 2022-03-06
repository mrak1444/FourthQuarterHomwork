using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

public struct RotationJob : IJobParallelForTransform
{
    public NativeArray<float> rotationY;

    public int angle;
    public int speed;
    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        float y = transform.rotation.eulerAngles.y;
        y += angle * speed * deltaTime;
        rotationY[index] = y;
    }
}
