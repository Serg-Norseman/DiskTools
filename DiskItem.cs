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

using System.Drawing;

namespace DiskTracker
{
    /// <summary>
    /// 
    /// </summary>
    public class DiskItem
    {
        public readonly string Caption;
        public readonly object Tag;
        public readonly Image Image;

        public DiskItem(string caption)
        {
            Caption = caption;
        }

        public DiskItem(string caption, object tag)
        {
            Caption = caption;
            Tag = tag;
        }

        public DiskItem(string caption, object tag, Image image)
        {
            Caption = caption;
            Tag = tag;
            Image = image;
        }

        public override string ToString()
        {
            return Caption;
        }
    }
}
