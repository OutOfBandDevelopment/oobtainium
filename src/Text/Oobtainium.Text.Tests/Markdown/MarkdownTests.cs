using Markdig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OoBDev.Oobtainium.TestUtilities;
using OoBDev.Oobtainium.Text.Markdown;
using System.IO;
using _Markdown = Markdig.Markdown;

namespace OoBDev.Oobtainium.Text.Tests.Markdown;

[TestClass]
public class MarkdownTests
{
    [TestMethod, TestCategory(TestCategories.DevLocal)]
    public void TestMethod1()
    {
        var filePath = "Design.md";
        var markdownText = File.ReadAllText(filePath);

        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UsePlantuml()
            .Build()
            ;

        var markdown = _Markdown.Normalize(markdownText, new Markdig.Renderers.Normalize.NormalizeOptions
        {
            EmptyLineAfterCodeBlock = true,
            EmptyLineAfterHeading = true,
            EmptyLineAfterThematicBreak = true,
            ExpandAutoLinks = true,
            ListItemCharacter = '-',
            SpaceAfterQuoteBlock = true,
        }, pipeline);
        File.WriteAllText(filePath + ".md", markdown);

        var plainText = _Markdown.ToPlainText(markdownText, pipeline);
        File.WriteAllText(filePath + ".txt", plainText);

        //visitor commonmark + plantuml to github mark + plantuml images
        var html = _Markdown.ToHtml(markdownText, pipeline);
        File.WriteAllText(filePath + ".html", html);
    }
}
