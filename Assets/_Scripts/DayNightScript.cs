using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    private Light thisLight;
    private float transition = 0.36f;
    public float transitionSpeed = 0.01f;
    public Material day;
    public Material night;

    private void Start()
    {
        thisLight = GetComponent<Light>();
    }

    private void Update()
    {
        transition += transitionSpeed * Time.deltaTime;
        if (transition < 0.0f || transition > 1.0f)
        {
            transitionSpeed *= -1;
        }
        thisLight.intensity = transition;
        thisLight.color = Color.Lerp(Color.blue, Color.white, transition);
        if (transition >= 0.35)
        {
            RenderSettings.skybox = day;
        }
        else
        {
            RenderSettings.skybox = night;
        }
    }
}