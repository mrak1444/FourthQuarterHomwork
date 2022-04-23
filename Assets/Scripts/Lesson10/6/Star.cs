using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Star : MonoBehaviour
{
    private Mesh _mesh;

    [SerializeField] private Vector3 _point = Vector3.up;
    [SerializeField] private int _numberOfPoints = 10;

    private Vector3[] _vertices;
    private int[] _triangles;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();

        _mesh.name = "Star Mesh";
        _vertices = new Vector3[_numberOfPoints + 1];
        _triangles = new int[_numberOfPoints * 3];
        float angle = -360f / _numberOfPoints;

        for (int v = 1, t = 1; v < _vertices.Length; v++, t += 3)
        {
            _vertices[v] = Quaternion.Euler(0f, 0f, angle * (v - 1)) * _point;
            _triangles[t] = v;
            _triangles[t + 1] = v + 1;
        }

        _triangles[_triangles.Length - 1] = 1;
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
    }
}