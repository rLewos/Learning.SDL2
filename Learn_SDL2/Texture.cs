using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.SDL2
{
        public class Texture
        {
                private IntPtr _texture;

                private Texture() 
                { 
                        this._texture = IntPtr.Zero;                
                }

                public void LoadTexture(string path)
                {
                        if (string.IsNullOrEmpty(path))
                        {
                                throw new Exception("No directory path");
                        }

                        IntPtr surface = SDL_image.IMG_Load(path);
                        if (surface == IntPtr.Zero)
                        {
                                string error = string.Format("Could load image: {0}", SDL.SDL_GetError()) ;
                                Console.WriteLine(error);
                                throw new Exception(error);
                        }
                }
        }
}
