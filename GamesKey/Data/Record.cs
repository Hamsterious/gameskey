using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesKey.Data
{
    public class Record<TKey> : IEquatable<Record<TKey>> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object obj) => Equals(obj as Record<TKey>);
        public bool Equals(Record<TKey> other) => other != null && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        public override int GetHashCode() => 2108858624 + EqualityComparer<TKey>.Default.GetHashCode(Id);

        public static bool operator ==(Record<TKey> record1, Record<TKey> record2) => EqualityComparer<Record<TKey>>.Default.Equals(record1, record2);
        public static bool operator !=(Record<TKey> record1, Record<TKey> record2) => !(record1 == record2);
    }
}
