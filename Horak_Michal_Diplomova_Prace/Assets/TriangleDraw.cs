using UnityEngine;

public class TriangleDraw : MonoBehaviour
{//Tøída, která slouží pro vykreslení plochy.
    //Slouží pro kreslení v Mesh rendereru objektu. Využito u generování terénu, kdy generuje jednotlivé ètverce plochy..
    Mesh m;
    MeshFilter mf;

    /// <summary>
    /// Metoda pro generování jednoho ètverce terénu
    /// </summary>
    /// <param name="x">Souøadnice prvního bodu</param>
    /// <param name="y">Souøadnice prvního bodu</param>
    /// <param name="z">Souøadnice prvního bodu</param>
    /// <param name="x2">Souøadnice druhého bodu</param>
    /// <param name="y2">Souøadnice drurého bodu</param>
    /// <param name="z2">Souøadnice druhého bodu</param>
    /// <param name="x3">Souøadnice tøetího bodu</param>
    /// <param name="y3">Souøadnice tøetího bodu</param>
    /// <param name="z3">Souøadnice tøetího bodu</param>
    /// <param name="x4">Souøadnice ètvrteho bodu</param>
    /// <param name="y4">Souøadnice ètvrteho bodu</param>
    /// <param name="z4">Souøadnice ètvrteho boduparam>
    public void DrawPlane(int x, float y, int z, int x2, float y2, int z2, int x3, float y3, int z3, int x4, float y4, int z4)
    {
        mf = this.GetComponent<MeshFilter>();
        m = new Mesh();

        Vector3[] normals = new Vector3[4];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;
        Vector3 a = new Vector3(x, y, z);
        Vector3 b = new Vector3(x2, y2, z2 + 0.0f);
        Vector3 c = new Vector3(x3, y3, z3);
        Vector3 d = new Vector3(x4, y4, z4 + 0.0f);
        m.vertices = new Vector3[] { c, a, b, d };

        m.uv = new Vector2[4]
        {
            new Vector2 ( 0, 0 ),
            new Vector2 ( 0, 1 ),
            new Vector2 ( 1, 1 ),
            new Vector2 ( 1, 0 )
        };

        m.normals = normals;

        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mf.mesh = m;

        m.RecalculateBounds();
    }
    //TODO SMAZAT
    public void DrawTriangle(int x, float y, int z, int x2, float y2, int z2, int x3, float y3, int z3)
    {


        mf = this.GetComponent<MeshFilter>();
        m = new Mesh();

        //We need two arrays one to hold the vertices and one to hold the triangles
        Vector3[] verteicesArray = new Vector3[3];

        int[] trianglesArray = new int[3];


        //lets add 3 vertices in the 3d space

        //define the order in which the vertices in the VerteicesArray shoudl be used to draw the triangle
        trianglesArray[0] = 0;
        trianglesArray[1] = 1;
        trianglesArray[2] = 2;

        Vector3[] normals = new Vector3[3];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;

        Vector2[] uv = new Vector2[3];
        uv[1] = new Vector2(1, 1);
        uv[2] = new Vector2(0, 0);
        uv[0] = new Vector2(0, 1);



        m.triangles = trianglesArray;
        m.uv = uv;
        m.normals = normals;
        //add these two triangles to the mesh


        mf.mesh = m;
    }
    //TODO SMAZAT
    public void DrawTriangle2(int x, float y, int z, int x2, float y2, int z2, int x3, float y3, int z3)
    {


        mf = this.GetComponent<MeshFilter>();
        m = new Mesh();

        //We need two arrays one to hold the vertices and one to hold the triangles
        Vector3[] verteicesArray = new Vector3[3];
        Vector3[] uv = new Vector3[3];
        int[] trianglesArray = new int[3];
        //lets add 3 vertices in the 3d space
        verteicesArray[0] = new Vector3(x, y, z);
        verteicesArray[1] = new Vector3(x2, y2, z2);
        verteicesArray[2] = new Vector3(x3, y3, z3);
        //define the order in which the vertices in the VerteicesArray shoudl be used to draw the triangle
        trianglesArray[0] = 0;
        trianglesArray[1] = 2;
        trianglesArray[2] = 1;
        //add these two triangles to the mesh
        Vector3[] normals = new Vector3[3];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;

        Vector2[] uv1 = new Vector2[3];

        uv1[0] = new Vector2(0, 0);
        uv1[1] = new Vector2(1, 0);
        uv1[2] = new Vector2(1, 1);

        m.vertices = verteicesArray;
        m.triangles = trianglesArray;
        m.uv = uv1;
        m.normals = normals;

        mf.mesh = m;
    }
}
