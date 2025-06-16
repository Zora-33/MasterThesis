<<<<<<< HEAD
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GazeLogger : MonoBehaviour
{
    private string logPath;
    private float logInterval = 0.2f;
    private float timer = 0f;
<<<<<<< HEAD
    private bool isLogging = false;



    public void StartLogging()
    {
        if (isLogging) return;

        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        logPath = Path.Combine(Application.persistentDataPath, $"GazeLog_{timeStamp}.csv");
        File.AppendAllText(logPath, "Time,Tag,HitPoint\n");
        isLogging = true;
        Debug.Log("👁️ Gaze logging started.");
    }

    public void StopLogging()
    {
        if (!isLogging) return;

        isLogging = false;
        Debug.Log("🛑 Gaze logging stopped.");
=======

    void Start()
    {
        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        logPath = Path.Combine(Application.persistentDataPath, $"GazeLog_{timeStamp}.csv");
        File.AppendAllText(logPath, "Time,Tag,HitPoint\n");
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
    }

    void Update()
    {
<<<<<<< HEAD
        if (!isLogging) return;
=======
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
        timer += Time.deltaTime;
        if (timer >= logInterval)
        {
            timer = 0f;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
                string objTag = hitInfo.collider.gameObject.name;
                string hitPos = hitInfo.point.ToString("F2");
                string logLine = $"{Time.time:F2},{objTag},{hitPos}\n";
                //Debug.Log(logLine);
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
                string objTag = hitInfo.collider.gameObject.name;
=======
                string objTag = hitInfo.collider.gameObject.tag;
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
                string hitPos = hitInfo.point.ToString("F2");
                string logLine = $"{Time.time:F2},{objTag},{hitPos}\n";
                Debug.Log(logLine);
>>>>>>> 5122c96c277387915cc42e3a47421f6499b4f258
>>>>>>> 11f7ec2df91ffbb41a82ed203356a90cac32385b
>>>>>>> a030962cc03c360d12297e9aa3849316d533cd92
                File.AppendAllText(logPath, logLine);
            }
            else
            {
                string logLine = $"{Time.time:F2},None,None\n";
                File.AppendAllText(logPath, logLine);
            }
        }
    }
}