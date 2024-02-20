using Blazor.Canvas.Components;
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

    public async Task OnKeyDown(KeyboardEventArgs args){await Task.CompletedTask;}
    public async Task OnKeyUp(KeyboardEventArgs args) {await Task.CompletedTask;}
    public async Task OnKeyPress(KeyboardEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseOver(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseOut(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseWheel(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseDown(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseUp(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnMouseMove(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnAuxClick(PointerEventArgs args) {await Task.CompletedTask;}
    public async Task OnClick(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnDoubleClick(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnBlur(FocusEventArgs args) {await Task.CompletedTask;}
    public async Task OnFocus(FocusEventArgs args) {await Task.CompletedTask;}
    public async Task OnFocusOut(FocusEventArgs args) {await Task.CompletedTask;}
    public async Task OnFocusIn(FocusEventArgs args) {await Task.CompletedTask;}
    public async Task OnScroll(EventArgs args) {await Task.CompletedTask;}
    public async Task OnScrollEnd(EventArgs args) {await Task.CompletedTask;}
    public async Task OnWheel(WheelEventArgs args) {await Task.CompletedTask;}
    public async Task OnContextMenu(MouseEventArgs args) {await Task.CompletedTask;}
    public async Task OnTouchStart(TouchEventArgs args) {await Task.CompletedTask;}
    public async Task OnTouchMove(TouchEventArgs args) {await Task.CompletedTask;}
    public async Task OnTouchEnd(TouchEventArgs args) {await Task.CompletedTask; }
    public async Task OnTouchCancel(TouchEventArgs args) {await Task.CompletedTask; }
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
        await Canvas.FillRect(20,20,160,160);
    }
    public async Task DrawLinearGradient()
    {
        var rad = new LinearGradient(110, 90, 100, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20,20,160,160);
    }
    public async Task DrawConicGradient()
    {
        var rad = new ConicGradient(110, 90, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20,20,160,160);
    }
    public async Task FillRect()
    {
        await Canvas.SetFillStyle("orange");
        await Canvas.FillRect(50,50,160,160);
    }
    public async Task StrokeRect()
    {
        await Canvas.SetStrokeStyle("purple");
        await Canvas.StrokeRect(50,50,160,160);
    }
    public async Task FillText()
    {
       // await Canvas.SetStrokeStyle("brown");
        await Canvas.SetFont("bold 48px serif");
        await Canvas.StrokeText("Hello World", 50, 100);
    }
    public async Task ToDataURL()
    {
       // await Canvas.SetStrokeStyle("brown");
        var x =await Canvas.ToDataURL();
    }
}
