using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

public struct NumbersJob : IJob
{
    public NativeArray<int> numbers;
    public void Execute()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if(numbers[i] > 10)
            {
                numbers[i] = 0;
            }
        }
    }
}
