using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Actions/Game Action")]
public class GameAction : ScriptableObject
{
    public UnityAction<object> Raise { get; set; }
    public UnityAction<Coroutine> raiseCoroutine;
    public UnityAction raiseNoArgs;
    
    public void RaiseAction()
    {
        raiseNoArgs?.Invoke();
    }

    public void RaiseAction(object obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(float obj)
    {
        Raise?.Invoke(obj);
    }
    
    public void RaiseAction(int obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(Transform obj)
    {
        Raise?.Invoke(obj);
    }

    public void RaiseAction(Coroutine obj)
    {
        raiseCoroutine?.Invoke(obj);
    }
}
