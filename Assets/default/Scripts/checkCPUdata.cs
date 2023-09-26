using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

using UnityEditorInternal;

using UnityEngine.Profiling;

public class checkCPUdata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

        Debug.Log("c.animation:" + ProcessCPUFrameData(Time.frameCount).animation);   
    }
    [Serializable]
    public class CPUFrameData
    {
        public float rendering;//ナノ秒
        public float scripts;
        public float physics;
        public float animation;
        public float garbageCollector;
        public float VSync;
        public float globalIllumination;
        public float ui;
        public float others;
    }
    public static CPUFrameData ProcessCPUFrameData(int frame)
    {
        var c = new CPUFrameData();
        var statistics = ProfilerDriver.GetGraphStatisticsPropertiesForArea(ProfilerArea.CPU);
        foreach (var propertyName in statistics)
        {
            var id = ProfilerDriver.GetStatisticsIdentifierForArea(ProfilerArea.CPU, propertyName);
            var buffer = new float[1];
            ProfilerDriver.GetStatisticsValues(id, frame, 1, buffer, out var maxValue);
            if (propertyName == "Rendering") c.rendering = buffer[0] * 0.000001f;
            else if (propertyName == "Scripts") c.scripts = buffer[0] * 0.000001f;
            else if (propertyName == "Physics") c.physics = buffer[0] * 0.000001f;
            else if (propertyName == "Animation") c.animation = buffer[0];
            else if (propertyName == "GarbageCollector") c.garbageCollector = buffer[0] * 0.000001f;
            else if (propertyName == "VSync") c.VSync = buffer[0] * 0.000001f;
            else if (propertyName == "Global Illumination") c.globalIllumination = buffer[0] * 0.000001f;
            else if (propertyName == "UI") c.ui = buffer[0] * 0.000001f;
            else if (propertyName == "Others") c.others = buffer[0] * 0.000001f;
        }

        return c;
    }
}
