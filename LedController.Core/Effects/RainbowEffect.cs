using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Core.Effects
{
    public class RainbowEffect : Effect
    {
        public const string ColorsParameterName = "Colors";


        

        private Color[] _colors;

        public Color[] Colors
        {
            get => _colors;
            set => _colors = value;
        }


        protected int Position { get; set; }

        protected int Segments { get; set; }

        protected int LedsPerSegment { get; set; }

        private int _pixelCount;

        /// <summary>
        /// The amount of colors we need ot display.
        /// </summary>
        public override int PixelCount
        {
            get => _pixelCount;
            set
            {
                _pixelCount = value;
                SetPixelCountParameters(value);
            } }


        public override EffectType Type => EffectType.RainbowCustom;




        // Color calculation done as followed
        /*
        
        Tops are ownly shows that the nominal color shown

	   |\	  /|\     /|\     /|\     /|
	   | \	 / | \   / | \   / | \   / |
       |  \ /  |  \ /  |  \ /  |  \ /  |
       |   X   |   X   |   X   |   X   |
       |  / \  |  / \  |  / \  |  / \  | 
       | /   \ | /   \ | /   \ | /   \ |
       |/     \|/     \|/     \|/     \|
	    
       ^
	   A Color Top
       B Color bottom
          ^
          A + B
              ^
			  B + A
          
        
        //*/


        public RainbowEffect() : base()
        {
            
        }


        public RainbowEffect(Color[] colors)
        {
            _colors = colors;
        }


        public RainbowEffect(EffectParameters parameters) : base(parameters)
        {
            RainbowEffectParameters settings = (RainbowEffectParameters)parameters;

            // Read parameters
            _colors = settings.Colors;
        }


        public void SetPixelCountParameters(int pixelCount)
        {
            int leds = PixelCount - 1;
            int segments = _colors.Count();

            int ledsPerSegment = (int) Math.Truncate(((double) (PixelCount / segments)));

            leds = ledsPerSegment * segments;

            Segments = segments;
            PixelCount = leds;
            LedsPerSegment = ledsPerSegment;
        }


        public override bool MoveNext()
        {
            Color[] colors = new Color[PixelCount];



            int i = 0 + Position;


            for (int s = 0; s < Segments; s++)
            {
                //_logger.LogInformation($"segment {s}");

                for (int j = 0; j < LedsPerSegment; j++)
                {
                    int cAR = CalculateAColor(_colors[s].R, j);
                    int cAG = CalculateAColor(_colors[s].G, j);
                    int cAB = CalculateAColor(_colors[s].B, j);

                    Color a = Color.FromArgb(Math.Min(cAR, 255), Math.Min(cAG, 255), Math.Min(cAB, 255));
                    //_logger.LogInformation($"colorA {a}");


                    Color nxtColor = GetNextColor(_colors, s);
                    int cBR = CalculateBColor(nxtColor.R, j);
                    int cBG = CalculateBColor(nxtColor.G, j);
                    int cBB = CalculateBColor(nxtColor.B, j);

                    Color b = Color.FromArgb(Math.Min(cBR, 255), Math.Min(cBG, 255), Math.Min(cBB, 255));
                    //_logger.LogInformation($"ColorB {b}");

                    //int nextindex = GetLedOffset(i);

                    colors[GetLedOffset(i)] = MixColors(a, b);
                    i++;
                }
            }

            Position++;

            Current = colors;

            if (Position >= PixelCount)
            {
                return false;
                Position = 0;
            }


            return true;

            int CalculateAColor(int value, int j)
            {
                if (value == 0)
                {
                    return 0;
                }

                return (value / LedsPerSegment) * (LedsPerSegment - j);
            }

            int CalculateBColor(int value, int j)
            {
                if (value == 0)
                {
                    return 0;
                }

                return (value / LedsPerSegment) * j;
            }



        }


        private int GetLedOffset(int currentIndex)
        {
            if (currentIndex >= PixelCount)
            {
                return currentIndex - PixelCount;
            }

            return currentIndex;
        }



        private Color GetNextColor(IList<Color> colors, int currentIndex)
        {
            if (currentIndex >= Segments - 1)
            {
                return colors[0];
            }

            return colors[currentIndex + 1];
        }


        private Color MixColors(Color a, Color b)
        {

            return Color.FromArgb(Math.Min(a.R + b.A, 255), Math.Min(a.G + b.G, 255), Math.Min(a.B + b.B, 255));

        }





    }



    public class RainbowEffectParameters : EffectParameters
    {

        public Color[] Colors { get; set; }



    }
}
