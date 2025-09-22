using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PixelProcessor : MonoBehaviour
{
    // Make sure you set this reference to one of your imported textures 
    private Texture2D textureToProcess;

    public Renderer targetRenderer;
    public Text textBox;
    public Image pixelImage;

    private int pixelWidth;
    private int pixelHeight;

    private int halfWidth;
    private int chosenWidth;

    int currentY;
    /**********************************************************************/
    //For texture swapping I hope!
    public Button applyTextureButton;
    public Texture2D originalTexture;
    public Texture2D altTexture;
    
    private bool isSwapped = false;
    /**********************************************************************/

    // Start is called before the first frame update
    void Start()
    {
        textureToProcess = originalTexture;
        /**********************************************************************/
        applyTextureButton.onClick.AddListener(ApplyTextureToMaterial);
        //originalTexture = GetComponent<Renderer>().material.mainTexture;
        /**********************************************************************/
        // Set pixelWidth to the width of the texture referenced in textureToProcess
        pixelWidth = textureToProcess.width;
        // Set pixelHeight to the height of the texture referenced in textureToProcess
        pixelHeight = textureToProcess.height;
        // Create an array of Color type called 'pixels' and initialize it with the return value of GetPixels() executed on textureToProcess
        Color[] pixels = textureToProcess.GetPixels();

        // Set halfWidth to to half of pixelWidth
        halfWidth = pixelWidth / 2;
        chosenWidth = halfWidth;
        
        // Uncomment the lines below to check your values
        Debug.Log($"<color=yellow>The texture is {pixelWidth}x{pixelHeight} pixels in dimension.</color>");
        Debug.Log($"<color=yellow>The texture contains {pixels.Length} pixels in total.</color>");

        StartCoroutine(ReadFromTexture());
        /**********************************************************************/

        /**********************************************************************/
    }

    // Update is called once per frame
    private IEnumerator ReadFromTexture()
    {
        for (currentY = 0; currentY < pixelHeight; currentY++)
        {
            // Create a Color variable called 'pixel' and initialize it the pixel at x: halfWidth y: currentY
            Color pixel = textureToProcess.GetPixel(chosenWidth, currentY);
            // Create a float variale called 'grayscale' and initialize it to grayscale value of your 'pixel' Color struct
            float grayscale = pixel.grayscale;

            // Uncomment the lines below to update the UI
            textBox.text = $"Coordinate - ({chosenWidth},{currentY})\nPixel Colour -\nGrayscale Value - {grayscale:F2}";
            pixelImage.color = pixel;

            // Set the color property of the material property of the targetRenderer to 'pixel'
            targetRenderer.material.color = pixel;
            // Set the local scale of the targetRenderer's game object 5x the grayscale value
            targetRenderer.transform.localScale = new Vector3(grayscale * 5, grayscale * 5, grayscale * 5);

            yield return new WaitForSeconds(0.05f);
        }
    }
    /**********************************************************************/
    //This is where I will attempt to swap the texture around.
    private void ApplyTextureToMaterial()
    {
        Renderer swapTextureRender = GetComponent<Renderer>();
        if (!isSwapped)
        {
            swapTextureRender.material.mainTexture = altTexture;
            textureToProcess = altTexture;
        }
        else
        {
            swapTextureRender.material.mainTexture = originalTexture;
            textureToProcess = originalTexture;
        }
        isSwapped = !isSwapped;
        
        pixelWidth = textureToProcess.width;
        pixelHeight = textureToProcess.height;
        halfWidth = pixelWidth / 2;
        chosenWidth = halfWidth;

        currentY = 0;
        StopCoroutine(ReadFromTexture());
        StartCoroutine(ReadFromTexture());
    }
    //This is where my button should randomize the X location
    public void ApplyRandomX()
    {
        StopCoroutine(ReadFromTexture());
        int randomX = Random.Range(0, textureToProcess.width);
        chosenWidth = randomX;
        StartCoroutine(ReadFromTexture());
    }
    private void OnDestroy()
    {
        applyTextureButton.onClick.RemoveAllListeners();
    }
    /**********************************************************************/

}
