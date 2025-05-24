using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.UX;

public class Nav_Test : MonoBehaviour
{
    public string targetDoorName = "Door_Left7"; // 在 Inspector 或代码中设置目标门名字
    public Animator animator;

    public DialogPool dialogPool;

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false; // 暂不导航

        // 根据名称查找目标 Transform
        GameObject targetObj = GameObject.Find(targetDoorName);
        if (targetObj != null)
        {
            target = targetObj.transform;
            

            //if (animator != null)
            //    animator.SetTrigger("Greeting");
            Invoke(nameof(ShowIntroDialog), 2f);
            
        }
        else
        {
            Debug.LogError("未找到目标门：" + targetDoorName);
        }
    }

    void ShowIntroDialog()
    {
        dialogPool.Get()
           .SetHeader("Hey there!")
           .SetBody("I'm your navigation assistant — Atlas.\n\nI'll guide you step by step.\n\nJust follow me!")
           .SetPositive("OK", _ =>
           {
               Debug.Log("✅ Intro done");
               ShowConfirmDialog();
           })
           .Show();
    }

    void ShowConfirmDialog()
    {
        dialogPool.Get()
            .SetHeader("Ready to start?")
            .SetBody("Start navigation now?")
            .SetPositive("Yes", _ =>
            {
                Debug.Log("✅ Navigation started.");
                StartNavigation();
                // 启动导航逻辑...
            })
            .SetNegative("No", _ =>
            {
                Debug.Log("❌ Navigation canceled.");
            })
            .Show();
    }

    void StartNavigation()
    {
        if (target != null)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (!agent.enabled || target == null) return;

        float speed = agent.velocity.magnitude;

        if (animator != null)
        {
            animator.SetFloat("Speed", speed > 0.1f ? 0.5f : 0f);
        }

        Vector3 direction = agent.steeringTarget - transform.position;
        direction.y = 0;
        float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

        if (animator != null && speed > 0.1f)
        {
            if (angle > 45f && angle < 135f)
            {
                animator.SetTrigger("Turn_right");
            }
            else if (angle < -45f && angle > -135f)
            {
                animator.SetTrigger("Turn_left");
            }
            else if (Mathf.Abs(angle) >= 135f)
            {
                animator.SetTrigger("Turn_back");
            }
        }
        // 到达终点
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            if (animator != null)
                animator.SetTrigger("Waving");

            // TODO: 触发结束提示，比如显示 UI 对话框
        }
    }
}