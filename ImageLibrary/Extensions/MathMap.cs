﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Extensions
{
    public static class MathMap
    {
        #region Complex

        public static IImage<Complex> Sqrt(IImage<Complex> image)
        {
            return image.MapValue(Complex.Sqrt);
        }

        public static IImage<Complex> Abs(IImage<Complex> image)
        {
            return image.MapValue(c => new Complex(Math.Abs(c.Real), Math.Abs(c.Imaginary)));
        }

        public static IImage<Complex> Exp(IImage<Complex> image)
        {
            return image.MapValue(Complex.Exp);
        }

        public static IImage<Complex> Log10(IImage<Complex> image)
        {
            return image.MapValue(Complex.Log10);
        }

        public static IImage<Complex> Acos(IImage<Complex> image)
        {
            return image.MapValue(Complex.Acos);
        }

        public static IImage<Complex> Asin(IImage<Complex> image)
        {
            return image.MapValue(Complex.Asin);
        }

        public static IImage<Complex> Tan(IImage<Complex> image)
        {
            return image.MapValue(Complex.Tan);
        }

        public static IImage<Complex> Sin(IImage<Complex> image)
        {
            return image.MapValue(Complex.Sin);
        }

        public static IImage<Complex> Cos(IImage<Complex> image)
        {
            return image.MapValue(Complex.Cos);
        }

        public static IImage<Complex> Log(IImage<Complex> image)
        {
            return image.MapValue(Complex.Log);
        }

        public static IImage<Complex> Atan(IImage<Complex> image)
        {
            return image.MapValue(Complex.Atan);
        }

        public static IImage<Complex> Ceiling(IImage<Complex> image)
        {
            return image.MapValue(c => new Complex(Math.Ceiling(c.Real), Math.Ceiling(c.Imaginary)));
        }

        public static IImage<Complex> Floor(IImage<Complex> image)
        {
            return image.MapValue(c => new Complex(Math.Floor(c.Real), Math.Floor(c.Imaginary)));
        }

        public static IImage<Complex> Log(IImage<Complex> image, double baseValue)
        {
            return image.MapValue(x => Complex.Log(x, baseValue));
        }

        #endregion

        #region Double

        public static IImage<Double> Sqrt(this IImage<Double> image)
        {
            return image.MapValue(Math.Sqrt);
        }

        public static IImage<Double> Abs(this IImage<Double> image)
        {
            return image.MapValue(Math.Abs);
        }

        public static IImage<Double> Exp(this IImage<Double> image)
        {
            return image.MapValue(Math.Exp);
        }

        public static IImage<Double> Log10(this IImage<Double> image)
        {
            return image.MapValue(Math.Log10);
        }

        public static IImage<Double> Acos(this IImage<Double> image)
        {
            return image.MapValue(Math.Acos);
        }

        public static IImage<Double> Asin(this IImage<Double> image)
        {
            return image.MapValue(Math.Asin);
        }

        public static IImage<Double> Tan(this IImage<Double> image)
        {
            return image.MapValue(Math.Tan);
        }

        public static IImage<Double> Sin(this IImage<Double> image)
        {
            return image.MapValue(Math.Sin);
        }

        public static IImage<Double> Cos(this IImage<Double> image)
        {
            return image.MapValue(Math.Cos);
        }

        public static IImage<Double> Log(this IImage<Double> image)
        {
            return image.MapValue(Math.Log);
        }

        public static IImage<Double> Atan(this IImage<Double> image)
        {
            return image.MapValue(Math.Atan);
        }

        public static IImage<Double> Ceiling(this IImage<Double> image)
        {
            return image.MapValue(Math.Ceiling);
        }

        public static IImage<Double> Floor(this IImage<Double> image)
        {
            return image.MapValue(Math.Floor);
        }

        public static IImage<Double> Log(this IImage<Double> image, double baseValue)
        {
            return image.MapValue(x => Math.Log(x, baseValue));
        }

        #endregion

        #region RGB
         
        public static IImage<RGB> Sqrt(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Sqrt);
        }

        public static IImage<RGB> Abs(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Abs);
        }

        public static IImage<RGB> Exp(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Exp);
        }

        public static IImage<RGB> Log10(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Log10);
        }

        public static IImage<RGB> Acos(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Acos);
        }

        public static IImage<RGB> Asin(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Asin);
        }

        public static IImage<RGB> Tan(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Tan);
        }

        public static IImage<RGB> Sin(this IImage<RGB> image)
        {
            
            return image.MapAcross(Math.Sin);
        }

        public static IImage<RGB> Cos(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Cos);
        }

        public static IImage<RGB> Log(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Log);
        }

        public static IImage<RGB> Atan(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Atan);
        }

        public static IImage<RGB> Ceiling(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Ceiling);
        }

        public static IImage<RGB> Floor(this IImage<RGB> image)
        {
            return image.MapAcross(Math.Floor);
        }

        public static IImage<RGB> Log(this IImage<RGB> image, double baseValue)
        {
            return image.MapAcross(x => Math.Log(x, baseValue));
        }

        #endregion

        public static double Max(IImage<Double> img)
        {
            return img.Aggregate(Math.Max);
        }

        public static double Max(params Double[] values)
        {
            return values.Aggregate(Math.Max);
        }

        public static double Max(IEnumerable<Double> values)
        {
            return values.Aggregate(Math.Max);
        }

        public static double Min(IImage<Double> img)
        {
            return img.Aggregate(Math.Min);
        }

        public static double Min(params Double[] values)
        {
            return values.Aggregate(Math.Min);
        }
    }
}