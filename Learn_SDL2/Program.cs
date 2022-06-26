using Learn.SDL2;
using SDL2;

const int xWindow = 800;
const int yWindow = 600;

try
{
        WindowHardware windowHardware = new WindowHardware(xWindow, yWindow);
        windowHardware.Init();

        
        // Initializing PNG loading module...
        SDL_image.IMG_InitFlags pngFlag = SDL_image.IMG_InitFlags.IMG_INIT_PNG;
        int imgInit = SDL_image.IMG_Init(pngFlag);

        bool b = !Convert.ToBoolean(imgInit & (int)pngFlag);
        if (!b)
        {
                Console.WriteLine(String.Format("SDL Image couldn't initialize:"));
        }

        IntPtr pngSurface = SDL_image.IMG_Load("texture.png");
        if (pngSurface == IntPtr.Zero)
        {
                Console.WriteLine(String.Format("SDL Image couldn't load."));
                throw new Exception("Could not load image.");
        }

        IntPtr texture = SDL.SDL_CreateTextureFromSurface(windowHardware.Renderer, pngSurface);
        SDL.SDL_FreeSurface(pngSurface);




        bool quit = false;
        SDL.SDL_Event e;

        while (!quit) // Game loop
        {
                while (SDL.SDL_PollEvent(out e) != 0) // Event loop
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
        }

        SDL.SDL_DestroyTexture(texture);
        windowHardware.Destroy();
        SDL.SDL_Quit();
}
catch (Exception e)
{

        
}