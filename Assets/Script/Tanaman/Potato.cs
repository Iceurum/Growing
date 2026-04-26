using UnityEngine;

public class Potato : Crop
{
    public override void Harvest() {
        Debug.Log("Panen Potato!");
    }

    void Start()
    {
        hoursToGrow = 5;
    }

}
