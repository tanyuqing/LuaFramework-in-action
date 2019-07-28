using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace LuaFramework {
    public class CustomBehaviour : View {
        private string data = null;
        private Dictionary<string, LuaFunction> buttons = new Dictionary<string, LuaFunction>();

        protected void Awake() {
            //Util.CallMethod(name, "Awake", gameObject);
            Debug.Log("===CustomBehaviour.awake");
            Invoke("DelayedAwake", 0.1f);
            Debug.Log("===CustomBehaviour.awake1");
        }

        private void DelayedAwake ()
        {
            Util.CallMethod(name, "Awake", gameObject);
            Debug.Log("===CustomBehaviour.delayAwake");
        }

        protected void Start() {
            Util.CallMethod(name, "Start");
        }

        protected void OnClick() {
            Util.CallMethod(name, "OnClick");
        }

        protected void OnClickEvent(GameObject go) {
            Util.CallMethod(name, "OnClick", go);
        }

        //-----------------------------------------------------------------
        protected void OnDestroy() {
#if ASYNC_MODE
            string abName = name.ToLower().Replace("panel", "");
            ResManager.UnloadAssetBundle(abName + AppConst.ExtName);
#endif
            Util.ClearMemory();
            Debug.Log("~" + name + " was destroy!");
        }
    }
}