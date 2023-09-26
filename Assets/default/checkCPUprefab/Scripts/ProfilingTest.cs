
using System.Collections.Generic;
using System.Text;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;

public class ExampleScript : MonoBehaviour
{
    string statsText;
    ProfilerRecorder systemMemoryRecorder;
    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder mainThreadTimeRecorder;

    ProfilerRecorder renderTimeRecorder;

    ProfilerRecorder physicsTimeRecorder;

    ProfilerRecorder scriptTimeRecorder;

    [SerializeField] private int guiRectX=150;

    [SerializeField] private int guiRectY=90;

    [SerializeField] private int guiRectWidth=250;

    [SerializeField] private int guiRectHeight=80;



    static double GetRecorderFrameAverage(ProfilerRecorder recorder)
    {
        var samplesCount = recorder.Capacity;
        double r = 0;
        if (samplesCount == 0)
            return 0;
        unsafe
        {
            var samples = stackalloc ProfilerRecorderSample[samplesCount];
            recorder.CopyTo(samples, samplesCount);
            for (var i = 0; i < samplesCount; ++i)
                r += samples[i].Value;
            r /= samplesCount;
        }

        return r;
    }

    void OnEnable()
    {
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        // renderTimeRecorder=ProfilerRecorder.StartNew(ProfilerCategory.Render, "Render Time");
        // physicsTimeRecorder=ProfilerRecorder.StartNew(ProfilerCategory.Physics, "Physics Time");
        // scriptTimeRecorder=ProfilerRecorder.StartNew(ProfilerCategory.Scripts, "Script Time");
        mainThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15);
    }

    void OnDisable()
    {
        systemMemoryRecorder.Dispose();
        gcMemoryRecorder.Dispose();
        renderTimeRecorder.Dispose();
        // physicsTimeRecorder.Dispose();
        // scriptTimeRecorder.Dispose();
        // mainThreadTimeRecorder.Dispose();
    }

    void Update()
    {
        var sb = new StringBuilder(500);
        sb.AppendLine($"Frame Time: {GetRecorderFrameAverage(mainThreadTimeRecorder) * (1e-6f):F1} ms");
        sb.AppendLine($"GC Memory: {gcMemoryRecorder.LastValue / (1024 * 1024)} MB");
        sb.AppendLine($"System Memory: {systemMemoryRecorder.LastValue / (1024 * 1024)} MB");
        //以降反映されないのでコメントアウト
        // sb.AppendLine($"Render Time:{renderTimeRecorder.LastValue / (1024 * 1024)} MB");
        // sb.AppendLine($"Script Time:{scriptTimeRecorder.LastValue / (1024 * 1024)} MB");
        // sb.AppendLine($"Physics Time:{physicsTimeRecorder.LastValue / (1024 * 1024)} MB");
        statsText = sb.ToString();
    }

    void OnGUI()
    {
        //50,30
        // GUI.TextArea(new Rect(150, 90, 250, 50), statsText);
        GUI.TextArea(new Rect(guiRectX, guiRectY, guiRectWidth, guiRectHeight), statsText);
    }

}
