using UnityEngine;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour
{
    public Vector3 LookAtPoint = Vector3.zero;
    public void Update()
    {
        transform.LookAt(LookAtPoint);
    }
}