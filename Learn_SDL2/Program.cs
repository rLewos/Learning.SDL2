using SDL2;
using System.Runtime.InteropServices;

const int xJanela = 800;
const int yJanela = 600;

IntPtr window = IntPtr.Zero;
IntPtr screenSurface = IntPtr.Zero;

SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
window = SDL.SDL_CreateWindow("SDL2 - Hello World", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, xJanela, yJanela, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
screenSurface = SDL.SDL_GetWindowSurface(window);


IntPtr imageSurface = SDL.SDL_LoadBMP("./assets/hello_world.bmp");
IntPtr convertedImage = SDL.SDL_ConvertSurface(imageSurface, Marshal.PtrToStructure<SDL.SDL_Surface>(screenSurface).format, 0);
SDL.SDL_FreeSurface(imageSurface);

bool quit = false;
SDL.SDL_Event e;

while (!quit)
{
    while (SDL.SDL_PollEvent(out e) != 0)
    {
        switch (e.type)
        {
            case SDL.SDL_EventType.SDL_QUIT:
                quit = true;
                break;

            case SDL.SDL_EventType.SDL_KEYDOWN:
                Console.WriteLine("Keyboard Digit");
                break;

            default:
                break;
        }
    }

    SDL.SDL_BlitSurface(convertedImage, IntPtr.Zero, screenSurface, IntPtr.Zero);
    SDL.SDL_UpdateWindowSurface(window);
}

SDL.SDL_FreeSurface(convertedImage); // Remove image.
convertedImage = IntPtr.Zero;

SDL.SDL_DestroyWindow(window);
window = IntPtr.Zero;

SDL.SDL_Quit();