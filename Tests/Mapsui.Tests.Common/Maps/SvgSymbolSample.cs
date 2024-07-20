using Mapsui.Layers;
using Mapsui.Samples.Common;
using Mapsui.Styles;
using Mapsui.Tiling;

using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable IDISP001 // Dispose created

namespace Mapsui.Tests.Common.Maps;

public class SvgSymbolSample : ISample
{
    public string Name => "Svg Symbol";
    public string Category => "Tests";

    public Task<Map> CreateMapAsync() => Task.FromResult(CreateMap());

    public static Map CreateMap()
    {
        var layer = new MemoryLayer
        {
            Style = null,
            Features = CreateFeatures(),
            Name = "Points with Svg"
        };

        var map = new Map
        {
            BackColor = Color.WhiteSmoke,
        };

        map.Layers.Add(OpenStreetMap.CreateTileLayer());

        map.Navigator.ZoomToBox(layer.Extent!.Grow(layer.Extent.Width * 2));

        map.Layers.Add(layer);

        return map;
    }

    public static IEnumerable<IFeature> CreateFeatures() =>
    [
        new PointFeature(new MPoint(50, 50))
        {
            Styles = [CreateSymbolStyle(Color.FromRgba(0, 128, 0, 255), Color.FromRgba(128, 0, 0, 255))]
        },
        new PointFeature(new MPoint(50, 100))
        {
            Styles = [CreateSymbolStyle(Color.FromRgba(0, 255, 0, 255), Color.FromRgba(200, 0, 0, 255))]
        },
        new PointFeature(new MPoint(100, 50))
        {
            Styles = [CreateSymbolStyle(Color.FromRgba(0, 190, 0, 255), Color.FromRgba(32, 0, 0, 255))]
        },
        new PointFeature(new MPoint(100, 100))
        {
            Styles = [CreateSymbolStyle(Color.FromRgba(0, 33, 0, 255), Color.FromRgba(190, 0, 0, 255))]
        }
    ];

    private static SymbolStyle CreateSymbolStyle(Color fillcolor, Color strokecolor) => new()
    {
        ImageSource = "embedded://mapsui.resources.images.pin5.svg",
        SvgFillColor = fillcolor,
        SvgStrokeColor = strokecolor
    };
}
