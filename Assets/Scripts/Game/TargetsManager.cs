using UnityEngine;

public class TargetsManager : MonoBehaviour
{
    public float Timer { get; set; }
    private int targets;

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            PlayerLost();
        }
    }

    private void PlayerLost()
    {
        
    }
    private void Start()
    {
        UpdateTargets();
    }

    public void UpdateTargets()
    {
        targets = FindObjectsOfType<Target>().Length;
    }

    public int GetTargetsAmmount()
    {
        return targets;
    }
    
    
}
