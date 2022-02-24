using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NegativeColor : MonoBehaviour
{
    PostProcessVolume ppv;
    Bloom bloomLayer = null;
    //Color trueBlack = (-1f,-1f,-1f);

    // Start is called before the first frame update
    void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out bloomLayer);
        bloomLayer.color.value = new Color(-100f,-100f,-100f,1);
        Debug.Log(bloomLayer.color.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
