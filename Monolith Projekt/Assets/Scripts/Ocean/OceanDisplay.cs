using UnityEngine;

public class OceanDisplay : MonoBehaviour
{
    public Renderer oceanRender;
    public MeshFilter oceanFilter;
    public MeshRenderer oceanMeshRender;

    public void DrawOcean(Texture2D texture)
    {        
        oceanRender.sharedMaterial.mainTexture = texture;
        oceanRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(OceanMeshData oceanData, Texture2D texture)
    {
        oceanFilter.sharedMesh = oceanData.CreateMesh();
        oceanMeshRender.sharedMaterial.mainTexture = texture;
    }
}
