using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 自定义的添加UI监听的方法，可以用lua中调用以做事件绑定
/// </summary>
public class UIEventEx {
    //添加监听
    public static void AddButtonClick(GameObject go, LuaFunction luafunc)
    {
        if (go == null || luafunc == null)
            return;

        Button btn = go.GetComponent<Button>();
        if (btn == null)
            return;

        btn.onClick.AddListener
        (
            delegate ()
            {
                luafunc.Call(go);
            }
        );
    }

    //添加监听（外带数据中转功能）
    public static void AddButtonClick(GameObject go, LuaFunction luafunc, LuaTable luatable)
    {
        if (go == null || luafunc == null)
            return;

        Button btn = go.GetComponent<Button>();
        if (btn == null)
            return;

        btn.onClick.AddListener
        (
            delegate ()
            {
                luafunc.Call(go, luatable);
            }
        );
    }

    /// <summary>
    /// 给Toggle组件添加监听
    /// </summary>
    public static void AddToggle(GameObject go, LuaFunction luafunc, LuaTable luatable)
    {
        if (go == null || luafunc == null) return;

        Toggle toggle = go.GetComponent<Toggle>();

        if (toggle == null) return;

        go.GetComponent<Toggle>().onValueChanged.AddListener(
            delegate (bool select) {
                luafunc.Call(luatable, select);
            }
        );
    }


    /// <summary>
    /// 给Toggle组件添加监听
    /// </summary>
    public static void AddToggle(GameObject go, LuaFunction luafunc)
    {
        if (go == null || luafunc == null) return;

        Toggle toggle = go.GetComponent<Toggle>();

        if (toggle == null) return;

        go.GetComponent<Toggle>().onValueChanged.AddListener(
            delegate (bool select) {
                luafunc.Call(select);
            }
        );

        //go.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    //给输入组件（InputField）添加结束编辑(OnEndEdit)监听
    public static void AddInputFieldEndEditHandler(GameObject go, LuaFunction luafunc)
    {
        if (go == null || luafunc == null) return;

        InputField input = go.GetComponent<InputField>();

        if (input == null)
        {
            Debug.LogError(go.name + "找不到InputField组件");
            return;
        }

        go.GetComponent<InputField>().onEndEdit.AddListener(
            delegate (string text) {
                luafunc.Call(text);
            }
        );
    }

    /// <summary>
    /// 添加对光标按下|抬起事件的支持
    /// </summary>
    /// <param name="go">目标对象</param>
    /// <param name="luafunc">按下事件</param>
    /// <param name="luafunc2">抬起事件</param>
    public static void AddPointerDownUpSupport(GameObject go, LuaFunction luafunc, LuaFunction luafunc2)
    {
        if (go == null) return;

        EventsSupport es = go.AddComponent<EventsSupport>();

        es.InitDownUpHandler((PointerEventData pointerEventData) => {
            if (luafunc != null)
            {
                luafunc.Call(go, pointerEventData);
            }

        }, (PointerEventData pointerEventData) => {
            if (luafunc2 != null)
            {
                luafunc2.Call(go, pointerEventData);
            }
        });
    }

    /// <summary>
    /// 给Slider组件添加onValueChanged事件
    /// </summary>
    /// <param name="go"></param>
    /// <param name="luafunc"></param>
    public static void AddSliderOnChangeEvent(GameObject go, LuaFunction luafunc)
    {
        if (go == null || luafunc == null) return;

        Slider component = go.GetComponent<Slider>();

        if (component == null)
        {
            Debug.LogError(go.name + "找不到Slider组件");
            return;
        }

        go.GetComponent<Slider>().onValueChanged.AddListener(
            delegate (float val) {
                luafunc.Call(val);
            }
        );
    }

    //清除监听
    public static void ClearButtonClick(GameObject go)
    {
        if (go == null)
            return;

        Button btn = go.GetComponent<Button>();
        if (btn == null)
            return;

        btn.onClick.RemoveAllListeners();
    }

}
