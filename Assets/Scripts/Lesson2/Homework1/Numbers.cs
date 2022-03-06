using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    public NativeArray<int> numbers;
    private NumbersJob numbersJob;

    private void Start()
    {
        numbers = new NativeArray<int>(new int[] { 1, 5, 10, 11, 7, 8, 18, 20, 6, 12 }, Allocator.Persistent);

        Debug.Log($"Before: {numbers[0]},{numbers[1]},{numbers[2]},{numbers[3]},{numbers[4]},{numbers[5]},{numbers[6]}," +
            $"{numbers[7]},{numbers[8]},{numbers[9]}");

        numbersJob = new NumbersJob()
        {
            numbers = numbers
        };

        JobHandle jobHandle = numbersJob.Schedule();

        jobHandle.Complete();

        Debug.Log($"After: {numbers[0]},{numbers[1]},{numbers[2]},{numbers[3]},{numbers[4]},{numbers[5]},{numbers[6]}," +
            $"{numbers[7]},{numbers[8]},{numbers[9]}");

        numbers.Dispose();
    }
}
