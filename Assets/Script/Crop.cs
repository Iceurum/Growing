using UnityEngine;

public abstract class Crop : MonoBehaviour
{
    public int hoursTogrow;
    public int currentHour;

    public virtual void Grow() {
        currentHour++;
    }

    public bool IsReady() {
        return currentHour >= hoursTogrow;
    }

    public abstract void Harvest();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}