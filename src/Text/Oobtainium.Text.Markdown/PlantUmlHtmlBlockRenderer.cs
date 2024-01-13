using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace OoBDev.Oobtainium.Text.Markdown;

public class PlantUmlHtmlBlockRenderer(MarkdownPipeline pipeline) : HtmlObjectRenderer<PlantUmlBlock>
{
    private readonly PlantUmlRenderer _renderer = new(pipeline);

    protected override void Write(HtmlRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
}
