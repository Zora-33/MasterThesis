using UnityEngine;
using System.IO;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;

public class ArrowSaveManager : MonoBehaviour
{
    private string savePath;
    private bool isRecording = false;
    public DialogPool dialogPool1;



<<<<<<< HEAD
    void Start()
    {
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        savePath = Path.Combine(Application.persistentDataPath, $"TriggeredArrows_{timestamp}.txt");
        LoadTriggeredArrows(); // 你也可以决定是否每次都加载
=======
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "TriggeredArrows.txt");
        LoadTriggeredArrows();
        //ShowIntroDialog(); // 启动时显示欢迎引导
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
    }

    public void StartNavigation()
    {
        isRecording = true;
        ArrowController.triggeredArrows.Clear(); // 路径C:\Users\Tian\AppData\LocalLow\DefaultCompany\MRTK_learn
        // 不同用户需要名字不一样，可以加上时间等
        Debug.Log("🔴 开始记录导航触发状态");
    }

    public void StopNavigationAndSave()
    {
        isRecording = false;
        SaveTriggeredArrows();
        ShowFinishDialog();
        Debug.Log("🟢 已保存导航记录并停止记录");
    }

    void OnApplicationQuit()
    {
        if (isRecording)
        {
            SaveTriggeredArrows();
        }
    }

    public void SaveTriggeredArrows()
    {
        File.WriteAllLines(savePath, ArrowController.triggeredArrows);
        Debug.Log("✅ 箭头触发记录已保存到: " + savePath);
    }

    public void LoadTriggeredArrows()
    {
        if (File.Exists(savePath))
        {
            string[] lines = File.ReadAllLines(savePath);
            ArrowController.triggeredArrows = new List<string>(lines);
            Debug.Log("📂 箭头触发记录已加载: " + lines.Length + " 项");
        }
    }

    // 🗨️ UI对话控制部分
    //public void ShowIntroDialog()
    //{
    //    dialogPool1.Get()
    //       .SetHeader("Hey there!")
    //       .SetBody("I'm your navigation assistant — Atlas.\n\nI'll guide you step by step.\n\nJust follow me!")
    //       .SetPositive("OK", _ => ShowConfirmDialog())
    //       .Show();
    //}

    public void ShowConfirmDialog()
    {
        dialogPool1.Get()
            .SetHeader("Ready to start?")
            .SetBody("Start navigation now?")
            .SetPositive("Yes", _ =>
            {
                Debug.Log("✅ Navigation started.");
                StartNavigation();
            })
            .SetNegative("No", _ =>
            {
                Debug.Log("❌ Navigation canceled.");     //如果用户不选择开始，需要说重新开始或者退出吗
            })
            .Show();
    }

    void ShowFinishDialog()
    {
        dialogPool1.Get()
            .SetHeader("🎯 You have arrived at the destination.")
            .Show();
    }

    // 可供外部调用，比如终点触发器调用这个
    public void OnDestinationReached()
    {
        StopNavigationAndSave();
    }
}