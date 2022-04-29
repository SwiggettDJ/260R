using UnityEngine;
using  UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    public GameAction recieveHealthAction;
    public Slider slider;

    public void SetSlider(object health)
    {
        slider.value = (float)health;
    }

    private void Start()
    {
        recieveHealthAction.Raise += SetSlider;
    }
    
}
