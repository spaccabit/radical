﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
using Topics.Radical;

namespace Test.Radical.Extensions
{
	[TestClass]
	public class ObjectExtensionsTests
	{
		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_Return_using_valid_parameter_should_behave_as_expected()
		{
			var expected = "a string";

			var actual = Topics.Radical.ObjectExtensions.Return( expected, v => v, "failed", s => String.IsNullOrEmpty( s ) );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_Return_using_invalid_parameter_should_behave_as_expected()
		{
			var expected = "failed";

			var actual = Topics.Radical.ObjectExtensions.Return( "", v => v, expected, s => String.IsNullOrEmpty( s ) );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_Return_using_null_parameter_should_behave_as_expected()
		{
			var expected = "failed";

			var actual = Topics.Radical.ObjectExtensions.Return( ( String )null, v => v, expected, s => String.IsNullOrEmpty( s ) );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_Return_using_valid_parameter_should_never_try_to_call_failureValue_provider()
		{
			var actual = false;

			Topics.Radical.ObjectExtensions.Return( "a value", v => v, () => { actual = true; return "failed"; }, s => String.IsNullOrEmpty( s ) );

			actual.Should().Be.False();
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_Return_using_valid_parameter_and_default_failure_evaluator_should_never_try_to_call_failureValue_provider()
		{
			var actual = false;

			Topics.Radical.ObjectExtensions.Return( "a value", v => v, () => { actual = true; return "failed"; } );

			actual.Should().Be.False();
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_With_using_valid_parameter_should_return_expected_value()
		{
			var expected = "foo";
			var actual = Topics.Radical.ObjectExtensions.With( expected, s => s );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_With_using_null_parameter_should_return_failure_value()
		{
			var expected = ( String )null;
			var actual = expected.With( s => s );

			actual.Should().Be.Null();
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_With_using_null_parameter_should_return_alternative_value()
		{
			var expected = "foo";
			var actual = ( ( String )null ).With( s => s, () => expected );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_With_using_empty_parameter_and_failure_evaluator_should_return_alternative_value()
		{
			var expected = "foo";
			var actual = ( "" ).With( s => s, s => String.IsNullOrEmpty( s ), () => expected );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_fluent_evaluation_using_invalid_graph_should_behave_as_expected()
		{
			var executed = false;

			var person = new Person()
			{
				Address = new Address()
			};

			person.With( p => p.Address )
				.Return( a => a.Street )
				.Do( s => executed = true );

			executed.Should().Be.False();
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_fluent_evaluation_using_valid_graph_should_behave_as_expected()
		{
			var executed = false;

			var person = new Person()
			{
				Address = new Address()
				{
					Street = "street"
				}
			};

			person.With( p => p.Address )
				.Return( a => a.Street )
				.Do( s => executed = true );

			executed.Should().Be.True();
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_fluent_evaluation_using_valid_graph_should_pass_expected_value()
		{
			var expected = "street";
			var actual = "";

			var person = new Person()
			{
				Address = new Address()
				{
					Street = expected
				}
			};

			person.With( p => p.Address )
				.Return( a => a.Street )
				.Do( s => actual = expected );

			actual.Should().Be.EqualTo( expected );
		}

		[TestMethod]
		[TestCategory( "ObjectExtensions" )]
		public void ObjectExtensions_fluent_evaluation_using_valid_graph_should_return_expected_value()
		{
			var expected = "street";
			var actual = "";

			var person = new Person()
			{
				Address = new Address()
				{
					Street = expected
				}
			};

			actual = person.With( p => p.Address )
				.Return( a => a.Street )
				.Do( s => { } );

			actual.Should().Be.EqualTo( expected );
		}
	}
}
