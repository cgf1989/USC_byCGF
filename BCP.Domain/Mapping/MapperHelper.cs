using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public static class MapperHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns>Return TResult Instance or NUll</returns>
        public static TResult MapperTo<TSource, TResult>(this TSource source)
        {
            if (source == null) return default(TResult);
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<TSource, TResult>(source);
            }
            return default(TResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>Return IEnumerable<TResult></TResult></returns>
        public static IEnumerable<TResult> MapperTo<TSource, TResult>(this IEnumerable<TSource> source)
        {
            if (source == null) return new List<TResult>();
            if (Mapper.FindTypeMapFor(typeof(TSource), typeof(TResult)) != null)
            {
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TResult>>(source);
            }
            return new List<TResult>();
        }
    }
}
