namespace Topics.Radical.Linq
{
	using System;
	using System.Text.RegularExpressions;
	using Topics.Radical.Validation;
	using Topics.Radical.ComponentModel;
	using System.Linq;

	public static class QueryableExtensions
	{
		/// <summary>
		/// Fills the specified destination collection using data coming from the given source
		/// and adapting the source data to the destination format using the speficied adapter
		/// delegate.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDest">The type of the destination.</typeparam>
		/// <param name="source">The source data.</param>
		/// <param name="destination">The destination container.</param>
		/// <param name="adapter">The adapter.</param>
		/// <returns>The a reference to the supplied destination container to allow fluent interface usage.</returns>
		public static IEntityCollection<TDest> Fill<TSource, TDest>( this IQueryable<TSource> source, IEntityCollection<TDest> destination, Func<TSource, TDest> adapter )
			where TDest : class
		{
			destination.BeginInit();
			source.ForEach( element => destination.Add( adapter( element ) ) );
			destination.EndInit();

			return destination;
		}

		/// <summary>
		/// Fills the specified destination collection using data coming from the given source
		/// and adapting the source data to the destination format using the speficied adapter
		/// delegate.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDest">The type of the destination.</typeparam>
		/// <param name="source">The source data.</param>
		/// <param name="destination">The destination container.</param>
		/// <param name="adapter">The adapter.</param>
		/// <returns>
		/// The a reference to the supplied destination container to allow fluent interface usage.
		/// </returns>
		public static IEntityCollection<TDest> Fill<TSource, TDest>( this IQueryable<TSource> source, IEntityCollection<TDest> destination, Func<TSource, IEntityCollection<TDest>, TDest> adapter )
			where TDest : class
		{
			destination.BeginInit();
			source.ForEach( element => destination.Add( adapter( element, destination ) ) );
			destination.EndInit();

			return destination;
		}
	}
}
