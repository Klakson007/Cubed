using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setupWorld_M : MonoBehaviour
{
    public bool gen;
    public int size = 2;
    public GameObject chunk;
    public List<GameObject> chunks;

    private void OnValidate()
    {
        gen = false;
        foreach(GameObject chnk in chunks)
        {
            Destroy(chnk);
        }

        chunks.Clear();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject tmp = Instantiate(chunk, new Vector3(i * chunk.GetComponent<GenerateTerrain>().size, 0, j * chunk.GetComponent<GenerateTerrain>().size), Quaternion.identity);
                chunks.Add(tmp);
                tmp.GetComponent<GenerateTerrain>().gen(chunk.GetComponent<GenerateTerrain>().size, chunk.GetComponent<GenerateTerrain>().lod);
            }
        }
    }
}
