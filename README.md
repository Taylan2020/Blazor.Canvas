# Blazor.Canvas

## Installation
Package Manager
```
Install-Package Blazor.Canvas -Version 4.1
```
or .net CLI
```
dotnet add package Blazor.Canvas --version 4.1
```
### Javascript
Embed JS-file to the body section of your page
```html
<script src="Blazor.Canvas.js"></script>
```
### Razor
Add Component to your razor view using the BlazorCanvas-Tag
and initialize the library after your component has rendered.
```razor
@using Blazor.Canvas.Components

<BlazorCanvas @ref="Canvas" InitialWidth="600" InitialHeight="600" Id="testCanvas" Style="border: 1px solid black;"
              
              @bind-ContainerStyle="CustomCanvasContainerStyle" ContainerClass="myclass" ContainerId="MyContainer"

              OnContainerDrag="OnDrag" OnContainerDragStart="OnDragStart" OnContainerDragOver="OnDragOver"
              OnContainerDragEnd="OnDragEnd" OnContainerDrop="OnDrop" OnContainerDragEnter="OnDragEnter"
              OnContainerDragLeave="OnDragLeave" 
              
              OnMouseDown="OnMouseDown" OnMouseUp="OnMouseUp"
              OnMouseMove="OnMouseMove" OnMouseOut="OnMouseOut" OnMouseOver="OnMouseOver"
              OnMouseWheel="OnMouseWheel" OnClick="OnClick" OnDoubleClick="OnDoubleClick"

              OnKeyDown="OnKeyDown" OnKeyPress="OnKeyPress" OnKeyUp="OnKeyUp"

              OnBlur="OnBlur" OnScroll="OnScroll" OnWheel="OnWheel" OnContextMenu="OnContextMenu"

              OnTouchStart="OnTouchStart" OnTouchMove="OnTouchMove" OnTouchEnd="OnTouchEnd" OnAuxClick="OnAuxClick"
              OnFocus="OnFocus" OnFocusIn="OnFocusIn" OnFocusOut="OnFocusOut" OnScrollEnd="OnScrollEnd"/>

@code{
  using Blazor.Canvas.Components;
  using Blazor.Canvas.Models.Gradient;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Components.Web;
  using Microsoft.JSInterop;
  
  [Inject] IJSRuntime _JS { get; set; }
  private BlazorCanvas Canvas;
  
[Parameter] public string CustomCanvasContainerStyle { get; set; } = "border: 1px solid red;";

  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
      if (firstRender)
      {
          await Canvas.Initialize(_JS);
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
  public async Task OnDrag(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDragEnd(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDragEnter(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDragLeave(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDragOver(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDragStart(DragEventArgs args) { await Task.CompletedTask; }
  public async Task OnDrop(DragEventArgs args) { await Task.CompletedTask; }
}
```
## Usage
```C#
        await Canvas.DrawImage("https://i.stack.imgur.com/UFBxY.png", 100, 100, 50, 50);

        await Canvas.SetFillStyle("orange");
        await Canvas.FillRect(50,50,160,160);
        
        var lin = new LinearGradient(110, 90, 100, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(lin);
        await Canvas.FillRect(20, 20, 160, 160);

        var rad = new RadialGradient(110, 90, 30, 100, 100, 70, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20,20,160,160);
        
        var con = new ConicGradient(110, 90, 100, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(con);
        await Canvas.FillRect(20, 20, 160, 160);

        await Canvas.SetFont("bold 48px serif");
        await Canvas.SetTextAlign(TextAlign.Center);
        await Canvas.SetStrokeStyle("red");
        await Canvas.StrokeText("Hello World", 50, 100);
        
        var myCanvasImage = await Canvas.ToDataURL();

        int currentWidth = Canvas.Width;
        int currentHeight = Canvas.Height;

        var viewInfos = await Canvas.GetViewInformation();
        if (viewInfos == null)
            return;

        if (viewInfos.Canvas != null){
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

        if (viewInfos.CanvasContainer != null){
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

        
        if (viewInfos.Window != null){
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
```
### Properties  
#### Canvas Properties
`string? Id`

`string? Name`

`int InitialWidth`

`int InitialHeight`

`string? Style`

`string? Class`

`int TabIndex`

#### Canvas Container Properties
`string? ContainerId`

`string? ContainerName`

`string? ContainerClass`

`int ContainerWidth`

`int ContainerHeight`

`string? ContainerStyle`

`string? ContainerClass`


### Fields  
`int Width`

`int Height`

### Methods  
#### Component Methods
`Task Dispose()`

`Task Initialize()`

#### Common Methods
`public async Task<ViewInformation> GetViewInformation()`

#### Window Methods 
`public async Task GetWindow()`

#### CanvasElement Methods 
`public async Task ChangeCanvasWidth(int width)`

`public async Task ChangeCanvasHeight(int height)`

`public async Task ChangeCanvasSize(int height, int width)`

`public async Task<string> ToDataURL()`

`public async Task<string> ToDataURL(string type = "image/png")`

`public async Task<string> ToDataURL(string type = "image/png", float encoderOptions = 1.0f)`

`public async Task<DOMRect> GetBoundingClientRect()`


#### CanvasRenderingContext2D Methods 
`Task Arc(int x, int y, decimal radius, int startAngle, int endAngle, bool counterClockWise = false)`

`Task ArcTo(int x1, int y1, int x2, int y2, decimal radius)`

`Task BeginPath()`

`Task BezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, int x, int y)`

`Task Task ClearRect(int x, int y, int width, int height)`

`Task ClosePath()`

`Task CreateConicGradient(int startAngle, int x, int y)`

`Task CreateLinearGradient(int x0, int y0, int x1, int y1)()`

`Task DrawImage(string staticImageUrl, int dx, int dy)`

`Task DrawImage(string staticImageUrl, int dx, int dy, int dWidth, int dHeight)`

`Task DrawImage(string staticImageUrl, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight)`

`Task Ellipse(int x, int y, int radiusX, int radiusY, int rotation, int startAngle, int endAngle, bool counterClockWise = false)`

`Task Fill()`

`Task FillRect(int x, int y, int width, int height)`

`Task FillText(string? text, int x, int y, int maxWidth)`

`Task FillText(string? text, int x, int y)`

`Task IsContextLost()`

`Task IsPointInStroke(int x, int y)`

`Task LineTo(int x, int y)`

`Task MeasureText(string? text)`

`Task MoveTo(int x, int y)`

`Task QuadraticCurveTo(int cpx, int cpy, int x, int y)`

`Task Rect(int x, int y, int width, int height)`

`Task Reset()`

`Task ResetTransform()`

`Task Restore()`

`Task Rotate(int angle)`

`Task RoundRect(int x, int y, int width, int height, int[] radii)`

`Task Save()`

`Task Scale(int x, int y)`

`Task ScrollPathIntoView()`

`Task SetLineDash(int[] segments)`

`Task SetTransform(float a, float b, float c, float d, float e, float f)`

`Task Stroke()`

`Task StrokeRect(int x, int y, int width, int height)`

`Task StrokeText(string text, int x, int y, int maxWidth)`

`Task StrokeText(string text, int x, int y)`

`Task Transform(float a, float b, float c, float d, float e, float f)`

`Task Translate(int x, int y)`

#### CanvasRenderingContext2D Property Setters
`Task SetFillStyle(string? fillStyle)`

`Task SetFillStyle(LinearGradient filter)`

`Task SetFillStyle(RadialGradient filter)`

`Task SetFillStyle(ConicGradient filter)`

`Task SetFilter(Blur filter)`

`Task SetFont(string font)`

`Task SetFont(string font)`

`Task SetFontStretch(FontStretch fontStretch)`

`Task SetFontVariationCap(FontVariationCap fontVariationCap)`

`Task SetGlobalAlpha(float globalAlpha)`

`Task SetImageSmoothingEnabled(bool imageSmoothingEnabled)`

`Task SetImageSmoothingQuality(ImageSmoothingQuality imageSmoothingQuality)`

`Task SetLetterSpacing(int letterSpacing)`

`Task SetLineCap(LineCap lineCap)`

`Task SetLineDashOffset(float lineDashOffset)`

`Task SetLineJoin(LineJoin lineJoin)`

`Task SetLineWidth(float lineWidth)`

`Task SetMiterLimit(float miterLimit)`

`Task SetShadowOffsetX(int shadowOffsetX)`

`Task SetShadowOffsetY(int shadowOffsetY)`

`Task SetShadowBlur(int shadowBlur)`

`Task SetShadowColor(string color)`

`Task SetStrokeStyle(LinearGradient filter)`

`Task SetStrokeStyle(RadialGradient filter)`

`Task SetStrokeStyle(ConicGradient filter)`

`Task SetStrokeStyle(string strokeStyle)`

`Task SetTextAlign(TextAlign textAlign)`

`Task SetTextBaseline(TextBaseline textBaseline)`

`Task SetTextDirection(TextDirection textDirection)`

`Task SetWordSpacing(int wordSpacing)`
