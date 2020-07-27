using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



// Functionality:
// This logger has two primary functions:
//  - It logs telemetry in regular intervals. This telemetry is the location and orientation of the headset
//  - It logs events whenever they occur

// How to use it - Telemetry
// To use the telemetry functionality, only the reference for the headset must be set in the unity editor
// (i.e. dragging the gameobject on top of the field labeled "Hmd" and dropping it). The logger starts recording
// automatically and does not needed to be started manually.

// How to use it - Events
// Events are defined by the researcher and are *only* logged when triggered by a script outside of the logger calling
// a log-event-function of it.
// To log an event, an external script could call the LogEven(...) function defined below. However, for the sake
// of code clarity, it is advised that the researcher implements a dedicated log-event-function and calls that instead.
// Examples of functions like that are given from line 109 to 123.

// Where are the logs stored?
// When executed on a Windows machine, the logs are stored under C:\Users\<User name>\AppData\LocalLow\<company name>
// When executed on an Oculus Quest, the logs are stored under Android/data/<packagename>/files


// What the log entries contain - Telemetry
// - Timestamp, Unix time (absolute time, machine readable, timezone independent)
// - Timestamp, time since start in seconds (reltative time)
// - Timestamp, local time (absolute time, human readable, timezone dependent)
// - HMD Location
// - HMD Orientation


// What the log entries contain - Event log
// - Timestamp, Unix time (absolute time, machine readable, timezone independent)
// - Timestamp, time since start in seconds (reltative time)
// - Timestamp, local time (absolute time, human readable, timezone dependent)
// - Event identifier (machine and human readable, intended for easy filtering, should be unique for that event type)
// - Event description (human readable, intended to provide additional information)


public class Logger : MonoBehaviour
{

    //private StreamWriter m_eventLogger;
    private StreamWriter m_telemetryLoggerCircle;
    private StreamWriter m_telemetryLoggerCursor;


    [Tooltip("The object representing the user's headset")]
    public Transform hmd;
    public Transform cursor;
    
    [Tooltip("The interval for the telemetry log in seconds.")]
    public float logIntervals = 0.5f; // 0.5 is default

    private float m_lastLogTime = 0;

    // Use this for initialization
    void Start() {
        // Check if log folder exists and create if not
        Directory.CreateDirectory(Application.persistentDataPath + "/Logs");

        // create writers
        string timeStamp = System.DateTime.Now.ToString("yyyymmdd_hhmmss");
        //m_eventLogger = new StreamWriter(Application.persistentDataPath + "/Logs/" + timeStamp + "_event.log");
        m_telemetryLoggerCircle = new StreamWriter(Application.persistentDataPath + "/Logs/" + timeStamp + "_telemetryCircle.log");
        m_telemetryLoggerCursor = new StreamWriter(Application.persistentDataPath + "/Logs/" + timeStamp + "_telemetryCursor.log"); 

    }

    // Update is called once per frame
    void Update() {
        // log telemetry in regular intervals
        if (m_lastLogTime + logIntervals < Time.time) {
            LogTelemetry();
            m_lastLogTime = Time.time;
        }
    }


    private void LogTelemetry() {
        string unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        string timeSinceStart = Time.time.ToString();
        string timeStamp = System.DateTime.Now.ToString("hhmmss");

        Vector3 hmdPos = hmd.position;
        string hmdPosString = hmdPos.ToString("F3");

        Vector3 hmdRot = hmd.eulerAngles;
        string hmdRotString = hmdRot.ToString();

        Vector3 cursorPos = cursor.position;
        string cursorPosString = cursorPos.ToString("F3");

        Vector3 cursorRot = cursor.eulerAngles;
        string cursorRotString = cursorRot.ToString();

        m_telemetryLoggerCircle.WriteLine(unixTime + "," + timeSinceStart + "," + timeStamp + "," + hmdPosString + "," + hmdRotString);
        m_telemetryLoggerCircle.Flush();
        m_telemetryLoggerCursor.WriteLine(unixTime + "," + timeSinceStart + "," + timeStamp + "," + cursorPosString + "," + cursorRotString);
        m_telemetryLoggerCursor.Flush();
    }

    // private void LogEvent(string eventIdentifier, string eventDescription) {
    //     string unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
    //     string timeSinceStart = Time.time.ToString();
    //     string timeStamp = System.DateTime.Now.ToString("hhmmss");

    //     m_eventLogger.WriteLine(unixTime + "," + timeSinceStart + "," + timeStamp + "," + eventIdentifier + "," + eventDescription);
    //     m_eventLogger.Flush();
    // }


    // #region Examples for log-event-functions
    // public void LogStart() {
    //     string eventDescription = "The Experimenter Started the Experiment";
    //     LogEvent("ES", eventDescription);
    // }

    // public void LogEnd()
    // {
    //     string eventDescription = "The Experiment ended";
    //     LogEvent("EE", eventDescription);
    // }

    // public void LogContinuation() {
    //     string eventDescription = "The Experimenter Continued the Experiment";
    //     LogEvent("EC", eventDescription);
    // }
    // #endregion

    // void OnApplicationQuit() {
    //     m_eventLogger.Close();
    //     m_telemetryLogger.Close();
    // }
}
