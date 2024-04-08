using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WindPanel : MonoBehaviour
{
    public GameObject wind_zone;
    private MeshRenderer wind_renderer;
    private CommunistWindZone wind_script;
    public GameObject wind_strength_slider_value;
    private TextMeshPro wind_strength_slider_text;
    void Start() 
    {
        wind_renderer = wind_zone.GetComponent<MeshRenderer>();
        wind_script = wind_zone.GetComponent<CommunistWindZone>();
        wind_strength_slider_text = wind_strength_slider_value.GetComponent<TextMeshPro>();
        
        //wind_script.wind_strength 
        //Debug.Log("retrieved wind zone mesh renderer");
    }
    public void ToggleShowWindZone() 
    {
        //Debug.Log("Toggling wind zone visibility");
        wind_renderer.enabled = !wind_renderer.enabled;
    }

    public void ToggleWindZoneActive() 
    {
        //Debug.Log("Toggling wind zone active");
        wind_zone.active = !wind_zone.active;
        //wind_zone.SetActive(wind_zone.active);
    }

    public void UpdateWindZoneDirection() 
    {
        // wind_script.direction = 1 ==> right
        // wind_script.direction = -1 ==> left 
        wind_script.direction = wind_script.direction * -1;
    }

    public void UpdateWindStrength(UnityEngine.UI.Slider slider) 
    {
        wind_script.wind_strength = 
        slider.value/10f * (wind_script.max_wind_strength - 
        wind_script.min_wind_strength) + wind_script.min_wind_strength;
        Debug.Log($"slider value: {slider.value}");
        Debug.Log($"sum: {wind_script.max_wind_strength - wind_script.min_wind_strength}");
        Debug.Log($"min: {wind_script.min_wind_strength}");

        //Debug.Log(wind_strength_slider_value is null);
    }
}
