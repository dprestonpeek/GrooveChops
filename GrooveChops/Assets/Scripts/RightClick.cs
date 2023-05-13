using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class RightClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;

    [SerializeField]
    bool quickplayHoverEvent = false;
    [SerializeField]
    bool noteConfigHoverEvent = false;
    [SerializeField]
    bool noteConfigOrderChange = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (noteConfigOrderChange)
            {
                NoteColorPicker.Instance.SelectInputField(GetComponent<TMP_InputField>());
            }
            else
            {
                if (leftClick != null)
                {
                    leftClick.Invoke();
                }
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            if (middleClick != null)
            {
                middleClick.Invoke();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (rightClick != null)
            {
                rightClick.Invoke();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (quickplayHoverEvent)
        {
            //get reference to button
            QuickplayManager.Instance.selectedSong = transform.parent.GetComponent<Song>();
        }
        if (noteConfigHoverEvent)
        {
            NoteColorPicker.Instance.SetHoveredButton(gameObject);
        }
    }
}