using Markdig.Parsers;
using Markdig.Syntax;
using System;

namespace OoBDev.Oobtainium.Text.Markdown;

public class PlantUmlBlock(BlockParser parser) : FencedCodeBlock(parser)
{
    public string GetScript() => string.Join(Environment.NewLine, Lines);
}
