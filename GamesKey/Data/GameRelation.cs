using System;
using System.Collections.Generic;

namespace GamesKey.Data
{
    public class GameRelation : Record<int>, IEquatable<GameRelation>
    {
        public string Name { get; set; }

        public override bool Equals(object obj) => Equals(obj as GameRelation);
        public bool Equals(GameRelation other) => other != null && base.Equals(other) && Name == other.Name;

        public override int GetHashCode()
        {
            var hashCode = 266367750;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public static bool operator ==(GameRelation relation1, GameRelation relation2) => EqualityComparer<GameRelation>.Default.Equals(relation1, relation2);
        public static bool operator !=(GameRelation relation1, GameRelation relation2) => !(relation1 == relation2);
    }
}
