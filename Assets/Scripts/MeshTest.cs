using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour {
    //　頂点配列
    public Vector3[] vertices;
    //　UV配列
    public Vector2[] uvs;
    //　三角形の順番配列
    public int[] triangles;
    //　メッシュ
    private Mesh mesh;
    //　メッシュ表示コンポーネント
    private MeshRenderer meshRenderer;
    //　メッシュに設定するマテリアル
    public Material material;

    // Use this for initialization
    void Start () {
        vertices = new Vector3[] {
            new Vector3 (0f, 0f, 0f),
            new Vector3 (0f, 1f, 0f),
            new Vector3 (1f, 1f, 0f),
            new Vector3 (1f, 0f, 0f) };
        uvs = new Vector2[] {
            new Vector2 (0f, 0f),
            new Vector2 (0f, 1f),
            new Vector2 (1f, 1f),
            new Vector2 (1f, 0f)
        };
        triangles = new int[] {
            0, 1, 2,
            0, 2, 3
        };

        gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;
        meshRenderer.material = material;
    }
	
	// Update is called once per frame
	void Update () {
        CreateMesh(mesh, vertices, uvs, triangles);
    }
    void CreateMesh(Mesh mesh, Vector3[] vertices, Vector2[] uvs, int[] triangles)
    {
        //　最初にメッシュをクリアする
        mesh.Clear();
        //　頂点の設定
        mesh.vertices = vertices;
        //　テクスチャのUV座標設定
        mesh.uv = uvs;
        //　三角形メッシュの設定
        mesh.triangles = triangles;
        //　Boundsの再計算
        mesh.RecalculateBounds();
        //　NormalMapの再計算
        mesh.RecalculateNormals();
    }
}
