using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    private Light thisLight;
    private float transition = 0.0f;
    public float transitionSpeed = 0.01f;
    private bool sunrise = true;
    public Material day;
    public Material night;

    private void Start()
    {
        thisLight = GetComponent<Light>();
    }

    private void Update()
    {
        transition += (sunrise) ? transitionSpeed * Time.deltaTime : -transitionSpeed * Time.deltaTime;
        if (transition < 0.0f || transition > 1.0f)
        {
            sunrise = !sunrise;
        }
        thisLight.intensity = transition;
        thisLight.color = Color.Lerp(Color.blue, Color.white, transition);
        if (sunrise)
        {
            RenderSettings.skybox = day;
        }
        else
        {
            RenderSettings.skybox = night;
        }
    }
}