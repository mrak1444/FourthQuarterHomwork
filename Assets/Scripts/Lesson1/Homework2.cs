using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Homework2 : MonoBehaviour
{
    void Start()
    {
        RunTask();
    }

    private async void RunTask()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken cancelToken = cancelTokenSource.Token;

        Task task1 = Task.Run(() => TaskSecond(cancelToken));
        Task task2 = Task.Run(() => TaskFrames(cancelToken));
        await Task.WhenAll(task1, task2);
        Debug.Log("Все задачи выполнены");
        cancelTokenSource.Cancel();
        cancelTokenSource.Dispose();
    }

    private async Task TaskSecond(CancellationToken cancelToken)
    {
        int i = 1;
        while (i < 1000)
        {
            if (cancelToken.IsCancellationRequested) Debug.Log("Прервано");
            await Task.Delay(100);
            i += 100;
        }
        Debug.Log("Одна секунда прошла");
    }

    private async Task TaskFrames(CancellationToken cancelToken)
    {
        int i = 1;
        while (i < 60)
        {
            if (cancelToken.IsCancellationRequested) Debug.Log("Прервано");
            await Task.Yield();
            i++;
        }

        Debug.Log($"{i} кадров прошли");
    }
}
