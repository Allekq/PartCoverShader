using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class RendererTextureUpdateQueue : MonoBehaviour
{
    [SerializeField] private Camera renderCam;
    [SerializeField] private Light2D[] playerLights;
    [SerializeField] private RenderTexture renderTexture;

    
    private Light2D[] otherlights;
    // Start is called before the first frame update
    void Awake()
    {
        renderCam.enabled = false;
        //renderCam.rect = new Rect(renderCam.rect.position, new Vector2(renderTexture.width, renderTexture.height));

        otherlights = GameObject.FindObjectsOfType<Light2D>().Where(t=> !playerLights.Contains(t)).ToArray(); 
    }

    private void Update()
    {
        Renderer();
    }

    // Update is called once per frame
    void Renderer()
    {
        renderCam.enabled = true;

        bool[] enable= new bool[otherlights.Length];
        for (int i = 0;i < otherlights.Length; i++) 
        {
            enable[i] = otherlights[i].enabled;
            otherlights[i].enabled = false;
        }

        renderCam.Render();

        for (int i = 0; i < otherlights.Length; i++)
            otherlights[i].enabled = enable[i];

        renderCam.enabled = false;
    }
}
