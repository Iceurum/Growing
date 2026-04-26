using UnityEngine;

public abstract class Crop : MonoBehaviour
{
    public int hoursToGrow;
    public int currentHour;

    public virtual void Grow() {
        if (currentHour < hoursToGrow) {
            currentHour++;
            Debug.Log(name + " tumbuh! Jam: " + currentHour + "/" + hoursToGrow);
        }
    }

    public bool IsReady() {
        return currentHour >= hoursToGrow;
    }

    public abstract void Harvest();
    
}