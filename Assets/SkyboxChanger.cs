using UnityEngine;

public class SkyboxChanger : MonoBehaviour{
	[SerializeField] private LayerMask triggerLayerMask;
	[SerializeField] private Material originalSkyboxMat;
	[SerializeField] private Material enteredSkyboxMat;

	private void OnTriggerEnter(Collider other) {
		if((triggerLayerMask.value & 1 << other.gameObject.layer) != 0 && RenderSettings.skybox != enteredSkyboxMat){
			RenderSettings.skybox = enteredSkyboxMat;	
		}
	}

	private void OnTriggerExit(Collider other) {
		if((triggerLayerMask.value & 1 << other.gameObject.layer) != 0 && RenderSettings.skybox != originalSkyboxMat){
			RenderSettings.skybox = originalSkyboxMat;	
		}
	}
}
