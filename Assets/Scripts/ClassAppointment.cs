using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassAppointment
{
    public int Id;
    public float X, Y;
    public string StudentName;
    public string MotherName;
    public string Hour;
    public string Address;

    public ClassAppointment(int id, float x, float y, string studentName, string motherName, string hour, string address)
    {
        Id = id;
        X = x;
        Y = y;
        StudentName = studentName;
        MotherName = motherName;
        Hour = hour;
        Address = address;
    }    

    public override string ToString()
    {
        return Id + ", " + StudentName + ", " + MotherName + ", " + Hour + ", " + Address;
    }

    public override bool Equals(object obj)
    {
        return StudentName.Equals(((ClassAppointment) obj).StudentName)
            && MotherName.Equals(((ClassAppointment) obj).MotherName)
            && Hour.Equals(((ClassAppointment) obj).Hour)
            && Address.Equals(((ClassAppointment) obj).Address);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode(); 
    }
}



[System.Serializable]
public class ClassAppointmentList
{
    public List<ClassAppointment> classes;

    public ClassAppointmentList() { classes = new List<ClassAppointment>(); }

    public void Show()
    {
        foreach (ClassAppointment c in classes) { Debug.Log(c); }
    }

    public void Add(ClassAppointment c)
    {
        foreach (ClassAppointment c1 in classes) {
            if (c.Equals(c1)) throw new System.Exception("Ja hi ha una classe amb les mateixes dades.");
        }

        classes.Add(c);
    }

    public void Delete(int id)
    {
        foreach (ClassAppointment c in classes)
        {
            if (c.Id == id) { classes.Remove(c); break; }
        }
    }

    public int GetLength() { return classes.Count; }

    public int GetFreeId()
    {
        int i = 0;
        bool free = false;

        while (!free) {
            free = true;

            foreach (ClassAppointment c in classes)
            {
                if (c.Id == i) { free = false; break; }
            }

            if (!free) i++;
        }

        return i;
    }

    public void FindAndSavePosition(int id, float x, float y) {
        ClassAppointment c = null;
        foreach (ClassAppointment c1 in classes) {
            if (c1.Id == id) c = c1;
        }

        if (c != null) {
            c.X = x;
            c.Y = y;
        }
    }
}
