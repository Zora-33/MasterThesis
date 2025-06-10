using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GazeLogger : MonoBehaviour
{
    private string logPath;
    private float logInterval = 0.2f;
    private float timer = 0f;

    void Start()
    {
        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        logPath = Path.Combine(Application.persistentDataPath, $"GazeLog_{timeStamp}.csv");
        File.AppendAllText(logPath, "Time,Tag,HitPoint\n");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= logInterval)
        {
            timer = 0f;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
<<<<<<< HEAD
                string objTag = hitInfo.collider.gameObject.name;
=======
                string objTag = hitInfo.collider.gameObject.tag;
>>>>>>> be661738128d38105003abea2dfc36fa72deb7c4
                string hitPos = hitInfo.point.ToString("F2");
                string logLine = $"{Time.time:F2},{objTag},{hitPos}\n";
                Debug.Log(logLine);
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