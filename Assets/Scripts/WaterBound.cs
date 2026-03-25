using UnityEngine;

public class WaterBound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
