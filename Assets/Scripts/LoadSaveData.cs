using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class LoadSaveData : MonoBehaviour
{
    public ClassAppointmentList classAppointments;

    string filePath;
    string jsonString;

    public ClassAppointment lastClassAppointmentGiven;

    public Canvas removeAllCanvas;

    void Awake()
    {
        try
        {
            //filePath = Application.dataPath + "/Saves/classAppointments.json";
            filePath = Application.persistentDataPath + "/classAppointments.json";
            jsonString = File.ReadAllText(filePath);
            classAppointments = JsonUtility.FromJson<ClassAppointmentList>(jsonString);
        }
        catch (Exception) { CreateJsonFile(); }
        if (classAppointments == null) classAppointments = new ClassAppointmentList();

        //classApointments.Show();

        foreach (ClassAppointment c in classAppointments.classes) {
            GetComponent<AddClassAppointmentScript>().InstantiateClassAppointment(c.Id, c.X, c.Y, c.StudentName, c.MotherName, c.Hour, c.Address);
        }
    }

    void CreateJsonFile() {
        System.IO.File.WriteAllText(filePath, "aaaaa");
    }

    public void OnApplicationQuit()
    {
        SaveClassAppointmentPositions();

        jsonString = JsonUtility.ToJson(classAppointments);
        File.WriteAllText(filePath, jsonString);
    }

    public void SaveClassAppointmentPositions() {
        GameObject[] ca = GameObject.FindGameObjectsWithTag("ClassAppointment");
        for (int i = 0; i < ca.Length; i++){
            FieldsControl fc = ca[i].GetComponent<FieldsControl>();
            classAppointments.FindAndSavePosition(fc.Id, ca[i].transform.position.x, ca[i].transform.position.y);
        }
    }
    

    public void CreateClassAppointment(int id, float x, float y, string studentName, string motherName, string hour, string address) {
        if (studentName == "" || motherName == "" || hour == "" || address == "") {
            throw new Exception("Camps buits.");
        }

        lastClassAppointmentGiven = new ClassAppointment(id, x, y, studentName, motherName, hour, address);
        classAppointments.Add(lastClassAppointmentGiven);
    }

    public void DeleteClassAppointment(int id) {
        classAppointments.Delete(id);
    }

    public int GetFreeId() {
        return classAppointments.GetFreeId();
    }



    //Remove all
    public void ShowRemoveAllCanvas()
    {
        removeAllCanvas.enabled = true;

        foreach (DragDropScript d in GameObject.FindObjectsOfType<DragDropScript>()) {
            d.enabled = false;
        }
    }

    public void HideRemoveAllCanvas() {
        removeAllCanvas.enabled = false;

        foreach (DragDropScript d in GameObject.FindObjectsOfType<DragDropScript>())
        {
            d.enabled = true;
        }
    }

    public void RemoveAll()
    {
        GameObject[] ca = GameObject.FindGameObjectsWithTag("ClassAppointment");
        for (int i = 0; i < ca.Length; i++)
        {
            Destroy(ca[i]);
        }

        classAppointments.classes.Clear();

        HideRemoveAllCanvas();
    }
}
