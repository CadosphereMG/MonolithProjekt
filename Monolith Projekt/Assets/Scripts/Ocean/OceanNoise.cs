using UnityEngine;

public class OceanNoise
{
    public static float[,] GenerateOceanNoise(int seed, int oceanWidth, int oceanHeight, int octaves, float scale, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] oceanMap = new float[oceanWidth, oceanHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxWaveHeight = float.MinValue;
        float minWaveHeight = float.MaxValue;

        for (int y = 0; y < oceanHeight; y++)
        {
            for (int x = 0; x < oceanWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;

                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency + octaveOffsets[i].x;
                    float sampleY = y / scale * frequency + octaveOffsets[i].y;

                    float oceanPerlin = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += oceanPerlin * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if (noiseHeight > maxWaveHeight)
                {
                    maxWaveHeight = noiseHeight;
                }
                else if (noiseHeight < minWaveHeight)
                {
                    minWaveHeight = noiseHeight;
                }

                oceanMap[x, y] = noiseHeight;
            }
        }
        for (int y = 0; y < oceanHeight; y++)
        {
            for (int x = 0; x < oceanWidth; x++)
            {
                oceanMap[x, y] = Mathf.InverseLerp(minWaveHeight, maxWaveHeight, oceanMap[x, y]);
            }
        }

        return oceanMap;
    }
}
