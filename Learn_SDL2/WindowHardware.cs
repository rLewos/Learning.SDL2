using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.SDL2
{
        public class WindowHardware
        {
                private IntPtr _window;
                public IntPtr Renderer { get; private set; }

                private int _width;
                private int _height;

                public WindowHardware(int windowWidth, int windowHeight)
                {
                        _window = IntPtr.Zero;
                        this.Renderer = IntPtr.Zero;

                        _width = windowWidth;
                        _height = windowHeight;
                }

                public void Init()
                {
                        int IsInitialized = SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
                        if (IsInitialized != 0)
                        {
                                string error = String.Format("Could not initialize SDL: {0}", SDL.SDL_GetError());
                                Console.WriteLine(error);
                                throw new Exception(error);
                        }

                        _window = SDL.SDL_CreateWindow("SDL Window Hardware", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, this._width, this._height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
                        if (_window == IntPtr.Zero)
                        {
                                string error = String.Format("Could not initialize SDL Window: {0}", SDL.SDL_GetError());
                                Console.WriteLine(error);
                                throw new Exception(error);
                        }

                        this.Renderer = SDL.SDL_CreateRenderer(_window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
                        if (this.Renderer == IntPtr.Zero)
                        {
                                string error = String.Format("Could not initialize SDL Renderer: {0}", SDL.SDL_GetError());
                                Console.WriteLine(error);
                                throw new Exception(error);
                        }

                        SDL.SDL_SetRenderDrawColor(this.Renderer, 0xFF, 0xFF, 0xFF, 0xFF);
                }

                public void Destroy()
                {
                        SDL.SDL_DestroyRenderer(this.Renderer);
                        SDL.SDL_DestroyWindow(this._window);
                }
        }
}
