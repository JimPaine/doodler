using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace doodler.Client
{
    public class Canvas2DContext
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ElementReference canvasReference;

        public Canvas2DContext(IJSRuntime jsRuntime, ElementReference canvasReference)
        {
            this.jsRuntime = jsRuntime;
            this.canvasReference = canvasReference;
        }

        public async Task DrawLine(Payload payload)
        {
            await jsRuntime.InvokeAsync<object>(
                "__blazorCanvasInterop.drawLine", 
                canvasReference, 
                payload.StartX,
                payload.StartY,
                payload.EndX,
                payload.EndY);
        }

        public async Task SetStrokeStyleAsync(string strokeStyle)
        {
            await jsRuntime.InvokeAsync<object>("__blazorCanvasInterop.setContextPropertyValue", canvasReference, "strokeStyle", strokeStyle);
        }
    }    
}