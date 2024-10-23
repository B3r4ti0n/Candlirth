using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLightFlicker : MonoBehaviour
{
    public Light candleLight;
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.1f;
    public float flickerPositionRange = 0.05f;

    public Color minColor = new Color(1f, 0.85f, 0.7f);
    public Color maxColor = new Color(1f, 0.95f, 0.8f);
    private Vector3 initialPosition;

    private void Start() {
        
        if (candleLight == null) {
            candleLight = GetComponent<Light>();
        }
        initialPosition = candleLight.transform.localPosition;
    }

    private void Update() {
        FlickerIntensity();
        FlickerPosition();
        FlickerColor();
    }

    private void FlickerIntensity() {
        float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(Time.time * flickerSpeed, 0));
        candleLight.intensity = newIntensity;
    }

    private void FlickerPosition() {
        float newX = initialPosition.x + Random.Range(-flickerPositionRange, flickerPositionRange);
        float newY = initialPosition.y + Random.Range(-flickerPositionRange, flickerPositionRange);
        candleLight.transform.localPosition = new Vector3(newX, newY, initialPosition.z);
    }

    private void FlickerColor() {
        candleLight.color = Color.Lerp(minColor, maxColor, Mathf.PerlinNoise(Time.time * flickerSpeed, 1));
    }
}