using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PixelProcessor : MonoBehaviour
{
    // Make sure you set this reference to one of your imported textures 
    public Texture2D textureToProcess;

    public Renderer targetRenderer;
    public Text textBox;
    public Image pixelImage;

    private int pixelWidth;
    private int pixelHeight;

    private int halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Set pixelWidth to the width of the texture referenced in textureToProcess
        // Set pixelHeight to the height of the texture referenced in textureToProcess
        // Create an array of Color type called 'pixels' and initialize it with the return value of GetPixels() executed on textureToProcess

        // Set halfWidth to to half of pixelWidth

        // Uncomment the lines below to check your values
        // Debug.Log($"<color=yellow>The texture is {pixelWidth}x{pixelHeight} pixels in dimension.</color>");
        // Debug.Log($"<color=yellow>The texture contains {pixels.Length} pixels in total.</color>");

        StartCoroutine(ReadFromTexture());
    }

    // Update is called once per frame
    private IEnumerator ReadFromTexture()
    {
        for (int currentY = 0; currentY < pixelHeight; currentY++)
        {
            // Create a Color variable called 'pixel' and initialize it the pixel at x: halfWidth y: currentY
            
            // Create a float variale called 'grayscale' and initialize it to grayscale value of your 'pixel' Color struct

            // Uncomment the lines below to update the UI
            // textBox.text = $"Coordinate - ({halfWidth},{currentY})\nPixel Colour -\nGrayscale Value - {grayscale:F2}";
            // pixelImage.color = pixel;

            // Set the color property of the material property of the targetRenderer to 'pixel'
            // Set the local scale of the targetRenderer's game object 5x the grayscale value

            yield return new WaitForSeconds(0.05f);
        }
    }
}
