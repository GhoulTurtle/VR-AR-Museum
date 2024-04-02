using UnityEngine;

public class LightSwitch : MonoBehaviour{
    [Header("References")]
    [SerializeField] private Light lightToControl;

    [Header("Light Switch Variables")]
    [SerializeField] private float lowerEndValue;
    [SerializeField] private float upperEndValue;

    public void UpdateLightValue(float lightValue) {
        lightToControl.intensity = Mathf.Lerp(lowerEndValue, upperEndValue, lightValue);
    }
}