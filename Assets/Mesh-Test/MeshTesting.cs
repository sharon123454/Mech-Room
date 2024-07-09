using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MeshTesting : MonoBehaviour
{
    [SerializeField] private int meshHeight = 4;
    [SerializeField] private int meshWidth = 4;
    [SerializeField] private int tileSize = 1;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = CreateMeshGrid();
    }

    private Mesh CreateMeshGrid()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4 * (meshWidth * meshHeight)];//Point in engine space
        Vector2[] uv = new Vector2[4 * (meshWidth * meshHeight)];//Texture position
        int[] triangles = new int[6 * (meshWidth * meshHeight)];//Each 3 is triangle point IDs. MUST go clockwise or will flip.

        int index;
        for (int i = 0; i < meshWidth; i++)
        {
            for (int j = 0; j < meshHeight; j++)
            {
                index = i * meshHeight + j;

                vertices[index * 4 + 0] = new Vector3(tileSize * i, tileSize * j);
                vertices[index * 4 + 1] = new Vector3(tileSize * i, tileSize * (j + 1));
                vertices[index * 4 + 2] = new Vector3(tileSize * (i + 1), tileSize * (j + 1));
                vertices[index * 4 + 3] = new Vector3(tileSize * (i + 1), tileSize * j);

                //texture 
                uv[index * 4 + 0] = new Vector2(0, 0);
                uv[index * 4 + 1] = new Vector2(0, 1);
                uv[index * 4 + 2] = new Vector2(1, 1);
                uv[index * 4 + 3] = new Vector2(1, 0);

                //triangle point[x] = vertex number in {vertices}
                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;

                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }

    private void CreateAnimationMesh()
    {
        //if wanna know more: look into Code Monkeys' "How to make a Mesh in Unity" video.
    }

}