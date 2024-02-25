
class BlazorCanvasManager {
    /** @type {object} */
    dotNETReference = null;

    /**
     * 
     * @param {string} id
     * @param {object} dotNETReference
     */
    Initialize(id, containerId, dotNETReference) {
        this.dotNETReference = dotNETReference;
        /** @type {HTMLCanvasElement} */
        this.Canvas = document.getElementById(id);
        /** @type {HTMLDivElement} */
        this.CanvasContainer = document.getElementById(containerId);
        /** @type {CanvasRenderingContext2D} */
        this.CanvasContext = this.Canvas.getContext("2d");
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

function SerializeWindowBar(prop) {
    if (!prop)
        return null;

    if (typeof (prop.visible) === 'boolean')
        return {
            Visible: window.personalbar.visible
        };

    return null;
}

function SetProperty(name, value) {
    let parts = name.split(".");

    for (var i = 0, len = parts.length, obj = window; i < len - 1; ++i) {
        obj = obj[parts[i]];
    }

    obj[parts[parts.length - 1]] = value;
}

function GetBoundingClientRect(elem) {
    if (elem == null)
        return null;

    let boundingClientRect = elem.getBoundingClientRect();

    return {
        X: boundingClientRect.x,
        Y: boundingClientRect.y,
        Width: boundingClientRect.width,
        Height: boundingClientRect.height,
        Top: boundingClientRect.top,
        Right: boundingClientRect.right,
        Bottom: boundingClientRect.bottom,
        Left: boundingClientRect.left
    };
}
function ElementPositionSizeInformation(element) {
    if (!element)
        return null;

    return {
        BoundingClientRect: GetBoundingClientRect(element),
        ClientLeft: element.clientLeft ?? null,
        ClientTop: element.clientTop ?? null,
        ClientWidth: element.clientWidth ?? null,
        ClientHeight: element.clientHeight ?? null,
        OffsetLeft: element.offsetLeft ?? null,
        OffsetTop: element.offsetTop ?? null,
        OffsetWidth: element.offsetWidth ?? null,
        OffsetHeight: element.offsetHeight ?? null,
        ScrollLeft: element.scrollLeft ?? null,
        ScrollTop: element.scrollTop ?? null,
        ScrollWidth: element.scrollWidth ?? null,
        ScrollHeight: element.scrollHeight ?? null,
    };
}
function WindowInformation() {
    let location = null;
    let visualViewport = null;

    if (window.location) {
        location = {
            Hash: (window.location.hash ? window.location.hash.toString() : null),
            Host: (window.location.host ? window.location.host.toString() : null),
            HostName: (window.location.hostname ? window.location.hostname.toString() : null),
            Href: (window.location.href ? window.location.href.toString() : null),
            Origin: (window.location.origin ? window.location.origin.toString() : null),
            PathName: (window.location.pathname ? window.location.pathname.toString() : null),
            Port: (window.location.port ? window.location.port.toString() : null),
            Protocol: (window.location.protocol ? window.location.protocol.toString() : null),
            Search: (window.location.search ? window.location.search.toString() : null),
        };
    }

    if (window.visualViewport) {
        visualViewport = {
            Width: window.visualViewport.width ?? null,
            Height: window.visualViewport.height ?? null,
            Scale: window.visualViewport.scale ?? null,
            OffsetLeft: window.visualViewport.offsetLeft ?? null,
            OffsetTop: window.visualViewport.offsetTop ?? null,
            PageLeft: window.visualViewport.pageLeft ?? null,
            PageTop: window.visualViewport.pageTop ?? null,
        };
    }

    return {
        Closed: window.closed ?? null,
        DevicePixelRatio: window.devicePixelRatio ?? null,
        InnerWidth: window.innerWidth ?? null,
        InnerHeight: window.innerHeight ?? null,
        Length: window.length ?? null,
        Location: location,
        LocationBar: this.SerializeWindowBar(window.locationbar),
        MenuBar: this.SerializeWindowBar(window.menubar),
        Name: window.name ?? null,
        OuterWidth: window.outerWidth ?? null,
        OuterHeight: window.outerHeight ?? null,
        PersonalBar: this.SerializeWindowBar(window.personalbar),
        ScreenLeft: window.screenLeft ?? null,
        ScreenTop: window.screenTop ?? null,
        ScreenX: window.screenX ?? null,
        ScreenY: window.screenY ?? null,
        ScrollX: window.scrollX ?? null,
        ScrollY: window.scrollY ?? null,
        ScrollBars: this.SerializeWindowBar(window.scrollbars),
        StatusBar: this.SerializeWindowBar(window.statusbar),
        ToolBar: this.SerializeWindowBar(window.toolbar),
        VisualViewport: visualViewport
    };
}

window.GetViewInformation = function () {
    let infoCanvasContainer = null;
    let infoCanvas = null;

    if (window.Blazor_Canvas_Manager) {
        if (window.Blazor_Canvas_Manager.CanvasContainer)
            infoCanvasContainer = this.ElementPositionSizeInformation(window.Blazor_Canvas_Manager.CanvasContainer);

        if (window.Blazor_Canvas_Manager.Canvas)
            infoCanvas = this.ElementPositionSizeInformation(window.Blazor_Canvas_Manager.Canvas);
    }

    return {
        Canvas: infoCanvas,
        CanvasContainer: infoCanvasContainer,
        Window: this.WindowInformation(),
    };
};

window.Blazor_Canvas_Manager = new BlazorCanvasManager();
window.SetProperty = SetProperty;
window.WindowInformation = WindowInformation;