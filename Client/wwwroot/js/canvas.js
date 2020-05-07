((window) => {
    let context = null;

    let getContext = (canvas) => {
        if (context == null) {
            context = canvas.getContext('2d');
        }
        return context;
    };

    window.canvas = {
        drawLine: (canvas, prevX, prevY, newX, newY) => {

            let context = getContext(canvas);

            context.lineJoin = 'round';
            context.lineWidth = 1;
            context.strokeStyle = "black";
            context.beginPath();
            context.moveTo(newX, newY);
            context.lineTo(prevX, prevY);
            context.closePath();
            context.stroke();
        },

        getOffset: (current, x, y) => {   
                
              let offsetLeft = 0;
              let offsetTop = 0;            
            
              while(current != null){
                offsetLeft += current.offsetLeft;
                offsetTop += current.offsetTop;
                current = current.offsetParent;
              }
            
              return { 
                x: x - offsetLeft,
                y: y - offsetTop,
              }; 
        },

        setSize: (canvas, wrapper) => {
            canvas.width = wrapper.clientWidth;
            canvas.height = wrapper.clientHeight;
            canvas.style.width = wrapper.clientWidth;
            canvas.style.height = wrapper.clientHeight;
        }
    };
})(window);