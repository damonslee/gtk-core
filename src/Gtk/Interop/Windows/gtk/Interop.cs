﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using static Gtk.Interop.glib;
using static Gtk.Interop.Libraries;

namespace Gtk
{
    internal static partial class Interop
    {
        internal static partial class gtk
        {
            [DllImport(Libraries.Gtk)]
            public static extern void gtk_main();

            [DllImport(Libraries.Gtk)]
            public static extern void gtk_main_quit();

            [DllImport(Libraries.Gtk)]
            public static extern void gtk_init(int argc, string[] argv);

            public enum GtkWindowType
            {
                GTK_WINDOW_TOPLEVEL,
                GTK_WINDOW_POPUP
            }

            public enum GtkOrientation
            {
                GTK_ORIENTATION_HORIZONTAL,
                GTK_ORIENTATION_VERTICAL
            }
        }
    }
}
