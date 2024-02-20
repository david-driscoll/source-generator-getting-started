using Microsoft.CodeAnalysis;

namespace generator;

[Generator]
public class Generator : IIncrementalGenerator //, ISourceGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // do generator things
        context.RegisterPostInitializationOutput(initializationContext => initializationContext.AddSource("StaticFile", "public class StaticClass { public List<int> Values { get; set; } }"));
    }
}
