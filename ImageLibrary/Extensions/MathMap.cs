﻿using System;
using System.Linq;
using System.Numerics;

namespace ImageLibrary.Extensions
{
    public static class MathMap
    {
        #region Complex

        public static IImage<Complex> Sqrt(IImage<Complex> image) 
            => image.MapValue(Complex.Sqrt);

        public static IImage<Complex> Abs(IImage<Complex> image)
            => image.MapValue(c => new Complex(Math.Abs(c.Real), Math.Abs(c.Imaginary)));

        public static IImage<Complex> Exp(IImage<Complex> image)
            => image.MapValue(Complex.Exp);

        public static IImage<Complex> Log10(IImage<Complex> image)
            => image.MapValue(Complex.Log10);

        public static IImage<Complex> Acos(IImage<Complex> image)
            => image.MapValue(Complex.Acos);

        public static IImage<Complex> Asin(IImage<Complex> image)
            => image.MapValue(Complex.Asin);

        public static IImage<Complex> Tan(IImage<Complex> image)
            => image.MapValue(Complex.Tan);

        public static IImage<Complex> Sin(IImage<Complex> image)
            => image.MapValue(Complex.Sin);

        public static IImage<Complex> Cos(IImage<Complex> image)
            => image.MapValue(Complex.Cos);

        public static IImage<Complex> Log(IImage<Complex> image)
            => image.MapValue(Complex.Log);

        public static IImage<Complex> Atan(IImage<Complex> image)
            => image.MapValue(Complex.Atan);

        public static IImage<Complex> Ceiling(IImage<Complex> image)
            => image.MapValue(c => new Complex(Math.Ceiling(c.Real), Math.Ceiling(c.Imaginary)));

        public static IImage<Complex> Floor(IImage<Complex> image)
            => image.MapValue(c => new Complex(Math.Floor(c.Real), Math.Floor(c.Imaginary)));

        public static IImage<Complex> Log(IImage<Complex> image, double baseValue)
            => image.MapValue(x => Complex.Log(x, baseValue));

        #endregion

        #region Double

        public static IImage<double> Sqrt(this IImage<double> image)
            => image.MapValue(Math.Sqrt);

        public static IImage<double> Abs(this IImage<double> image) 
            => image.MapValue(Math.Abs);

        public static IImage<double> Exp(this IImage<double> image) 
            => image.MapValue(Math.Exp);

        public static IImage<double> Log10(this IImage<double> image)
            => image.MapValue(Math.Log10);

        public static IImage<double> Acos(this IImage<double> image)
            => image.MapValue(Math.Acos);

        public static IImage<double> Asin(this IImage<double> image) 
            => image.MapValue(Math.Asin);

        public static IImage<double> Tan(this IImage<double> image)
            => image.MapValue(Math.Tan);

        public static IImage<double> Sin(this IImage<double> image)
            => image.MapValue(Math.Sin);

        public static IImage<double> Cos(this IImage<double> image) 
            => image.MapValue(Math.Cos);

        public static IImage<double> Log(this IImage<double> image)
            => image.MapValue(Math.Log);

        public static IImage<double> Atan(this IImage<double> image)
            => image.MapValue(Math.Atan);

        public static IImage<double> Ceiling(this IImage<double> image) 
            => image.MapValue(Math.Ceiling);

        public static IImage<double> Floor(this IImage<double> image)
            => image.MapValue(Math.Floor);

        public static IImage<double> Log(this IImage<double> image, double baseValue)
            => image.MapValue(x => Math.Log(x, baseValue));

        #endregion

        #region RGB
         
        public static IImage<RGB> Sqrt(this IImage<RGB> image)
            => image.MapAcross(Math.Sqrt);

        public static IImage<RGB> Abs(this IImage<RGB> image)
            => image.MapAcross(Math.Abs);

        public static IImage<RGB> Exp(this IImage<RGB> image)
            => image.MapAcross(Math.Exp);

        public static IImage<RGB> Log10(this IImage<RGB> image) 
            => image.MapAcross(Math.Log10);

        public static IImage<RGB> Acos(this IImage<RGB> image) 
            => image.MapAcross(Math.Acos);

        public static IImage<RGB> Asin(this IImage<RGB> image) 
            => image.MapAcross(Math.Asin);

        public static IImage<RGB> Tan(this IImage<RGB> image) 
            => image.MapAcross(Math.Tan);

        public static IImage<RGB> Sin(this IImage<RGB> image) 
            => image.MapAcross(Math.Sin);

        public static IImage<RGB> Cos(this IImage<RGB> image) 
            => image.MapAcross(Math.Cos);

        public static IImage<RGB> Log(this IImage<RGB> image) 
            => image.MapAcross(Math.Log);

        public static IImage<RGB> Atan(this IImage<RGB> image) 
            => image.MapAcross(Math.Atan);

        public static IImage<RGB> Ceiling(this IImage<RGB> image)
            => image.MapAcross(Math.Ceiling);

        public static IImage<RGB> Floor(this IImage<RGB> image) 
            => image.MapAcross(Math.Floor);

        public static IImage<RGB> Log(this IImage<RGB> image, double baseValue) 
            => image.MapAcross(x => Math.Log(x, baseValue));

        #endregion

        public static double Max(IImage<double> img) 
            => img.Aggregate(Math.Max);

        public static double Min(IImage<double> img) 
            => img.Aggregate(Math.Min);
    }
}
