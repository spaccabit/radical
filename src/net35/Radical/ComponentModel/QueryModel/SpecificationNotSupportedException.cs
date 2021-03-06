﻿namespace Topics.Radical.ComponentModel.QueryModel
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// The excpetion raised when the infrastructure cannot find any
	/// engine for a given specification.
	/// </summary>
#if !SILVERLIGHT
	[Serializable]
#endif
	public class SpecificationNotSupportedException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificationNotSupportedException"/> class.
		/// </summary>
		public SpecificationNotSupportedException()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificationNotSupportedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public SpecificationNotSupportedException( string message )
			: base( message )
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificationNotSupportedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public SpecificationNotSupportedException( string message, Exception inner )
			: base( message, inner )
		{

		}

#if !SILVERLIGHT

		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificationNotSupportedException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
		/// </exception>
		protected SpecificationNotSupportedException( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{

		}

#endif
	}
}
