using System;
using System.ComponentModel;

namespace CooperativeSystem.UI.Utilities
{
    internal static class SyncronizeInvokeExtensions
    {
        public static void InvokeExtension<T>(this T owner, Action<T> action) where T : ISynchronizeInvoke
        {
            if (owner.InvokeRequired)
                owner.Invoke(action, new object[] { owner });
            else
                action(owner);
        }
    }
}
