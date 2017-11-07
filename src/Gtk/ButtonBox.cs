﻿using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using static Interop.gio;
using static Interop.gtk;

namespace Gtk
{
    public class ButtonBox : Box
    {
        public unsafe ButtonBox() : base()
        {
            handle = gtk_button_box_new(GtkOrientation.GTK_ORIENTATION_HORIZONTAL);

            RegisterObject();
        }

        public ButtonBox(IntPtr handle)
            : base(handle)
        {

        }
    }
}
