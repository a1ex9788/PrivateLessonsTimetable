using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddClassAppointmentScript : MonoBehaviour
{
    public GameObject stickyNote;
    public Sprite stickyNoteImage1;
    public Sprite stickyNoteImage2;
    public Sprite stickyNoteImage3;

    System.Random random = new System.Random();

    public GameObject addClassAppointmentCanvas;    

    public void ShowAddClassAppointmentCanvas() {
        Instantiate(addClassAppointmentCanvas, new Vector3(0, 0, 0), new Quaternion());
    }

    public string AddClassAppointment(string studentName, string motherName, string hour, string address) {
        try {
            LoadSaveData ls = GameObject.FindObjectOfType<LoadSaveData>();

            int id = ls.GetFreeId();            

            
            ls.CreateClassAppointment(id, 0, 0, studentName, motherName, hour, address);

            InstantiateClassAppointment(id, 600, -60, studentName, motherName, hour, address);

            return "";
        } catch (Exception ex) {
            return ex.Message;
        }        
    }

    public void InstantiateClassAppointment(int id, float x, float y, string studentName, string motherName, string hour, string address) {
        stickyNote.GetComponentInChildren<SpriteRenderer>().sprite = GetRandomSprite();
        GameObject a = GameObject.Instantiate(stickyNote, new Vector2(x, y), Quaternion.identity);
        a.GetComponent<FieldsControl>().SetFields(id, x, y, studentName, motherName, hour, address);
    }

    Sprite GetRandomSprite()
    {
        Sprite res = stickyNoteImage1;
        int randomNumber = random.Next(1, 4);

        switch (randomNumber)
        {
            case 1: res = stickyNoteImage1; break;
            case 2: res = stickyNoteImage2; break;
            case 3: res = stickyNoteImage3; break;
        }

        return res;
    }
}
