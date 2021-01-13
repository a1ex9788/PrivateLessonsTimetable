using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldsControl : MonoBehaviour
{
    public Text Hour;
    public Text StudentName;
    public Text MotherName;
    public Text Address;

    public int Id;

    public void SetFields(int id, float x, float y, string studentName, string motherName, string hour, string address)
    {
        //NameObject
        Id = id;
        this.name = "ClassAppointment - " + id;

        //Order in Layer
        this.GetComponentInChildren<SpriteRenderer>().sortingOrder = id;
        this.GetComponentInChildren<Canvas>().sortingOrder = id;

        //ClassAppointment fields
        Hour.text = hour;
        StudentName.text = studentName;
        MotherName.text = motherName;
        Address.text = address;
    }
}
