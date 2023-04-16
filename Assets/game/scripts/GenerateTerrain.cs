using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class GenerateTerrain : MonoBehaviour
{
    public int size;
    public int lod;
    [SerializeField] MeshFilter meshFilter;
    int[] meshTriangles;
    Vector3[] vertices;
    public bool generate;

    [Range(0f, 10f)]
    public float pow = 1f;
    [Range(0f, 1f)]
    public List<float> octaveFreq = new List<float>();
    [Range(-10f, 10f)]
    public List<float> octaveTX = new List<float>();
    [Range(-10f, 10f)]
    public List<float> octaveTZ = new List<float>();
    [Range(-10f, 1000f)]
    public List<float> heights = new List<float>();
    public List<bool> invert = new List<bool>();


    // Start is called before the first frame update
    void Start()
    {
        gen(size, lod);
        Mesh mesh = new Mesh();
        //MeshFilter meshFilter = new MeshFilter();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = meshTriangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if(generate)
        {
            generate = false;
            gen(size, lod);

            Mesh mesh = new Mesh();

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = meshTriangles;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
        }
    }
    void OnValidate()
    {
        gen(size, lod);

        Mesh mesh = new Mesh();

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = meshTriangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
    public void gen(int size, int lod)
    {


        vertices = new Vector3[(size + 1) * (size + 1)];
        for (int i = 0, z = 0; z <= size; z += lod)
        {
            for (int x = 0; x <= size; x += lod)
            {
                float height = 0;

                for (int j = 0; j < octaveFreq.Count; j++)
                {
                    if(invert[j])
                        height += noise.cellular(new float2((transform.position.z + z + octaveTZ[j]) * octaveFreq[j], (transform.position.x + x + octaveTX[j]) * octaveFreq[j])).x * heights[j];
                    else
                        height -= noise.cellular(new float2((transform.position.z + z + octaveTZ[j]) * octaveFreq[j], (transform.position.x + x + octaveTX[j]) * octaveFreq[j])).x * heights[j];

                }


                vertices[i] = new Vector3(x - size / 2, height, z - size / 2);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;

        meshTriangles = new int[size * size * 6];

        for (int z = 0; z < size / lod; z++)
        {
            for (int x = 0; x < size / lod; x++)
            {
                meshTriangles[tris + 0] = (vert + 0);
                meshTriangles[tris + 1] = (vert + (size / lod) + 1);
                meshTriangles[tris + 2] = (vert + 1);
                meshTriangles[tris + 3] = (vert + 1);
                meshTriangles[tris + 4] = (vert + (size / lod) + 1);
                meshTriangles[tris + 5] = (vert + (size / lod) + 2);

                vert += 1;
                tris += 6;
            }
            vert += 1;
        }
    }
}
