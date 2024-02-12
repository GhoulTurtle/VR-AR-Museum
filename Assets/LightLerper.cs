using System.Collections;
using UnityEngine;

public class LightLerper : MonoBehaviour{
	[Header("References")]
	[SerializeField] private LayerMask triggerLayerMask;
	[SerializeField] private Light lightToLerp;

	[Header("Light Number Variables")]
	[SerializeField] private float lerpedLightStrength;
	[SerializeField] private float originalLightStrength;
	[SerializeField] private Color lerpedLightColor;
	[SerializeField] private Color originalLightColor;

	[Header("Lerp Variables")]
	[SerializeField] private float lerpSnap = 0.03f;
	[SerializeField] private float lerpSpeed = 0.05f;

	private IEnumerator currentLerpJob;

	private void Awake() {
		if(lightToLerp != null){
			originalLightStrength = lightToLerp.intensity;
			originalLightColor = lightToLerp.color;
		}
	}

	private void OnDestroy() {
		StopAllCoroutines();
	}

	private void OnTriggerEnter(Collider other) {
		if((triggerLayerMask.value & 1 << other.gameObject.layer) != 0 && lightToLerp.intensity != lerpedLightStrength){
			TriggerLerp(lerpedLightStrength, lerpedLightColor);
		}
	}

    private void OnTriggerExit(Collider other) {
		if((triggerLayerMask.value & 1 << other.gameObject.layer) != 0 && lightToLerp.intensity != originalLightStrength){
			TriggerLerp(originalLightStrength, originalLightColor);			
		}
	}

    private void TriggerLerp(float lightStrength, Color lightColor){
		if(currentLerpJob != null){
			StopCoroutine(currentLerpJob);
			currentLerpJob = null;
		}

		currentLerpJob = LightLerpJob(lightStrength, lightColor);

		StartCoroutine(currentLerpJob);
    }

	private IEnumerator LightLerpJob(float lightStrength, Color lightColor){
		do{
			var constantLerpSpeed = lerpSpeed + Time.deltaTime;
			lightToLerp.intensity = Mathf.Lerp(lightToLerp.intensity, lightStrength, constantLerpSpeed);
			lightToLerp.color = Color.Lerp(lightToLerp.color, lightColor, constantLerpSpeed);
			yield return null;
		} 
		while (Mathf.Abs(lightToLerp.intensity - lightStrength) > lerpSnap);
		
		lightToLerp.intensity = lightStrength;
		lightToLerp.color = lightColor;
	}
}
