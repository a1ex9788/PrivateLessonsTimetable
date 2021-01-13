using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    public GameObject trashBinButton;
    public float removeDistance;

    private void Start() {
        trashBinButton = GameObject.Find("TrashBin");
    }

    public void DestroyIfNear() {
        if (Distance(transform.position, trashBinButton.transform.position) < removeDistance) {
            int id = int.Parse(this.name.Split('-').GetValue(1).ToString());
            GameObject.FindObjectOfType<LoadSaveData>().DeleteClassAppointment(id);

            Destroy(gameObject);
        }
    }

    private float Distance(Vector3 a, Vector3 b)
    {
        Vector2 v = Substract(a, b);
        return Mathf.Abs(v.x) + Mathf.Abs(v.y);
    }

    private Vector3 Substract(Vector3 a, Vector3 b) {
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }
}
