using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Duration of a full day in seconds, editable in the Inspector
    [SerializeField] private float dayDuration = 120f;

    // Reference to the Transform of the Directional Light
    private Transform lightTransform;

    // Number of degrees per second (calculated based on day duration)
    private float degreesPerSecond;

    void Start()
    {
        // Cache the Transform of the Directional Light
        lightTransform = transform;

        // Calculate the speed in degrees per second
        degreesPerSecond = 360f / dayDuration;
    }

    void Update()
    {
        // Rotate the light along the X-axis based on the speed
        lightTransform.Rotate(Vector3.right, degreesPerSecond * Time.deltaTime);
    }
}
