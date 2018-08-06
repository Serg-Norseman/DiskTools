/*
 *  "DiskTracker".
 *  Copyright (C) 2018 by Sergey V. Zhdanovskih.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace DiskTracker
{
    public static class DTHelper
    {
        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
            T result;
            if (attributes == null || attributes.Length == 0) {
                result = null;
            } else {
                result = attributes[0] as T;
            }
            return result;
        }

        public static string GetAppPath()
        {
            Assembly assembly = typeof(DTHelper).Assembly;
            Module[] mods = assembly.GetModules();
            string fn = mods[0].FullyQualifiedName;
            return Path.GetDirectoryName(fn) + Path.DirectorySeparatorChar;
        }

        public static string GetAppCopyright()
        {
            Assembly assembly = typeof(DTHelper).Assembly;
            var attr = GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly);
            return (attr == null) ? string.Empty : attr.Copyright;
        }

        public static void LoadExtFile(string fileName)
        {
            if (File.Exists(fileName)) {
                Process.Start(new ProcessStartInfo("file://"+fileName) { UseShellExecute = true });
            } else {
                Process.Start(fileName);
            }
        }

        public static Stream LoadResourceStream(string resName)
        {
            return LoadResourceStream(typeof(DTHelper), resName);
        }

        public static Stream LoadResourceStream(Type baseType, string resName)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetManifestResourceStream(resName);
        }

        public static Bitmap LoadResourceImage(Type baseType, string resName)
        {
            return new Bitmap(LoadResourceStream(baseType, resName));
        }

        public static Bitmap LoadResourceImage(string resName)
        {
            return LoadResourceImage(typeof(DTHelper), resName);
        }
    }
}
