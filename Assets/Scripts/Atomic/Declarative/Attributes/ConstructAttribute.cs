using System;
using JetBrains.Annotations;

namespace Atomic.Declarative
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ConstructAttribute : Attribute
    {
    }
}