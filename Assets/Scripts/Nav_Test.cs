using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.UX;

public class Nav_Test : MonoBehaviour
{
    [System.Serializable]
    public class PlatformPoint
    {
        public Transform point;
        public bool waitForUser;
    }

    public List<PlatformPoint> platformPoints = new List<PlatformPoint>();
<<<<<<< HEAD
    //public string targetDoorName = "Door_right5";
    public GameObject targetObj;
=======
<<<<<<< HEAD
    //public string targetDoorName = "Door_right5";
    public GameObject targetObj;
=======
<<<<<<< HEAD
    //public string targetDoorName = "Door_right5";
    public GameObject targetObj;
=======
    public string targetDoorName = "Door_right5";
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
    public Animator animator;
    public DialogPool dialogPool;
    public Transform userTransform;
    private string lastTurn = "";
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    private int currentPlatformIndex = 0;
    private bool isWaitingForUser = false;
    private bool waitingAtPlatform = false;
    private bool hasArrived = false;
    private bool hasShownDialog = false;
    private bool reachedFinalTarget = false;
<<<<<<< HEAD
    //private bool isNavigationStarted = false;
=======
<<<<<<< HEAD
    //private bool isNavigationStarted = false;
=======
<<<<<<< HEAD
    //private bool isNavigationStarted = false;
=======
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b

    private float waitDistance = 5f;
    private float resumeDistance = 2f;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false;

<<<<<<< HEAD
        //GameObject targetObj = GameObject.Find(targetDoorName);
=======
<<<<<<< HEAD
        //GameObject targetObj = GameObject.Find(targetDoorName);
=======
<<<<<<< HEAD
        //GameObject targetObj = GameObject.Find(targetDoorName);
=======
        GameObject targetObj = GameObject.Find(targetDoorName);
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
        if (targetObj != null)
        {
            target = targetObj.transform;
            //Invoke(nameof(ShowIntroDialog), 2f);
        }
        else
        {
<<<<<<< HEAD
            //Debug.LogError("❌ 未找到目标门：" + targetDoorName);
=======
<<<<<<< HEAD
            //Debug.LogError("❌ 未找到目标门：" + targetDoorName);
=======
<<<<<<< HEAD
            //Debug.LogError("❌ 未找到目标门：" + targetDoorName);
=======
            Debug.LogError("❌ 未找到目标门：" + targetDoorName);
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
        }
    }

    //void ShowIntroDialog()
    //{
    //    dialogPool.Get()
    //       .SetHeader("Hey there!")
    //       .SetBody("I'm your navigation assistant — Atlas.\n\nI'll guide you step by step.\n\nJust follow me!")
    //       .SetPositive("OK", _ => ShowConfirmDialog())
    //       .Show();
    //}

    public void ShowConfirmDialog()
    {
        dialogPool.Get()
            .SetHeader("Ready to start?")
            .SetBody("Start navigation now?")
            .SetPositive("Yes", _ =>
            {
                Debug.Log("✅ Navigation started.");
                StartNavigation();
            })
            .SetNegative("No", _ =>
            {
                ShowConfirmDialog();
                Debug.Log("❌ Navigation canceled.");
            })
            .Show();
    }

    void CloseToAgentDialog()
    {
        if (!hasShownDialog)
        {
            dialogPool.Get()
                .SetHeader("Come on, follow me.")
                .SetBody("You need to get a little closer to the agent.")
                .Show();
            hasShownDialog = true;
        }
    }

    void FinishDialog()
    {
        dialogPool.Get()
            .SetHeader("You have arrived at the destination.")
            .Show();
    }

    void StartNavigation()
    {
        if (platformPoints.Count == 0 || target == null) return;
<<<<<<< HEAD
        //isNavigationStarted = true;
=======
<<<<<<< HEAD
        //isNavigationStarted = true;
=======
<<<<<<< HEAD
        //isNavigationStarted = true;
=======

>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
        agent.enabled = true;
        agent.isStopped = false;

        currentPlatformIndex = 0;
        MoveToNextPlatform();
    }

    void Update()
    {
<<<<<<< HEAD
        //if (!agent.enabled || !isNavigationStarted || reachedFinalTarget) return;
        if (!agent.enabled || reachedFinalTarget) return;
=======
<<<<<<< HEAD
        //if (!agent.enabled || !isNavigationStarted || reachedFinalTarget) return;
        if (!agent.enabled || reachedFinalTarget) return;
=======
<<<<<<< HEAD
        //if (!agent.enabled || !isNavigationStarted || reachedFinalTarget) return;
        if (!agent.enabled || reachedFinalTarget) return;
=======
        if (!agent.enabled || reachedFinalTarget) return;

>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
        float speed = agent.velocity.magnitude;
        float smoothedSpeed = Mathf.Lerp(animator.GetFloat("Speed"), speed, Time.deltaTime * 5f);
        smoothedSpeed = Mathf.Clamp(smoothedSpeed, 0f, 2f); // 限制最大值


        if (agent.isStopped || isWaitingForUser || smoothedSpeed < 0.05f)
        {
            smoothedSpeed = 0f;
        }

        animator.SetFloat("Speed", smoothedSpeed);

        // 控制转向动画
        Vector3 direction = agent.steeringTarget - transform.position;
        direction.y = 0;
        float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
        if (animator != null && speed > 0.1f && !agent.isStopped)
        {
            string currentTurn = "";

            if (angle > 45f && angle < 135f)
                currentTurn = "Turn_right";
            else if (angle < -45f && angle > -135f)
                currentTurn = "Turn_left";
            else if (Mathf.Abs(angle) >= 135f)
                currentTurn = "Turn_back";

            if (!string.IsNullOrEmpty(currentTurn) && currentTurn != lastTurn)
            {
                animator.ResetTrigger("Turn_left");
                animator.ResetTrigger("Turn_right");
                animator.ResetTrigger("Turn_back");

                animator.SetTrigger(currentTurn);
                lastTurn = currentTurn;
            }
        }
        else
        {
            lastTurn = "";
        }

        // 到达目标点
<<<<<<< HEAD
        if (!agent.pathPending && agent.remainingDistance <= 0.05f && !hasArrived)
=======
<<<<<<< HEAD
        if (!agent.pathPending && agent.remainingDistance <= 0.05f && !hasArrived)
=======
<<<<<<< HEAD
        if (!agent.pathPending && agent.remainingDistance <= 0.05f && !hasArrived)
=======
        if (!agent.pathPending && agent.remainingDistance <= 0.5f && !hasArrived)
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
        {
            hasArrived = true;
            HandleArrivalLogic();
        }

        // 动态等待：非平台中用户离得太远
        if (!waitingAtPlatform && !isWaitingForUser && Vector3.Distance(transform.position, userTransform.position) > waitDistance)
        {
            Debug.Log("📏 用户距离过远，暂停等待");
            isWaitingForUser = true;
            agent.isStopped = true;
            CloseToAgentDialog();
            StartCoroutine(WaitForUserThenContinue());
        }
    }

    void HandleArrivalLogic()
    {
        if (currentPlatformIndex < platformPoints.Count)
        {
            var current = platformPoints[currentPlatformIndex];

            Debug.Log($"🧭 到达平台 {currentPlatformIndex + 1}, waitForUser = {current.waitForUser}");

            if (current.waitForUser && Vector3.Distance(transform.position, userTransform.position) > resumeDistance)
            {
                isWaitingForUser = true;
                waitingAtPlatform = true;
                agent.isStopped = true;
                animator.SetFloat("Speed", 0f);
                CloseToAgentDialog();
                StartCoroutine(WaitForUserThenContinue());
                return;
            }

            currentPlatformIndex++;
            MoveToNextPlatform();
        }
        else if (!reachedFinalTarget && target != null)
        {
            Debug.Log("🎯 到达终点门附近");
            agent.isStopped = true;
            animator?.SetTrigger("Waving");
            FinishDialog();
            reachedFinalTarget = true;
        }
    }

    IEnumerator WaitForUserThenContinue()
    {
        while (Vector3.Distance(transform.position, userTransform.position) > resumeDistance)
        {
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("✅ 用户已靠近，继续导航");
        isWaitingForUser = false;
        waitingAtPlatform = false;
        hasShownDialog = false;
        agent.isStopped = false;
        hasArrived = false;

        if (currentPlatformIndex < platformPoints.Count)
        {
            //currentPlatformIndex++;
            MoveToNextPlatform();
        }
        else if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void MoveToNextPlatform()
    {
        hasArrived = false;

        if (currentPlatformIndex < platformPoints.Count)
        {
            agent.SetDestination(platformPoints[currentPlatformIndex].point.position);
        }
        else if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}