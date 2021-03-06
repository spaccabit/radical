﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Topics.Radical.ChangeTracking;
using Topics.Radical.ComponentModel.ChangeTracking;
using SharpTestsEx;

namespace Test.Radical.ChangeTracking
{
	[TestClass]
	public class ChangeSetDistinctVisitorTests
	{
		[TestMethod()]
		[TestCategory( "ChangeTracking" )]
		public void changeSetDistinctVisitor_visit()
		{
			ChangeSetDistinctVisitor target = new ChangeSetDistinctVisitor();

			var entities = new Object[] { new Object() };
			var c1 = MockRepository.GenerateStub<IChange>();
			c1.Expect( obj => obj.GetChangedEntities() ).Return( entities );

			var c2 = MockRepository.GenerateStub<IChange>();
			c2.Expect( obj => obj.GetChangedEntities() ).Return( entities );

			IChangeSet cSet = new ChangeSet( new IChange[] { c1, c2 } );

			var result = target.Visit( cSet );

			result.Count.Should().Be.EqualTo( 1 );
			result[ entities[ 0 ] ].Should().Be.EqualTo( c2 );
		}

		[TestMethod()]
		[ExpectedException( typeof( ArgumentNullException ) )]
		[TestCategory( "ChangeTracking" )]
		public void changeSetDistinctVisitor_visit_null_changeSet_reference()
		{
			ChangeSetDistinctVisitor target = new ChangeSetDistinctVisitor();
			target.Visit( null );
		}
	}
}
