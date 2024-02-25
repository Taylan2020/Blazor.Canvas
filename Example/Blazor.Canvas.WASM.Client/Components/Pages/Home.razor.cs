using Blazor.Canvas.Components;
using Blazor.Canvas.Models;
using Blazor.Canvas.Models.DOM;
using Blazor.Canvas.Models.Gradient;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blazor.Canvas.WASM.Client.Components.Pages;

public partial class Home
{
    [Inject] IJSRuntime _JS { get; set; }
    private BlazorCanvas Canvas;
    bool IsButtonDisabled = true;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Canvas.Initialize(_JS);
            IsButtonDisabled = false;
            StateHasChanged();
        }

        await base.OnAfterRenderAsync(firstRender);
    }
    [Parameter] public string CustomCanvasContainerStyle { get; set; } = "border: 1px solid red;";
    public async Task OnKeyDown(KeyboardEventArgs args) { await Task.CompletedTask; }
    public async Task OnKeyUp(KeyboardEventArgs args) { await Task.CompletedTask; }
    public async Task OnKeyPress(KeyboardEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseOver(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseOut(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseWheel(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseDown(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseUp(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnMouseMove(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnAuxClick(PointerEventArgs args) { await Task.CompletedTask; }
    public async Task OnClick(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnDoubleClick(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnBlur(FocusEventArgs args) { await Task.CompletedTask; }
    public async Task OnFocus(FocusEventArgs args) { await Task.CompletedTask; }
    public async Task OnFocusOut(FocusEventArgs args) { await Task.CompletedTask; }
    public async Task OnFocusIn(FocusEventArgs args) { await Task.CompletedTask; }
    public async Task OnScroll(EventArgs args) { await Task.CompletedTask; }
    public async Task OnScrollEnd(EventArgs args) { await Task.CompletedTask; }
    public async Task OnWheel(WheelEventArgs args) { await Task.CompletedTask; }
    public async Task OnContextMenu(MouseEventArgs args) { await Task.CompletedTask; }
    public async Task OnTouchStart(TouchEventArgs args) { await Task.CompletedTask; }
    public async Task OnTouchMove(TouchEventArgs args) { await Task.CompletedTask; }
    public async Task OnTouchEnd(TouchEventArgs args) { await Task.CompletedTask; }
    public async Task OnTouchCancel(TouchEventArgs args) { await Task.CompletedTask; }
    public async Task DrawRect()
    {
        await Canvas.SetFillStyle("blue");
        await Canvas.Rect(0, 100, 50, 50);
        await Canvas.FillRect(0, 100, 100, 100);
    }
    public async Task Clear()
    {
        await Canvas.ClearRect(0, 0, 600, 600);
    }
    public async Task DrawImage()
    {
        await Canvas.DrawImage("https://i.stack.imgur.com/UFBxY.png", 100, 100, 50, 50);
    }
    public async Task DrawRadialGradient()
    {
        var rad = new RadialGradient(110, 90, 30, 100, 100, 70, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20, 20, 160, 160);
    }
    public async Task DrawLinearGradient()
    {
        var rad = new LinearGradient(110, 90, 100, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20, 20, 160, 160);
    }
    public async Task DrawConicGradient()
    {
        var rad = new ConicGradient(110, 90, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20, 20, 160, 160);
    }
    public async Task FillRect()
    {
        await Canvas.SetFillStyle("orange");
        await Canvas.FillRect(50, 50, 160, 160);
    }
    public async Task StrokeRect()
    {
        await Canvas.SetStrokeStyle("purple");
        await Canvas.StrokeRect(50, 50, 160, 160);
    }
    public async Task FillText()
    {
        // await Canvas.SetStrokeStyle("brown");
        await Canvas.SetTextAlign(TextAlign.Center);
        await Canvas.SetFont("bold 48px serif");
        await Canvas.SetStrokeStyle("red");
        await Canvas.StrokeText("Hello World", 50, 100);
    }
    public async Task ToDataURL()
    {
        // await Canvas.SetStrokeStyle("brown");
        var x = await Canvas.ToDataURL();
    }

    public async Task GetCanvasInformation()
    {
        var viewInfos = await Canvas.GetViewInformation();
        if (viewInfos == null)
            return;
        if (viewInfos.Canvas == null)
            return;

        Console.WriteLine($"canvas.getBoundingClientRect().Right={viewInfos.Canvas.BoundingClientRect?.Right}");
        Console.WriteLine($"canvas.getBoundingClientRect().Left={viewInfos.Canvas.BoundingClientRect?.Left}");
        Console.WriteLine($"canvas.getBoundingClientRect().X={viewInfos.Canvas.BoundingClientRect?.X}");
        Console.WriteLine($"canvas.getBoundingClientRect().Y={viewInfos.Canvas.BoundingClientRect?.Y}");

        Console.WriteLine($"canvas.getBoundingClientRect().Width={viewInfos.Canvas.BoundingClientRect?.Width}");
        Console.WriteLine($"canvas.getBoundingClientRect().Height={viewInfos.Canvas.BoundingClientRect?.Height}");
        Console.WriteLine($"canvas.getBoundingClientRect().Top={viewInfos.Canvas.BoundingClientRect?.Top}");
        Console.WriteLine($"canvas.getBoundingClientRect().Bottom={viewInfos.Canvas.BoundingClientRect?.Bottom}");

        Console.WriteLine($"canvas.getBoundingClientRect().OffsetTop={viewInfos.Canvas.OffsetTop}");
        Console.WriteLine($"canvas.getBoundingClientRect().OffsetLeft={viewInfos.Canvas.OffsetLeft}");
        Console.WriteLine($"canvas.getBoundingClientRect().OffsetWidth={viewInfos.Canvas.OffsetWidth}");
        Console.WriteLine($"canvas.getBoundingClientRect().OffsetHeight={viewInfos.Canvas.OffsetHeight}");

        Console.WriteLine($"canvas.getBoundingClientRect().ClientTop={viewInfos.Canvas.ClientTop}");
        Console.WriteLine($"canvas.getBoundingClientRect().ClientLeft={viewInfos.Canvas.ClientLeft}");
        Console.WriteLine($"canvas.getBoundingClientRect().ClientWidth={viewInfos.Canvas.ClientWidth}");
        Console.WriteLine($"canvas.getBoundingClientRect().ClientHeight={viewInfos.Canvas.ClientHeight}");

        Console.WriteLine($"canvas.getBoundingClientRect().ScrollTop={viewInfos.Canvas.ScrollTop}");
        Console.WriteLine($"canvas.getBoundingClientRect().ScrollLeft={viewInfos.Canvas.ScrollLeft}");
        Console.WriteLine($"canvas.getBoundingClientRect().ScrollWidth={viewInfos.Canvas.ScrollWidth}");
        Console.WriteLine($"canvas.getBoundingClientRect().ScrollHeight={viewInfos.Canvas.ScrollHeight}");
    }
    public async Task GetCanvasContainerInformation()
    {
        var viewInfos = await Canvas.GetViewInformation();
        if (viewInfos == null)
            return;

        if (viewInfos.CanvasContainer == null)
            return;

        Console.WriteLine($"canvasContainer.getBoundingClientRect().Right={viewInfos.CanvasContainer.BoundingClientRect?.Right}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().Left={viewInfos.CanvasContainer.BoundingClientRect?.Left}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().X={viewInfos.CanvasContainer.BoundingClientRect?.X}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().Y={viewInfos.CanvasContainer.BoundingClientRect?.Y}");

        Console.WriteLine($"canvasContainer.getBoundingClientRect().Width={viewInfos.CanvasContainer.BoundingClientRect?.Width}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().Height={viewInfos.CanvasContainer.BoundingClientRect?.Height}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().Top={viewInfos.CanvasContainer.BoundingClientRect?.Top}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().Bottom={viewInfos.CanvasContainer.BoundingClientRect?.Bottom}");

        Console.WriteLine($"canvasContainer.getBoundingClientRect().OffsetTop={viewInfos.CanvasContainer.OffsetTop}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().OffsetLeft={viewInfos.CanvasContainer.OffsetLeft}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().OffsetWidth={viewInfos.CanvasContainer.OffsetWidth}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().OffsetHeight={viewInfos.CanvasContainer.OffsetHeight}");

        Console.WriteLine($"canvasContainer.getBoundingClientRect().ClientTop={viewInfos.Canvas?.ClientTop}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ClientLeft={viewInfos.Canvas?.ClientLeft}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ClientWidth={viewInfos.Canvas?.ClientWidth}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ClientHeight={viewInfos.Canvas?.ClientHeight}");

        Console.WriteLine($"canvasContainer.getBoundingClientRect().ScrollTop={viewInfos.CanvasContainer.ScrollTop}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ScrollLeft={viewInfos.CanvasContainer.ScrollLeft}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ScrollWidth={viewInfos.CanvasContainer.ScrollWidth}");
        Console.WriteLine($"canvasContainer.getBoundingClientRect().ScrollHeight={viewInfos.CanvasContainer.ScrollHeight}");
    }

    public async Task GetWindowInformation()
    {
        var viewInfos = await Canvas.GetViewInformation();
        if (viewInfos == null)
            return;

        if (viewInfos.Window == null)
            return;

        Console.WriteLine($"window.Name={viewInfos.Window.Name}");
        Console.WriteLine($"window.Closed={viewInfos.Window.Closed}");
        Console.WriteLine($"window.Length={viewInfos.Window.Length}");
        Console.WriteLine($"window.DevicePixelRatio={viewInfos.Window.DevicePixelRatio}");

        if (viewInfos.Window.Location != null)
        {
            Console.WriteLine($"window.Location.Host={viewInfos.Window.Location.Host}");
            Console.WriteLine($"window.Location.HostName={viewInfos.Window.Location.HostName}");
            Console.WriteLine($"window.Location.Port={viewInfos.Window.Location.Port}");
            Console.WriteLine($"window.Location.Search={viewInfos.Window.Location.Search}");
            Console.WriteLine($"window.Location.PathName={viewInfos.Window.Location.PathName}");
        }

        Console.WriteLine($"window.InnerHeight={viewInfos.Window.InnerHeight}");
        Console.WriteLine($"window.InnerHeight={viewInfos.Window.InnerHeight}");
        Console.WriteLine($"window.OuterWidth={viewInfos.Window.OuterWidth}");
        Console.WriteLine($"window.OuterHeight={viewInfos.Window.OuterHeight}");

        Console.WriteLine($"window.ScreenTop={viewInfos.Window.ScreenTop}");
        Console.WriteLine($"window.ScreenLeft={viewInfos.Window.ScreenLeft}");
        Console.WriteLine($"window.ScreenX={viewInfos.Window.ScreenX}");
        Console.WriteLine($"window.ScreenY={viewInfos.Window.ScreenY}");

        Console.WriteLine($"window.ScrollX={viewInfos.Window.ScrollX}");
        Console.WriteLine($"window.ScrollY={viewInfos.Window.ScrollY}");

        Console.WriteLine($"window.LocationBar.Visible={viewInfos.Window.LocationBar?.Visible}");
        Console.WriteLine($"window.Menubar.Visible={viewInfos.Window.Menubar?.Visible}");
        Console.WriteLine($"window.PersonalBar.Visible={viewInfos.Window.PersonalBar?.Visible}");
        Console.WriteLine($"window.ScrollBars.Visible={viewInfos.Window.ScrollBars?.Visible}");
        Console.WriteLine($"window.ToolBar.Visible={viewInfos.Window.ToolBar?.Visible}");

        if(viewInfos.Window.VisualViewport != null)
        {
            Console.WriteLine($"window.VisualViewport.Width={viewInfos.Window.VisualViewport.Width}");
            Console.WriteLine($"window.VisualViewport.Height={viewInfos.Window.VisualViewport.Height}");
            Console.WriteLine($"window.VisualViewport.Scale={viewInfos.Window.VisualViewport.Scale}");
            Console.WriteLine($"window.VisualViewport.PageTop={viewInfos.Window.VisualViewport.PageTop}");
            Console.WriteLine($"window.VisualViewport.PageLeft={viewInfos.Window.VisualViewport.PageLeft}");
            Console.WriteLine($"window.VisualViewport.OffsetTop={viewInfos.Window.VisualViewport.OffsetTop}");
            Console.WriteLine($"window.VisualViewport.OffsetLeft={viewInfos.Window.VisualViewport.OffsetLeft}");
        }
    }
    public async Task GetWindow()
    {
        var windowInfo = await Canvas.GetWindow(_JS);
        Console.WriteLine(windowInfo?.Name);
    }
    public void GiveParentBlueBorder()
    {
        CustomCanvasContainerStyle = "border: 1px solid blue";
        StateHasChanged();
    }
}
