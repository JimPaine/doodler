using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace doodler.Client
{
    public class CanvasInterop
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ElementReference canvas;
        private readonly ElementReference wrapper;

        public CanvasInterop(IJSRuntime jsRuntime, ElementReference canvas, ElementReference wrapper)
        {
            this.jsRuntime = jsRuntime;
            this.canvas = canvas;
            this.wrapper = wrapper;
        }

        public async Task DrawLine(Payload payload)
        {
            await this.jsRuntime.InvokeAsync<object>(
                "canvas.drawLine", 
                this.canvas, 
                payload.PrevX,
                payload.PrevY,                
                payload.NewX,
                payload.NewY,
                payload.Color,
                payload.StrokeWidth);
        }

        public async Task<Point> GetOffset(double x, double y)
        {
            return await this.jsRuntime.InvokeAsync<Point>("canvas.getOffset", this.canvas, x, y);
        }

        public async Task SetSize()
        {
            await this.jsRuntime.InvokeAsync<Point>("canvas.setSize", this.canvas, this.wrapper);
        }

        public async Task Clear()
        {
            await this.jsRuntime.InvokeAsync<object>("canvas.clear", this.canvas);
        }
    }    
}