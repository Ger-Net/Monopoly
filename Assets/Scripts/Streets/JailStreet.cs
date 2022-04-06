using System;

public class JailStreet : Street, INotBuyStreet
{
    private int counter;
    public event Action JailEnd;

    private void Start()
    {
        ToJailStreet toJailStreet = FindObjectOfType<ToJailStreet>();
        toJailStreet.InJail += StartPassing;
    }

    private void StartPassing() => counter = 0;

    public void Pass()
    {
        if (counter == 2)
        {
            counter = 0;
            JailEnd?.Invoke();
        }
        counter++;
    }
}
