using SDL2;
using System.Runtime.InteropServices;

const int xWindow = 800;
const int yWindow = 600;

try
{
    Learn.SDL2.Window window = new Learn.SDL2.Window(xWindow, yWindow);
    window.Init();

    IntPtr screenSurface = window.WindowSurface;
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

                    switch (e.key.keysym.sym)
                    {
                        case SDL.SDL_Keycode.SDLK_UP:
                            Console.WriteLine("UP");
                            break;

                        case SDL.SDL_Keycode.SDLK_DOWN:
                            Console.WriteLine("DOWN");
                            break;

                        case SDL.SDL_Keycode.SDLK_LEFT:
                            Console.WriteLine("LEFT");
                            break;

                        case SDL.SDL_Keycode.SDLK_RIGHT:
                            Console.WriteLine("RIGHT");
                            break;

                        case SDL.SDL_Keycode.SDLK_q:
                            quit = true;
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    break;
            }
        }

        window.Draw(convertedImage);
        window.Update();
    }

    SDL.SDL_FreeSurface(convertedImage); // Remove image.
    convertedImage = IntPtr.Zero;

    window.Close();
    SDL.SDL_Quit();
}
catch (Exception e)
{

    throw e;
}