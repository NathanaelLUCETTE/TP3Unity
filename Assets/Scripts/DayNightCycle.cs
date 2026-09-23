using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;

    public float dayDuration = 120f;

    private float currentTime = 6f;

    void Update()
    {
        // Faire avancer le temps
        currentTime += (24f / dayDuration) * Time.deltaTime;

        // Recommencer après 24 heures
        if (currentTime >= 24f)
        {
            currentTime = 0f;
        }

        // Faire tourner le soleil
        float sunAngle = (currentTime / 24f) * 360f - 90f;

        sun.transform.rotation = Quaternion.Euler(sunAngle, 0f, 0f);

        // Modifier l'intensité
        UpdateSunIntensity();
    }

    void UpdateSunIntensity()
    {
        float intensity;

        if (currentTime >= 6f && currentTime <= 18f)
        {
            // Jour
            intensity = Mathf.Lerp(
                0.1f,
                1f,
                Mathf.Sin((currentTime - 6f) / 12f * Mathf.PI)
            );
        }
        else
        {
            // Nuit
            intensity = 0.1f;
        }

        sun.intensity = intensity;
    }
}