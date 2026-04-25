using UnityEngine;

public class Turnip : Crop
{
    public override void Harvest(){
        Debug.Log("Panen Turnip!");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoursTogrow = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
