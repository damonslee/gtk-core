﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Gtk.Interop.gobj;

namespace Gtk.Internal
{
    /// <summary>
    /// Base class for all GObject. 
    /// This class should not be derived from outside of this library. 
    /// Constructors have been marked as internal.
    /// </summary>
    public abstract class GObject
    {
        protected IntPtr handle;

        private Dictionary<object, uint> signalHandlerMap;

        private delegate void SignalHandlerDelegate(IntPtr arg1, IntPtr arg2, IntPtr arg3);

        internal GObject()
        {
            this.signalHandlerMap = new Dictionary<object, uint>();
        }

        internal GObject(IntPtr handle) : this()
        {
            this.handle = handle;

            RegisterObject();
        }

        public string GObjectType
        {
            get
            {
                var gType = Interop.gobj.g_object_get_type(handle);
                var ptr = Interop.gobj.g_type_name(gType);
                return StringHelpers.Utf8PtrToString(ptr);
            }
        }

        /// <summary>
        /// Registers an object to the ObjectManager.
        /// </summary>
        internal void RegisterObject()
        {
            ObjectManager.Register(handle, this);
        }

        /// <summary>
        /// Registers a signal handler. 
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="name"></param>
        /// <param name="eventHandler"></param>
        /// <param name="process"></param>
        internal void AddSignalHandler<TEventArgs>(string name, EventHandler<TEventArgs> eventHandler, Action<IntPtr, IntPtr, IntPtr, EventHandler<TEventArgs>> process = null)
             where TEventArgs : EventArgs
        {
           var handlerId = g_signal_connect_data(handle, name, WrapEventHandler(this, eventHandler, process), IntPtr.Zero, null, GConnectFlags.G_CONNECT_AFTER);

            signalHandlerMap.Add(eventHandler, handlerId);
        }

        internal void RemoveSignalHandler<TEventArgs>(EventHandler<TEventArgs> eventHandler)
             where TEventArgs : EventArgs
        {
            var handlerId = signalHandlerMap[eventHandler];

            signalHandlerMap.Remove(eventHandler);

            g_signal_handler_disconnect(Handle, handlerId);
        }

        private static IntPtr WrapEventHandler<TEventArgs>(object instance, EventHandler<TEventArgs> eventHandler, Action<IntPtr, IntPtr, IntPtr, EventHandler<TEventArgs>> process)
            where TEventArgs : EventArgs
        {
            var ptr = Marshal.GetFunctionPointerForDelegate<SignalHandlerDelegate>((a, b, c) => {
                if (process != null)
                {
                    process(a, b, c, eventHandler);
                }
                else
                {
                    eventHandler(instance, Activator.CreateInstance<TEventArgs>());
                }
            });
            return ptr;
        }

        public unsafe IntPtr Handle
        {
            get
            {
                return handle;
            }
        }

        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        ~GObject()
        {
            ObjectManager.Unregister(handle);
        }
    }
}