using UnityEngine;

public class Turnip : Crop
{
    public override void Harvest(){
        Debug.Log("Panen Turnip!");
    }
    
    void Start()
    {
        hoursToGrow = 3;
    }

}
