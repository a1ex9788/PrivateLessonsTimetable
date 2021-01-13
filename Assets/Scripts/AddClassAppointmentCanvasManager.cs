using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddClassAppointmentCanvasManager : MonoBehaviour
{
    public Text errorText;
    public Text studentName;
    public Text motherName;
    public Text hour;
    public Text yard;
    public Text door;

    private void Start()
    {
        foreach (DragDropScript d in GameObject.FindObjectsOfType<DragDropScript>())
        {
            d.enabled = false;
        }
    }

    public void HideAddClassAppointmentCanvas()
    {
        foreach (DragDropScript d in GameObject.FindObjectsOfType<DragDropScript>())
        {
            d.enabled = true;
        }

        Destroy(gameObject);
    }

    public void AddClassAppointment()
    {
        string sn = studentName.text.ToUpper();
        string mn = motherName.text.ToUpper();
        string h = hour.text.ToUpper();
        string a = yard.text.ToUpper() + " pta " + door.text.ToUpper();

        string aux = FindObjectOfType<AddClassAppointmentScript>().AddClassAppointment(sn, mn, h, a);

        if (aux != "")
        {
            errorText.enabled = true;
            errorText.text = aux;
        }
        else {
            HideAddClassAppointmentCanvas();
        }
    }
}
