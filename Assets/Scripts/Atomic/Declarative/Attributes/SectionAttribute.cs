using System;
using JetBrains.Annotations;

namespace Atomic.Declarative
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class SectionAttribute : Attribute
    {
    }
}