using System;
using JetBrains.Annotations;

namespace KlimentiyInjector
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public class InjectAttribute : Attribute { }
}