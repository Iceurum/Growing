using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour {
    
    public float interval = 5f;
    public UnityEvent onTick;
    
    private float timer;

    private void Update() {
        timer += Time.deltaTime;
        
        if (timer >= interval) {
            timer = 0f;
            onTick.Invoke();
        }
    }
}
