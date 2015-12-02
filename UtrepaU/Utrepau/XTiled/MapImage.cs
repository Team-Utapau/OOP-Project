using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace FuncWorks.XNA.XTiled
{
    /// <summary>
    /// Represents an image in an ImageLayer
    /// </summary>
    public class MapImage
    {
        /// <summary>
        /// Optional name of the tileset
        /// </summary>
        public String Name;
        /// <summary>
        /// Custom properties
        /// </summary>
        public Dictionary<String, Property> Properties;
        /// <summary>
        /// Full path of the image referenced in the TMX file
        /// </summary>
        public String ImageFileName;
        /// <summary>
        /// Transparent color as set in the Tiled editor; null if not set
        /// </summary>
        public Color? ImageTransparentColor;
        /// <summary>
        /// Width of image in pixels
        /// </summary>
        public Int32 ImageWidth;
        /// <summary>
        /// Height of image in pixels
        /// </summary>
        public Int32 ImageHeight;
        /// <summary>
        /// Image as an XNA Texture2D instance; null if Map.LoadTextures is false
        /// </summary>
        public Texture2D Texture;
    }
}
