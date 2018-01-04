using GamesKey.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GamesKey.ViewModels
{
    public class ViewModel<TEntity> : IEquatable<ViewModel<TEntity>> where TEntity : Record<int>, new()
    {
        protected TEntity _model;
        [JsonIgnore]
        public TEntity Model { get => _model; }
        public int Id { get => _model.Id; }

        public ViewModel(TEntity model = default(TEntity))
        {
            _model = model ?? new TEntity();
        }

        public override bool Equals(object obj) => Equals(obj as ViewModel<TEntity>);
        public bool Equals(ViewModel<TEntity> other) => other != null && EqualityComparer<TEntity>.Default.Equals(_model, other._model);
        public override int GetHashCode() => 1004856531 + EqualityComparer<TEntity>.Default.GetHashCode(_model);

        public static bool operator ==(ViewModel<TEntity> model1, ViewModel<TEntity> model2) => EqualityComparer<ViewModel<TEntity>>.Default.Equals(model1, model2);
        public static bool operator !=(ViewModel<TEntity> model1, ViewModel<TEntity> model2) => !(model1 == model2);
    }
}
