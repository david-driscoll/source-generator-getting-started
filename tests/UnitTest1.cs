using System.Runtime.CompilerServices;
using DiffEngine;
using generator;
using Microsoft.CodeAnalysis;
using Rocket.Surgery.Extensions.Testing.SourceGenerators;

namespace tests;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var builder = GeneratorTestContextBuilder.Create()
            .WithGenerator<Generator>()
            .AddSources(@"
global using System.Collections;
global using System.Collections.Generic;
")
            .AddSources(@"
public class Test { public List<int> Values { get; set; } }
");

        var generatorInstance = builder.Build();

        var result = await generatorInstance.GenerateAsync();

        await Verify(result);
    }
}

class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyGeneratorTextContext.Initialize(
            includeInputs: true,
            includeOptions: true,
            diagnosticSeverityFilter: DiagnosticSeverity.Hidden
        );
        DiffRunner.Disabled = true;
    }
}
