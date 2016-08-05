﻿using Gtk;
using Gtk.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Gtk.Interop;
using static Gtk.Interop.gio;
using static Gtk.Interop.glib;
using static Gtk.Interop.gobj;
using static Gtk.Interop.gtk;

namespace Gtk
{
    public class Button : Widget
    {
        public unsafe Button() : base()
        {
            handle = gtk_button_new_with_label(null);

            RegisterObject();
        }

        public Button(IntPtr handle)
            : base(handle)
        {

        }

        public string Label
        {
            get
            {
                var ptr = gtk_button_get_label(handle);
                return StringHelpers.Utf8PtrToString(ptr);
            }
            set
            {
                gtk_button_set_label(handle, value);
            }
        }

        public event EventHandler<EventArgs> Clicked
        {
            add
            {
                AddSignalHandler("clicked", value, handleClicked);
            }

            remove
            {
                RemoveSignalHandler(value);
            }
        }

        private void handleClicked(IntPtr instance, IntPtr data, EventHandler<EventArgs> handler)
        {
            handler(this, new EventArgs());
        }
    }
}
