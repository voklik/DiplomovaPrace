using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNois
{
    //Vytvoøí se 2D obrázek a náhodnì se vytvoøí šum. Tento šum slouží potom pøi generování terénu, kdy hodnota šumu urèuje výšku (souøadnici y)
    public static int width1, height1;
    public static float[,] map;
    public static float[,] Generate(int width, int height, float scale, Vector2 offset)
    {

        width1 = width;
        height1 = height;
        float[,] noiseMap = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float samlePosX = (float)x * scale + offset.x;
                float samlePosY = (float)y * scale + offset.y;
                float perlinValue = 0 + (Mathf.PerlinNoise(((float)x / (float)width) * 1, ((float)y / (float)height) * 1) * (float)2);

                noiseMap[x, y] = perlinValue;
            }
        }
        map = noiseMap;
        return noiseMap;
    }
    public static float[,] Generate(int width, int height, float scale, Vector2 offset, float baseHeight, float hillHeight, float randomSeed)
    {
        width1 = width;
        height1 = height;
        float[,] noiseMap = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float tilesize = 1.0f;
                float samlePosX = (float)x * scale + offset.x;
                float samlePosY = (float)y * scale + offset.y;
                float perlinValue = baseHeight + (Mathf.PerlinNoise(((float)x / (float)width) * tilesize + randomSeed, ((float)y / (float)height) * tilesize + randomSeed) * (float)hillHeight);
                noiseMap[x, y] = (float)System.Math.Round(perlinValue, 3);
            }
        }
        map = noiseMap;
        return noiseMap;
    }
}
