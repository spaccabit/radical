﻿namespace Test.Radical.ChangeTracking
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Topics.Radical.ComponentModel.ChangeTracking;
	using Topics.Radical.ChangeTracking;
	using SharpTestsEx;
	using Topics.Radical;

	[TestClass]
	public class AdvisedActionTests
	{
		[TestMethod]
		[TestCategory( "ChangeTracking" )]
		public void advisedAction_ctor()
		{
			GenericParameterHelper target = new GenericParameterHelper();

			AdvisedAction actual = new AdvisedAction( target, ProposedActions.Delete );

			actual.Action.Should().Be.EqualTo( ProposedActions.Delete );
			actual.Target.Should().Be.EqualTo( target );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		[TestCategory( "ChangeTracking" )]
		public void advisedAction_ctor_null_reference_target()
		{
			AdvisedAction actual = new AdvisedAction( null, ProposedActions.Delete );
		}

		[TestMethod]
		[ExpectedException( typeof( NotSupportedException ) )]
		[TestCategory( "ChangeTracking" )]
		public void advisedAction_ctor_not_supported_proposed_action()
		{
			AdvisedAction actual = new AdvisedAction( new Object(), ProposedActions.None );
		}

		[TestMethod]
		[ExpectedException( typeof( EnumValueOutOfRangeException ) )]
		[TestCategory( "ChangeTracking" )]
		public void advisedAction_ctor_invalid_proposed_action()
		{
			AdvisedAction actual = new AdvisedAction( new Object(), ( ProposedActions )1000 );
		}
	}
}