using UnityEngine;

public class TerenDetail
{
    //Tøída, která drží informace o terénu. Terén je ètverec.
    public readonly Vector3 vertex1;
    public readonly Vector3 vertex2;
    public readonly Vector3 vertex3;
    public readonly Vector3 vertex4;
    public readonly Vector2 position;
    public readonly bool podklad;

    public TerenDetail(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, Vector3 vertex4, Vector2 position, bool underground)
    {
        this.vertex1 = vertex1;
        this.vertex2 = vertex2;
        this.vertex3 = vertex3;
        this.vertex4 = vertex4;
        this.position = position;
        this.podklad = underground;
    }
}
