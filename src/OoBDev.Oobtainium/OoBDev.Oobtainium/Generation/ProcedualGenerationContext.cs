using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class ProcedualGenerationContext : IProcedualGenerationContext
    {
        protected readonly List<IProcedualGenerationContext> _children = new List<IProcedualGenerationContext>();

        public ProcedualGenerationContext(
            int seed,
            Type targetType,
            object relation,
            IEnumerable<Attribute> attributes,
            IProcedualGenerationContext? parent,
            IProcedualGenerationProvider provider
            )
        {
            Seed = seed;
            Random = new Random(seed);
            TargetType = targetType;
            Relation = relation;

            Provider = provider;

            Attributes = attributes ?? Enumerable.Empty<Attribute>();

            Parent = parent;
            if (parent is ProcedualGenerationContext same) same._children.Add(this);
        }

        public int Seed { get; }
        public Random Random { get; private set; }
        public Type TargetType { get; }
        public IEnumerable<Attribute> Attributes { get; }
        public IProcedualGenerationContext? Parent { get; }
        public IProcedualGenerationProvider Provider { get; }
        public object Relation { get; }
        public IEnumerable<IProcedualGenerationContext> Children => _children.AsReadOnly();

        public override int GetHashCode() => HashCode.Combine(Seed, TargetType, Parent);
    }
}
