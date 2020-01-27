using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Enter a draw map design (PNG or Photoshop file)
    public Texture2D map;
    // Substitutes selected colour with enterd prefab
    public ColourToPrefab[] colourMapping;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel () {
        for (int x = 0; x < map.width; x++) {
            for (int y = 0; y < map.height; y++) {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile (int x, int y) {
        Color pixelColor = map.GetPixel(x, y);

        // Ignore transparent pixel
        if (pixelColor.a == 0) {
            return;
        }

        foreach (ColourToPrefab colourMapping in colourMapping) {
            // Check if the assigned colour is the same as the pixels colour
            if (colourMapping.colour.Equals(pixelColor)) {
                Vector2 position = new Vector2(x, y);
                // Replace pixel with assigned prefab
                Instantiate(colourMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }

}
