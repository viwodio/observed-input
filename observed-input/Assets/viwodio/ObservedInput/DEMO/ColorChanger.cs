using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using viwodio.InputSystem;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private string inputKey = "random-color";
    [SerializeField] private Color[] colors = {
        Color.red,
        Color.blue,
        Color.cyan,
        Color.magenta,
        Color.white,
        Color.green,
        Color.grey
    };
    [SerializeField] private Material material;

    void OnEnable()
    {
        Button.GetButton(inputKey).OnPressDown += NextColor;
    }

    private void NextColor()
    {
        material.color = colors[Random.Range(0, colors.Length)];
    }

    void OnDisable()
    {
        Button.GetButton(inputKey).OnPressDown -= NextColor;
    }
}
