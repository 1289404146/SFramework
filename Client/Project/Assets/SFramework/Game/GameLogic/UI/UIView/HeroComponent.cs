using UnityEngine.UI;

public class HeroComponent:BaseMono
{
    public Text text;
    private void Awake()
    {
        text = transform.Find("Label").GetComponent<Text>();
    }
}