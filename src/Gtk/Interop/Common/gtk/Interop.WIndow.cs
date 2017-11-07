﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using static Interop.Libraries;

namespace Interop
{
    internal static partial class gtk
    {
        [DllImport(Libraries.Gtk)]
        public static extern IntPtr gtk_window_new(GtkWindowType type);

        [DllImport(Libraries.Gtk)]
        public static extern IntPtr gtk_window_set_title(IntPtr window, string title);

        [DllImport(Libraries.Gtk)]
        public static extern IntPtr gtk_window_get_title(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_set_default_size(IntPtr window, int width, int height);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_resize(IntPtr window, int width, int height);

        [DllImport(Libraries.Gtk)]
        public static extern bool gtk_window_is_active(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern bool gtk_window_close(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_maximize(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_unmaximize(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_fullscreen(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_unfullscreen(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_set_modal(IntPtr window, bool modal);

        [DllImport(Libraries.Gtk)]
        public static extern bool gtk_window_get_modal(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_set_focus(IntPtr window, IntPtr focus);

        [DllImport(Libraries.Gtk)]
        public static extern IntPtr gtk_window_get_focus(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_get_size(IntPtr window, ref int width, ref int height);

        [DllImport(Libraries.Gtk)]
        public static extern bool gtk_window_is_maximized(IntPtr window);

        [DllImport(Libraries.Gtk)]
        public static extern bool gtk_window_set_position(IntPtr window, GtkWindowPosition position);

        // Exists?
        [DllImport(Libraries.Gtk)]
        public static extern void gtk_window_get_position(IntPtr widget,
         int root_x,
         int root_y);

            public enum GtkWindowPosition
        {
            GTK_WIN_POS_NONE,
            GTK_WIN_POS_CENTER,
            GTK_WIN_POS_MOUSE,
            GTK_WIN_POS_CENTER_ALWAYS,
            GTK_WIN_POS_CENTER_ON_PARENT
        }
    }
}
