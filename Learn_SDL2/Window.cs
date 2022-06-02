using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.SDL2
{
    public class Window
    {
        private IntPtr _window;
        public IntPtr WindowSurface { get; private set; }
        public Window()
        {
            _window = IntPtr.Zero;
        }

        public void Init()
        {

            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0)
            {
                string log = string.Format("Could not initialize SDL: {0}", SDL.SDL_GetError());
                Console.WriteLine(log);
                throw new Exception(log);
            }

            _window = SDL.SDL_CreateWindow("SDL - Hello World", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, 1024, 768, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            
            if (_window == IntPtr.Zero)
            {
                string log = string.Format("Could not create window: {0}", SDL.SDL_GetError());
                Console.WriteLine(log);
                throw new Exception(log);
            }

            WindowSurface = SDL.SDL_GetWindowSurface(_window);
        }

        public void Close()
        {
            SDL.SDL_DestroyWindow(_window);
        }
    }
}
