using System;
using JetBrains.Annotations;

namespace KlimentiyInjector
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceAttribute : Attribute { }
}