((window) => {
    let context = null;
    let strokeColor = "black";
    let strokeWidth = 1;

    let getContext = (canvas) => {
        if (context == null) {
            context = canvas.getContext('2d');
        }
        return context;
    };

    window.canvas = {
        drawLine: (canvas, prevX, prevY, newX, newY, strokeColor, strokeWidth) => {

            let context = getContext(canvas);

            context.lineJoin = 'round';
            context.lineWidth = strokeWidth;
            context.strokeStyle = strokeColor;
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
        },

        clear: (canvas) => {
            let context = getContext(canvas);
            context.clearRect(0, 0, canvas.width, canvas.height);
        }
    };
})(window);