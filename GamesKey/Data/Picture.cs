using System;
using System.Collections.Generic;

namespace GamesKey.Data
{
    public class Picture : Record<int>, IEquatable<Picture>
    {
        public byte[] File { get; set; }

        public override bool Equals(object obj) => Equals(obj as Picture);
        public bool Equals(Picture other) => other != null && base.Equals(other) && EqualityComparer<byte[]>.Default.Equals(File, other.File);

        public override int GetHashCode()
        {
            var hashCode = 723007075;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(File);
            return hashCode;
        }

        public static bool operator ==(Picture picture1, Picture picture2) => EqualityComparer<Picture>.Default.Equals(picture1, picture2);
        public static bool operator !=(Picture picture1, Picture picture2) => !(picture1 == picture2);
    }
}
