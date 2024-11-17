using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    public int offset = 0;
    public PlayerController player = null;
    
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component

    private int winEffectCount = 150;

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsOfType(collectibleType).Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsOfType(collectible2DType).Length;
        }

        int remainingCount = totalCollectibles - offset;
        int remainingCollectibles = remainingCount > 0 ? remainingCount : 0;

        // Update the collectible count display
        collectibleText.text = $"Collectibles remaining: {remainingCollectibles}";

        if(remainingCount == 0 && player != null && winEffectCount > 0) {
            player.Victory();
            --winEffectCount;
        }

    }
}
