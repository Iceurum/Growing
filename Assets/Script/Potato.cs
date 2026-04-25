using UnityEngine;

public class Potato : Crop
{
    public override void Harvest() {
        Debug.Log("Panen Potato!");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoursTogrow = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
