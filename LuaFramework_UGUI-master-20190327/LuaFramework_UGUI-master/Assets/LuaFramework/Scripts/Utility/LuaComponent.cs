/*
 * 让Lua脚本也能挂载到游戏物体上的组件
 * 
 * LuaComponent主要有Get和Add两个静态方法，其中Get相当于UnityEngine中的GetComponent方法，Add相当于AddComponent方法，
 * 只不过这里添加的是lua组件不是c#组件。每个LuaComponent拥有一个LuaTable（lua表）类型的变量table，它既引用上述的Component表。
 * Add方法使用AddComponent添加LuaComponent，调用参数中lua表的New方法，将其返回的表赋予table。
 * Get方法使用GetComponents获取游戏对象上的所有LuaComponent（一个游戏对象可能包含多个lua组件，由参数table决定需要获取哪一个），
 * 通过元表地址找到对应的LuaComponent，返回lua表
 * 
 * Add by Tan Yuqing 2018.11.22
 */

using UnityEngine;
using System.Collections;
using LuaInterface;
using LuaFramework;

public class LuaComponent : MonoBehaviour
{
    //Lua表
    public LuaTable table;

    //添加LUA组件  

    public static LuaTable Add(GameObject go, LuaTable tableClass)
    {

        LuaFunction fun = tableClass.GetLuaFunction("New");

        if (fun == null)

            return null;

        /*object[] rets = fun.Call(tableClass);
        if (rets.Length != 1)

            return null;

        LuaComponent cmp = go.AddComponent();

        cmp.table = (LuaTable)rets[0];
        */

        //lua升级后不，Call方法不再返回对象，因此改为Invoke方法实现
        object rets = fun.Invoke<LuaTable, object>(tableClass);
        if (rets == null)
        {
            return null;
        }
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.table = (LuaTable)rets;

        cmp.CallAwake();
        return cmp.table;
    }

    //添加LUA组件，允许携带额外一个参数（args）
    public static LuaTable Add(GameObject go, LuaTable tableClass, LuaTable args)
    {
        LuaFunction fun = tableClass.GetLuaFunction("New");
        if (fun == null)
            return null;

        object rets = fun.Invoke<LuaTable, object>(tableClass);
        if (rets == null)
        {
            return null;
        }
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.table = (LuaTable)rets;

        cmp.CallAwake(args);
        return cmp.table;
    }

    //添加LUA组件  
    // isAllowOneComponent为true时，表示只添加一次组件，如果已存在，就不再添加
    public static LuaTable Add(GameObject go, LuaTable tableClass, bool isAllowOneComponent)
    {
        //如果已存在，则不再添加
        LuaComponent luaComponent = go.GetComponent<LuaComponent>();
        if (luaComponent != null)
        {
            return null;
        }

        LuaFunction fun = tableClass.GetLuaFunction("New");

        if (fun == null)
            return null;

        object rets = fun.Invoke<LuaTable, object>(tableClass);
        if (rets == null)
        {
            return null;
        }
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.table = (LuaTable)rets;

        cmp.CallAwake();
        return cmp.table;
    }

    //获取lua组件

    public static LuaTable Get(GameObject go, LuaTable table)

    {
        /*
        LuaComponent[] cmps = go.GetComponents();
        foreach (LuaComponent cmp in cmps)
        {
            string mat1 = table.ToString();
            string mat2 = cmp.table.GetMetaTable().ToString();
            if (mat1 == mat2)
            {
                return cmp.table;
            }
        }
        */

        LuaComponent cmp = go.GetComponent<LuaComponent>();
        string mat1 = table.ToString();
        string mat2 = cmp.table.GetMetaTable().ToString();
        if (mat1 == mat2)
        {
            return cmp.table;
        }

        return null;

    }

    //删除LUA组件的方法略，调用Destory()即可  

    //调用lua表的Awake方法
    void CallAwake()
    {

        LuaFunction fun = table.GetLuaFunction("Awake");

        if (fun != null)
            fun.Call(table, gameObject);
    }

    //调用lua表的Awake方法（携带一个参数）
    void CallAwake(LuaTable args)
    {

        LuaFunction fun = table.GetLuaFunction("Awake");
        if (fun != null)
            fun.Call(table, gameObject, args);
    }


    private void OnEnable()
    {
       // Debug.Log("================================================================================");
        //Debug.Log(table);

        if (table == null)
        {
            //Debug.LogWarning("Table is Null---------------------");
            return;
        }

        LuaFunction fun = table.GetLuaFunction("OnEnable");


        if (fun != null)
        {
            fun.Call(table, gameObject);
        }
    }

    void Start()

    {
        LuaFunction fun = table.GetLuaFunction("Start");

        if (fun != null)

            fun.Call(table, gameObject);
    }

    void Update()
    {
        //效率问题有待测试和优化

        //可在lua中调用UpdateBeat替代

        LuaFunction fun = table.GetLuaFunction("Update");

        if (fun != null)

            fun.Call(table, gameObject);
    }


    private void FixedUpdate()
    {
        LuaFunction fun = table.GetLuaFunction("FixedUpdate");

        if (fun != null)

            fun.Call(table, gameObject);
    }

    private void LateUpdate()
    {
        LuaFunction fun = table.GetLuaFunction("LateUpdate");

        if (fun != null)

            fun.Call(table, gameObject);
    }


    void OnCollisionEnter(Collision collisionInfo)

    {

        //略

    }

    //更多函数略

    private void OnDisable()
    {
        if (table != null) {
            LuaFunction fun = table.GetLuaFunction("OnDisable");

            if (fun != null)
            {
                fun.Call(table, gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (table != null)
        {
            LuaFunction fun = table.GetLuaFunction("OnDestroy");

            if (fun != null)
            {
                fun.Call(table, gameObject);
            }
        }
    }

}