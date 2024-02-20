
class BlazorCanvasManager {
    /** @type {object} */
    dotNETReference = null;

    /**
     * 
     * @param {string} id
     * @param {object} dotNETReference
     */
    Initialize(id, dotNETReference) {
        this.dotNETReference = dotNETReference;
        /** @type {HTMLCanvasElement} */
        this.Canvas = document.getElementById(id);
        /** @type {CanvasRenderingContext2D} */
        this.CanvasContext = this.Canvas.getContext("2d");
    }

    /**
     * 
     * @param {string} id
     * @return {boolean}
     */
    DOMElementExists(id) {
        return !!document.getElementById(id);
    }

    /**
     * 
     * @return {boolean}
     */
    IsContextValid() {
        return !!this.CanvasContext;
    }

    /**
     * 
     * @return {object}
     */
    GetContext2D() {
        let model = {

        };

        return model;
    }

    /**
     * 
     * @returns {object}
     */
    GetCanvas() {
        let model = {
            Width: this.Canvas.width,
            Height: this.Canvas.height,
            Context: this.GetContext2D()
        };

        return model;
    }

    /**
     * 
     * @param {string} color
     */
    SetFillStyle(color) {
        this.CanvasContext.fillStyle = `${color}`;
    }

    /**
     * 
     * @param {string} url
     * @returns {Image} 
     */
    LoadImageElement(url) {
        return new Promise((resolve) => {
            const e = new Image();
            e.addEventListener("load", () => { resolve(e); });
            e.src = url;
        });
    }

    ChangeCanvasSize(width, height) {
        if (isNaN(width) === true)
            width = 150;

        if (isNaN(height) === true)
            height = 150;

        this.Canvas.width = width;
        this.Canvas.height = height;

        return [this.Canvas.width, this.Canvas.height];
    }

    /**
     * 
     * @param {string} imageURL
     * @param {number} sx
     * @param {number} sy
     * @param {number} sw
     * @param {number} sh
     * @param {number} dx
     * @param {number} dy
     * @param {number} dw
     * @param {number} dh
     * @returns
     */
    async DrawImage(imageURL, sx, sy, sw, sh, dx, dy, dw, dh) {
        let img = await this.LoadImageElement(imageURL);

        if (!arguments)
            return;

        else if (arguments.length >= 9)
            this.CanvasContext.drawImage(img, arguments[1], arguments[2], arguments[3], arguments[4], arguments[5], arguments[6], arguments[7], arguments[8]);

        else if (arguments.length >= 5)
            this.CanvasContext.drawImage(img, arguments[1], arguments[2], arguments[3], arguments[4]);

        else if (arguments.length >= 3)
            this.CanvasContext.drawImage(img, arguments[1], arguments[2]);
    }

    CreateLinearGradient(x0, y0, x1, y1, colorStops) {
        let grad = this.CanvasContext.createLinearGradient(x0, y0, x1, y1);

        if (colorStops && colorStops.length > 0) {
            colorStops.forEach(colorStop => {
                if (colorStop &&
                    isNaN(colorStop.offset) === false &&
                    colorStop.color)
                    grad.addColorStop(colorStop.offset, colorStop.color);
            });
        }

        return grad;
    }
    CreateRadialGradient(x0, y0, r0, x1, y1, r1, colorStops) {
        let grad = this.CanvasContext.createRadialGradient(x0, y0, r0, x1, y1, r1);

        if (colorStops && colorStops.length > 0) {
            colorStops.forEach(colorStop => {
                if (colorStop &&
                    isNaN(colorStop.offset) === false &&
                    colorStop.color)
                    grad.addColorStop(colorStop.offset, colorStop.color);
            });
        }

        return grad;
    }
    CreateConicGradient(startAngle, x, y, colorStops) {
        let grad = this.CanvasContext.createConicGradient(startAngle, x, y);

        if (colorStops && colorStops.length > 0) {
            colorStops.forEach(colorStop => {
                if (colorStop &&
                    isNaN(colorStop.offset) === false &&
                    colorStop.color)
                    grad.addColorStop(colorStop.offset, colorStop.color);
            });
        }

        return grad;
    }

    FillLinearGradient(x0, y0, x1, y1, colorStops) {
        let grad = this.CreateLinearGradient(x0, y0, x1, y1, colorStops);

        this.CanvasContext.fillStyle = grad;
    }
    StrokeLinearGradient(x0, y0, x1, y1, colorStops) {
        let grad = this.CreateLinearGradient(x0, y0, x1, y1, colorStops);

        this.CanvasContext.strokeStyle = grad;
    }
    FillRadialGradient(x0, y0, r0, x1, y1, r1, colorStops) {
        let grad = this.CreateRadialGradient(x0, y0, r0, x1, y1, r1, colorStops);

        this.CanvasContext.fillStyle = grad;
    }
    StrokeRadialGradient(x0, y0, r0, x1, y1, r1, colorStops) {
        let grad = this.CreateRadialGradient(x0, y0, r0, x1, y1, r1, colorStops);

        this.CanvasContext.strokeStyle = grad;
    }
    FillConicGradient(startAngle, x, y, colorStops) {
        let grad = this.CreateConicGradient(startAngle, x, y, colorStops)

        this.CanvasContext.fillStyle = grad;
    }
    StrokeConicGradient(startAngle, x, y, colorStops) {
        let grad = this.CreateConicGradient(startAngle, x, y, colorStops)

        this.CanvasContext.strokeStyle = grad;
    }
}
function GetPropertyOwner(propertyString) {

}
function SetProperty(name, value) {
    let parts = name.split(".");

    for (var i = 0, len = parts.length, obj = window; i < len-1; ++i) {
        obj = obj[parts[i]];
    }

    obj[parts[parts.length - 1]] = value;
}
/** @type {BlazorCanvasManager}*/
window.Blazor_Canvas_Manager = new BlazorCanvasManager();
window.SetProperty = SetProperty;