using UnityEngine;

public class OceanGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColorMap, Mesh };
    public DrawMode drawMode;

    public int oceanWidth;
    public int oceanHeight;
    public float noiseScale;

    public int octaves;
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public OceanType[] waves;

    public void GenerateOcean()
    {
        float[,] oceanMap = OceanNoise.GenerateOceanNoise(seed, oceanWidth, oceanHeight, octaves, noiseScale, persistance, lacunarity, offset);

        Color[] oceanColorMap = new Color[oceanWidth * oceanHeight];
        for (int y = 0; y < oceanHeight; y++)
        {
            for (int x = 0; x < oceanWidth; x++)
            {
                float currentHeight = oceanMap[x, y];
                for (int i = 0; i < waves.Length; i++)
                {
                    if (currentHeight <= waves[i].height)
                    {
                        oceanColorMap[y * oceanWidth + x] = waves[i].color;
                        break;
                    }
                }
            }
        }

        OceanDisplay display = FindObjectOfType<OceanDisplay>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawOcean(TextureGenerator.TextureFromHeightMap(oceanMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            display.DrawOcean(TextureGenerator.TextureFromColourMap(oceanColorMap, oceanWidth, oceanHeight));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(OceanMeshGenerator.GenerateOceanMesh(oceanMap), TextureGenerator.TextureFromColourMap(oceanColorMap, oceanWidth, oceanHeight));  
        }
    }
}

[System.Serializable]
public struct OceanType
{
    public string name;
    public float height;
    public Color color;
}