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
            await jsRuntime.InvokeAsync<object>(
                "canvas.drawLine", 
                this.canvas, 
                payload.PrevX,
                payload.PrevY,                
                payload.NewX,
                payload.NewY);
        }

        public async Task<Point> GetOffset(double x, double y)
        {
            return await jsRuntime.InvokeAsync<Point>("canvas.getOffset", this.canvas, x, y);
        }

        public async Task SetSize()
        {
            await jsRuntime.InvokeAsync<Point>("canvas.setSize", this.canvas, this.wrapper);
        }
    }    
}