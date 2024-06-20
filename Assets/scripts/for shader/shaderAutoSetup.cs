using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderAutoSetup : MonoBehaviour
{

    [SerializeField]
    private Camera renderCam;

    [Space]
    [SerializeField]
    private Material mat;

    [SerializeField]
    private string ScalerName = "_res";

    void Awake()
    {
        float v = (Camera.main.orthographicSize / renderCam.orthographicSize) / 2; // /2 because it is half size
        v /= 10; //for some reason, idk why
        mat.SetFloat(ScalerName, v);
    }

}
