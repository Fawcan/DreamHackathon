﻿using UnityEngine;
using System.Collections;

/// <summary>
/// A led bar the can be lighten up linearly by a normaltized value. Will go from one color to another fr[n one side to the other
/// Great for health bars in world GUI
/// </summary>
public class LEDBar : MonoBehaviour
{
    Color OffColor;
    [SerializeField]
    Color NoFillColor;
    [SerializeField]
    Color FullFillColor;
    [SerializeField]
    AnimationCurve Intensity;
    [SerializeField]
    float IntensityFactor;
    [Tooltip("Fill this array with the objects you want lit up based on progress")]
    [SerializeField]
    MeshRenderer[] LEDs;
    [SerializeField]
    MeshRenderer[] floorBars;

    [Range(0, 1)]
    public float NormFillValue;

    Color TargetColor;
    void Start()
    {
        OffColor = NoFillColor;
        int count = floorBars.Length;
        for (int i = 0; i < count; i++)
        {
            Color color = FullFillColor;

            floorBars[i].material.SetColor("_EmissionColor", color * Intensity.Evaluate(1) * IntensityFactor);
            floorBars[i].material.SetColor("_Color", color);
        }
    }
    void Update()
    {
        Color colorRange = FullFillColor - NoFillColor;
        TargetColor = NoFillColor + (NormFillValue * colorRange);

        int count = LEDs.Length;
        for (float i = 0; i < LEDs.Length; i += 1)
        {
            float evaluate = NormFillValue / (1f / count) % 1f;
            Color color = new Color(OffColor.r + (evaluate * TargetColor.r),
                                    OffColor.g + (evaluate * TargetColor.g),
                                    OffColor.b + (evaluate * TargetColor.b),
                                    OffColor.a + (evaluate * TargetColor.a));

            int phase = (int)(NormFillValue / (1f / count));
            if (phase == i)
            {
                LEDs[(int)i].material.SetColor("_EmissionColor", color * Intensity.Evaluate(evaluate) * IntensityFactor);
                LEDs[(int)i].material.SetColor("_Color", color);
            }
            else if (phase < i)
            {
                LEDs[(int)i].material.SetColor("_EmissionColor", color * Intensity.Evaluate(0) * IntensityFactor);
                LEDs[(int)i].material.SetColor("_Color", OffColor);
            }
            else
            {
                LEDs[(int)i].material.SetColor("_EmissionColor", TargetColor * Intensity.Evaluate(1) * IntensityFactor);
                LEDs[(int)i].material.SetColor("_Color", TargetColor);
            }

        }

    }
}
