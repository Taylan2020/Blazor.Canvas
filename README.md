# Blazor.Canvas

## Installation
Package Manager
```
Install-Package Blazor.Canvas -Version 2.3
```
or .net CLI
```
dotnet add package Blazor.Canvas --version 2.3
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
<BlazorCanvas @ref="Canvas" InitialWidth="600" InitialHeight="600" Id="testCanvas" style="border: 1px solid black;"
  OnMouseDown="OnMouseDown" OnMouseUp="OnMouseUp" OnMouseMove="OnMouseMove" OnMouseOut="OnMouseOut" OnMouseOver="OnMouseOver"
              OnMouseWheel="OnMouseWheel" OnClick="OnClick" OnDoubleClick="OnDoubleClick" OnBlur="OnBlur" OnScroll="OnScroll"
              OnKeyDown="OnKeyDown" OnKeyPress="OnKeyPress" OnKeyUp="OnKeyUp" OnWheel="OnWheel" OnContextMenu="OnContextMenu"
              OnTouchStart="OnTouchStart" OnTouchMove="OnTouchMove" OnTouchEnd="OnTouchEnd" OnAuxClick="OnAuxClick"
              OnFocus="OnFocus" OnFocusIn="OnFocusIn" OnFocusOut="OnFocusOut" OnScrollEnd="OnScrollEnd" />

@code{
  using Blazor.Canvas.Components;
  using Blazor.Canvas.Models.Gradient;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Components.Web;
  using Microsoft.JSInterop;
  
  [Inject] IJSRuntime _JS { get; set; }
  private BlazorCanvas Canvas;

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
}
```
## Usage
```C#
        await Canvas.DrawImage("https://i.stack.imgur.com/UFBxY.png", 100, 100, 50, 50);
        await Canvas.SetFillStyle("orange");
        await Canvas.FillRect(50,50,160,160);
        
        var rad = new RadialGradient(110, 90, 30, 100, 100, 70, new() { new(0f, "pink"), new(0.9f, "white"), new(1f, "green") });
        await Canvas.SetFillStyle(rad);
        await Canvas.FillRect(20,20,160,160);
        
        await Canvas.SetFont("bold 48px serif");
        await Canvas.SetTextAlign(TextAlign.Center);
        await Canvas.SetStrokeStyle("red");
        await Canvas.StrokeText("Hello World", 50, 100);

        int currentWidth = Canvas.Width;
        int currentHeight = Canvas.Height;
```
### Properties  
`string? Id`

`string? Name`

`int InitialWidth`

`int InitialHeight`

`string? Style`

`string? Class`

`int TabIndex`

### Fields  
`int Width`

`int Height`

### Methods  
#### Component Methods
`Task Dispose()`

`Task Initialize()`

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
