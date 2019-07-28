using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*  其它事件可根据需要在此类中实现
    IPointerEnterHandler - OnPointerEnter - Called when a pointer enters the object
    IPointerExitHandler - OnPointerExit - Called when a pointer exits the object
    IPointerDownHandler - OnPointerDown - Called when a pointer is pressed on the object
    IPointerUpHandler - OnPointerUp - Called when a pointer is released (called on the original the pressed object)
    IPointerClickHandler - OnPointerClick - Called when a pointer is pressed and released on the same object
    IInitializePotentialDragHandler - OnInitializePotentialDrag - Called when a drag target is found, can be used to initialise values
    IBeginDragHandler - OnBeginDrag - Called on the drag object when dragging is about to begin
    IDragHandler - OnDrag - Called on the drag object when a drag is happening
    IEndDragHandler - OnEndDrag - Called on the drag object when a drag finishes
    IDropHandler - OnDrop - Called on the object where a drag finishes
    IScrollHandler - OnScroll - Called when a mouse wheel scrolls
    IUpdateSelectedHandler - OnUpdateSelected - Called on the selected object each tick
    ISelectHandler - OnSelect - Called when the object becomes the selected object
    IDeselectHandler - OnDeselect - Called on the selected object becomes deselected
    IMoveHandler - OnMove - Called when a move event occurs (left, right, up, down, ect)
    ISubmitHandler - OnSubmit - Called when the submit button is pressed
    ICancelHandler - OnCancel - Called when the cancel button is pressed
 */

/// <summary>
/// unity事件支持（本类用于实现Unity中的各种事件，借给Lua调用）
/// </summary>
public class EventsSupport : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Action<PointerEventData> onPointerDownHandler = null;
    Action<PointerEventData> onPointerUpHandler = null;

    public void InitDownUpHandler (Action<PointerEventData> downHandler, Action<PointerEventData> upHandler)
    {
        onPointerDownHandler = downHandler;
        onPointerUpHandler = upHandler;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        //Debug.Log("[" + name + "] Game Object Click in Progress");
        
        if (onPointerDownHandler != null) {
            onPointerDownHandler(pointerEventData);
        }
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //Debug.Log("[" +　name + "] No longer being clicked");
        if (onPointerUpHandler != null)
        {
            onPointerUpHandler(pointerEventData);
        }
    }
}
