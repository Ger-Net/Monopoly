using System;

public class JailStreet : Street, INotBuyStreet
{
    public event Action JailEnd;

    public void Pass(Player player)
    {
        if (player.inJailCounter == 2)
        {
            player.inJailCounter = 0;
            JailEnd?.Invoke();
            return;
        }
        player.inJailCounter++;
    }
}
