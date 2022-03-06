using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CubeRotationController : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int speed;

    private RotationJob _rotationJob;
    private TransformAccessArray transformAccessArray;
    private Transform[] _transforms = new Transform[1];

    public NativeArray<float> rotationY;

    

    private void Start()
    {
        rotationY = new NativeArray<float>(1, Allocator.Persistent);
        _transforms[0] = _cube.transform;
        transformAccessArray = new TransformAccessArray(_transforms);
    }

    private void Update()
    {
        _rotationJob = new RotationJob()
        {
            rotationY = rotationY,
            angle = 10,
            speed = speed,
            deltaTime = Time.deltaTime
        };

        JobHandle rotationHandle = _rotationJob.Schedule(transformAccessArray);

        rotationHandle.Complete();

        _cube.transform.rotation = Quaternion.Euler(0, rotationY[0], 0);
    }

    private void OnDestroy()
    {
        rotationY.Dispose();
        transformAccessArray.Dispose();
    }
}
