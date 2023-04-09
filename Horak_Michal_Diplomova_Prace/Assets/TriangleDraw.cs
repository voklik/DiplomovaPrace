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
}
