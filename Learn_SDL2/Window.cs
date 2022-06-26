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
                private int xSizeWindow = 0;
                private int ySizeWindow = 0;

                public Window(int xSize, int ySize)
                {
                        _window = IntPtr.Zero;
                        xSizeWindow = xSize;
                        ySizeWindow = ySize;
                }

                public void Init()
                {
                        int IsInitialized = SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
                        if (IsInitialized != 0)
                        {
                                string log = string.Format("Could not initialize SDL: {0}", SDL.SDL_GetError());
                                Console.WriteLine(log);
                                throw new Exception(log);
                        }

                        _window = SDL.SDL_CreateWindow("SDL - Hello World", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, xSizeWindow, ySizeWindow, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
                        if (_window == IntPtr.Zero)
                        {
                                string log = string.Format("Could not create window: {0}", SDL.SDL_GetError());
                                Console.WriteLine(log);
                                throw new Exception(log);
                        }

                        WindowSurface = SDL.SDL_GetWindowSurface(_window);
                        if (WindowSurface == IntPtr.Zero)
                        {
                                string log = string.Format("Could not create WindowSurface: {0}", SDL.SDL_GetError());
                                Console.WriteLine(log);
                                throw new Exception(log);
                        }
                }

                /// <summary>
                ///  Update screen.
                /// </summary>
                public void Update()
                {
                        SDL.SDL_UpdateWindowSurface(_window);
                }

                /// <summary>
                /// Draw on backbuffer.
                /// </summary>
                /// <param name="surface">Surface to be drawn on the backbuffer</param>
                public void Draw(IntPtr surface)
                {
                        SDL.SDL_BlitSurface(surface, IntPtr.Zero, WindowSurface, IntPtr.Zero);
                }

                public void Close()
                {
                        SDL.SDL_DestroyWindow(_window);
                        _window = IntPtr.Zero;
                }
        }
}
