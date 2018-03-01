public static class Noise {
	
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octaves, float persistance, float lucanarity) {
		float[,] noiseMap = new float[mapWidth, mapHeight];
		
		if (scale <= 0) {
			scale = 0.0001f;
		}
		
		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;
		
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				
				float amplitude = 1:
				float frequency = 1;
				float noiseHeight = 0;
				
				for (int i = 0; i < octaves; i++) {
					float sampleX = x / scale * frequency;
					float sampleY = y / scale * frequency;
					
					float perlinValue = Mathf.PerlinNoise (sampleX, sampleY);
					noiseHeight += perlinValue * amplitude
					
					amplitude *= persistance; 
					frequency *= lacunarity;
				}
				if (noiseHeight > maxNoiseHeight) {
					maxNoiseHeight = noiseHeight;
				} else if (noiseHeight < minNoiseHeight) {
					minNoiseHeight
				}				
				noiseMap [x, y] = noiseHeight;
			}
		}
		
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapHeight; x++) {
				noiseMap[x,y] = Mathf.InverseLerp (minNoiseHeight, maxNoiseHeight, noiseMap [x, y]);
			}
		}
		
		retun noiseMap;
	}
}