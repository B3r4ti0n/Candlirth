using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRangeDecreaser : MonoBehaviour
{
    public Light playerLight;
    public float initialRange = 10f;
    public float decreaseInterval = 10f;
    public float totalTime = 300f;
    public float rangeDecreaseAmount = 0.5f;
    public string resetTag = "ResetObject";
    public float rangeMinimal = 5;

    private float elapsedTime = 0f;
    private float nextDecreaseTime = 0f;

    private void Start() {
        ResetLight();
    }

    private void Update() {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= nextDecreaseTime && playerLight.range > rangeMinimal){
            playerLight.range -= rangeDecreaseAmount;
            nextDecreaseTime += decreaseInterval;
        }

        if(elapsedTime >= totalTime && playerLight.range > rangeMinimal){
            playerLight.range = rangeMinimal;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(resetTag)) {
            ResetLight();
        }
    }

    private void ResetLight(){
        elapsedTime = 0f;
        nextDecreaseTime = decreaseInterval;
        playerLight.range = initialRange;
    }
}
