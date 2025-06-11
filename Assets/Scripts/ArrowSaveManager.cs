using UnityEngine;
using System.IO;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;

public class ArrowSaveManager : MonoBehaviour
{
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
            hasArrived = true;
            SaveArrowDataToFile();
            ShowFinishDialog();
        }
    }

    public void StartNavigation()
    {

        ArrowController.triggeredArrows.Clear();
        Debug.Log("🔴 开始记录导航触发状态");//zou
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
                Debug.Log("❌ Navigation canceled.");
            })
            .Show();
    }

    

}