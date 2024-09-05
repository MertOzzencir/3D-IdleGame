

using UnityEngine;

public interface Clickable 
{
    enum Materials
    {

        Wood,
        Rock,
        Bronz,
        Silver,
        Gold

    }
    public void Click();
    public Materials Material();
    public int Priority();

    
}
