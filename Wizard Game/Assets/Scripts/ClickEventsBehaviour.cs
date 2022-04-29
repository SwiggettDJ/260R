using UnityEngine;
using UnityEngine.Events;
public class ClickEventsBehaviour : MonoBehaviour
{
    public UnityEvent clickEvent;
    public void OnMouseDown()
    {
        clickEvent.Invoke();
    }
}
