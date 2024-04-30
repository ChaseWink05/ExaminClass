using UnityEngine;

public class SuntoNight : MonoBehaviour
{
    public Light sun;
    public float daySpeed = 1.0f;
    public float nightSpeed = 1.0f;
    public float transitionSpeed = 0.1f;


    private bool isDay = true;
    private float targetIntensity = 1.0f;


    void Update()
    {
        if (isDay)
        {
            // Rotate the sun for day cycle
            sun.transform.Rotate(Vector3.right, daySpeed * Time.deltaTime);
        }
        else
        {
            // Rotate the sun for night cycle
            sun.transform.Rotate(Vector3.right, nightSpeed * Time.deltaTime);
        }

        // Adjust the intensity smoothly for transition
        sun.intensity = Mathf.Lerp(sun.intensity, targetIntensity, transitionSpeed * Time.deltaTime);

    }
}
