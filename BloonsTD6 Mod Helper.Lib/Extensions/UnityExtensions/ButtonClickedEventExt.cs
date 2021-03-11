using System;
using static UnityEngine.UI.Button;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ButtonClickedEventExt
    {
        public delegate void funcDelegate();

        public static void RemovePersistantCall(this ButtonClickedEvent clickEvent, int index)
        {
            clickEvent.m_PersistentCalls.m_Calls.RemoveAt(index);
        }

        public static void RemoveAllPersistantCalls(this ButtonClickedEvent clickEvent)
        {
            clickEvent.m_PersistentCalls.Clear();
        }

        public static void AddListener(this ButtonClickedEvent clickEvent, funcDelegate funcToExecute)
        {
            clickEvent.AddListener(new Action(() => { funcToExecute(); }));
        }
    }
}
