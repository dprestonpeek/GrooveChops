using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RightClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            middleClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //get reference to button
        QuickplayManager.Instance.selectedSong = transform.parent.GetComponent<Song>();
    }
}