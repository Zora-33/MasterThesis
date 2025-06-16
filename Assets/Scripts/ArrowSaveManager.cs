using UnityEngine;
using System.IO;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;

public class ArrowSaveManager : MonoBehaviour
{
<<<<<<< HEAD
    public Transform playerHead;              // XR Rig 中的 Camera Transform
    public Transform destinationPoint;        // 设置为终点门的位置
    
    public DialogPool dialogPool1;
    public float arrivalThreshold = 1.5f;     // 到达判定距离（单位：米）
    private bool isArrowMode = false;
    private bool hasArrived = false;
    private UnityEngine.AI.NavMeshAgent agent;
    


    void Update()
    {
        if (playerHead.position == null)
            Debug.LogError("❌ playerHead is null");
        if (destinationPoint == null)
            Debug.LogError("❌ destinationPoint is null");
        if (!isArrowMode || hasArrived || playerHead == null || destinationPoint == null)
        {
            Debug.Log("⛔ 条件不满足，跳过检测");
            return;
        }



        float distance = Vector3.Distance(playerHead.position, destinationPoint.position);
        Debug.Log($"📏 当前与终点距离: {distance}");
        if (distance <= arrivalThreshold)
        {
            Debug.Log("✅ 到达终点，准备触发 ShowFinishDialog()");
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
    public Transform playerHead;              // XR Rig 中的 Camera Transform
    public Transform destinationPoint;        // 设置为终点门的位置
    public DialogPool dialogPool1;
    public float arrivalThreshold = 1.5f;     // 到达判定距离（单位：米）

    private bool hasArrived = false;

 

    void Update()
    {
        if (hasArrived || playerHead == null || destinationPoint == null) return;

        float distance = Vector3.Distance(playerHead.position, destinationPoint.position);

        if (distance <= arrivalThreshold)
        {
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
            hasArrived = true;
            SaveArrowDataToFile();
            ShowFinishDialog();
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
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
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
    }

    public void StartNavigation()
    {
<<<<<<< HEAD

        ArrowController.triggeredArrows.Clear();
        Debug.Log("🔴 开始记录导航触发状态");
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b

        ArrowController.triggeredArrows.Clear();
        Debug.Log("🔴 开始记录导航触发状态");//zou
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
    }

 

    private void ShowFinishDialog()
    {
        Debug.Log("📣 尝试显示完成对话框");

        if (dialogPool1 == null)
        {
            Debug.LogError("❌ dialogPool1 is null — 无法显示完成对话框！");
            return;
        }

        dialogPool1.Get()
            .SetHeader("🎯 You have arrived at the destination.")
            .Show();
    }

    private void SaveArrowDataToFile()
    {
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string savePath = Path.Combine(Application.persistentDataPath, $"TriggeredArrows_{timestamp}.txt");

        try
        {
            File.WriteAllLines(savePath, ArrowController.triggeredArrows);
            Debug.Log($"✅ 已保存箭头路径到本地文件: {savePath}");
        }
        catch (IOException e)
        {
            Debug.LogError($"❌ 保存文件失败: {e.Message}");
        }

        ArrowController.triggeredArrows.Clear();
    }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
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

>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
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
<<<<<<< HEAD
                Debug.Log("❌ Navigation canceled.");
=======
<<<<<<< HEAD
                Debug.Log("❌ Navigation canceled.");
=======
<<<<<<< HEAD
                Debug.Log("❌ Navigation canceled.");
=======
                Debug.Log("❌ Navigation canceled.");     //如果用户不选择开始，需要说重新开始或者退出吗
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
            })
            .Show();
    }

<<<<<<< HEAD
    public void EnableArrowMode(bool enabled)
    {
        isArrowMode = enabled;
    }

=======
<<<<<<< HEAD
    

=======
<<<<<<< HEAD
    

=======
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
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
}