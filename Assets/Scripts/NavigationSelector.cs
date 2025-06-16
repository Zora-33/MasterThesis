using System.Collections;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;
using UnityEngine;

public class NavigationSelector : MonoBehaviour
{
    public GameObject agentNavRoot;         // 包含 Agent 模型和 Nav_Test 脚本的对象
    public GameObject arrowNavRoot;         // 包含 ArrowSaveManager 和所有箭头的根节点
    public DialogPool dialogPool;           // 通用 DialogPool
    public ArrowSaveManager ASM;
    public Nav_Test AgentNavi;
<<<<<<< HEAD
    public GazeLogger gazeLogger;

=======
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92

    void Start()
    {
        ShowNavigationChoice();
    }

    void ShowNavigationChoice()
    {
        dialogPool.Get()
            .SetHeader("Choose Navigation Mode")

            .SetPositive("Arrow", _ => StartArrowMode())
            .SetNegative("Agent", _ => StartAgentMode())
            .Show();
    }

    void ShowIntroDialogArrow()
    {
        dialogPool.Get()
           .SetHeader("Hey there!")
           .SetBody("I'm your navigation assistant — Atlas.\n\nI'll guide you step by step.\n\nJust follow me!")
           .SetPositive("OK", _ => ASM.ShowConfirmDialog())
           .Show();
    }

    void ShowIntroDialogAgent()
    {
        dialogPool.Get()
           .SetHeader("Hey there!")
           .SetBody("I'm your navigation assistant — Atlas.\n\nI'll guide you step by step.\n\nJust follow me!")
           .SetPositive("OK", _ => AgentNavi.ShowConfirmDialog())
           .Show();
    }

    void StartArrowMode()
    {
        Debug.Log("🟦 Arrow mode selected.");
<<<<<<< HEAD
        ASM.EnableArrowMode(true);
        gazeLogger.StartLogging();
=======
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
        arrowNavRoot.SetActive(true);
        agentNavRoot.SetActive(false);
        ShowIntroDialogArrow();

    }

    void StartAgentMode()
    {
        Debug.Log("🧍 Agent mode selected.");
<<<<<<< HEAD
        ASM.EnableArrowMode(false);
        gazeLogger.StartLogging();
=======
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
        agentNavRoot.SetActive(true);
        arrowNavRoot.SetActive(false);
        ShowIntroDialogAgent();

    }
}