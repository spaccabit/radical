﻿using System;
using System.Linq;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SharpTestsEx;
using Topics.Radical.ComponentModel;

namespace Test.Radical
{
	[TestClass()]
	public class EntityItemViewPropertyDescriptorTests
	{
		[TestMethod]
		public void entityItemViewPropertyDescriptor_ctor_default_should_correctly_set_default_values()
		{
			var expected = "Data";
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( expected );

			target.Category.Should().Be.EqualTo( "Misc" );
			target.Attributes.OfType<Attribute>().Should().Have.SameSequenceAs( new Attribute[ 0 ] );
			target.ComponentType.Should().Be.EqualTo( typeof( IEntityItemView<GenericParameterHelper> ) );
			target.Converter.GetType().Should().Be.EqualTo( typeof( Int32Converter ) );
			target.Description.Should().Be.EqualTo( String.Empty );
			target.DesignTimeOnly.Should().Be.False();
			target.DisplayName.Should().Be.EqualTo( expected );
			target.IsBrowsable.Should().Be.True();
			target.IsLocalizable.Should().Be.False();
			target.IsReadOnly.Should().Be.False();
			target.Name.Should().Be.EqualTo( expected );
			target.PropertyType.Should().Be.EqualTo( typeof( Int32 ) );
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_ctor_propertyName_customDisplayName_should_correctly_set_default_values()
		{
			var propertyName = "Data";
			var customDisplayName = "Foo";

			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( propertyName, customDisplayName );

			target.Category.Should().Be.EqualTo( "Misc" );
			target.Attributes.OfType<Attribute>().Should().Have.SameSequenceAs( new Attribute[ 0 ] );
			target.ComponentType.Should().Be.EqualTo( typeof( IEntityItemView<GenericParameterHelper> ) );
			target.Converter.GetType().Should().Be.EqualTo( typeof( Int32Converter ) );
			target.Description.Should().Be.EqualTo( String.Empty );
			target.DesignTimeOnly.Should().Be.False();
			target.DisplayName.Should().Be.EqualTo( customDisplayName );
			target.IsBrowsable.Should().Be.True();
			target.IsLocalizable.Should().Be.False();
			target.IsReadOnly.Should().Be.False();
			target.Name.Should().Be.EqualTo( propertyName );
			target.PropertyType.Should().Be.EqualTo( typeof( Int32 ) );
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_ctor_propertyInfo_should_correctly_set_default_values()
		{
			var expected = typeof( GenericParameterHelper ).GetProperty( "Data" );

			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( expected );

			target.Category.Should().Be.EqualTo( "Misc" );
			target.Attributes.OfType<Attribute>().Should().Have.SameSequenceAs( new Attribute[ 0 ] );
			target.ComponentType.Should().Be.EqualTo( typeof( IEntityItemView<GenericParameterHelper> ) );
			target.Converter.GetType().Should().Be.EqualTo( typeof( Int32Converter ) );
			target.Description.Should().Be.EqualTo( String.Empty );
			target.DesignTimeOnly.Should().Be.False();
			target.DisplayName.Should().Be.EqualTo( expected.Name );
			target.IsBrowsable.Should().Be.True();
			target.IsLocalizable.Should().Be.False();
			target.IsReadOnly.Should().Be.EqualTo( !expected.CanWrite );
			target.Name.Should().Be.EqualTo( expected.Name );
			target.PropertyType.Should().Be.EqualTo( expected.PropertyType );
		}

		[TestMethod]
		public void entityItemViewCustomPropertyDescriptor_ctor_customDisplayName_propertyType_valueGetter_should_correctly_set_default_values()
		{
			var customPropertyName = "Foo";
			EntityItemViewValueGetter<GenericParameterHelper, Int32> getter = ( obj ) => { return null; };

			var target = new EntityItemViewCustomPropertyDescriptor<GenericParameterHelper, Int32>( customPropertyName, getter );

			target.Category.Should().Be.EqualTo( "Misc" );
			target.Attributes.OfType<Attribute>().Should().Have.SameSequenceAs( new Attribute[ 0 ] );
			target.ComponentType.Should().Be.EqualTo( typeof( IEntityItemView<GenericParameterHelper> ) );
			target.Converter.GetType().Should().Be.EqualTo( typeof( Int32Converter ) );
			target.Description.Should().Be.EqualTo( String.Empty );
			target.DesignTimeOnly.Should().Be.False();
			target.DisplayName.Should().Be.EqualTo( customPropertyName );
			target.IsBrowsable.Should().Be.True();
			target.IsLocalizable.Should().Be.False();
			target.IsReadOnly.Should().Be.True();
			target.Name.Should().Be.EqualTo( customPropertyName );
			target.PropertyType.Should().Be.EqualTo( typeof( Int32 ) );
		}

		[TestMethod]
		public void entityItemViewCustomPropertyDescriptor_ctor_customDisplayName_propertyType_valueGetter_valueSetter_should_correctly_set_default_values()
		{
			var customPropertyName = "Foo";
			EntityItemViewValueGetter<GenericParameterHelper, Int32> getter = arg => { return null; };
			EntityItemViewValueSetter<GenericParameterHelper, Int32> setter = arg => { };

			var target = new EntityItemViewCustomPropertyDescriptor<GenericParameterHelper, Int32>( customPropertyName, getter, setter );

			target.Category.Should().Be.EqualTo( "Misc" );
			target.Attributes.OfType<Attribute>().Should().Have.SameSequenceAs( new Attribute[ 0 ] );
			target.ComponentType.Should().Be.EqualTo( typeof( IEntityItemView<GenericParameterHelper> ) );
			target.Converter.GetType().Should().Be.EqualTo( typeof( Int32Converter ) );
			target.Description.Should().Be.EqualTo( String.Empty );
			target.DesignTimeOnly.Should().Be.False();
			target.DisplayName.Should().Be.EqualTo( customPropertyName );
			target.IsBrowsable.Should().Be.True();
			target.IsLocalizable.Should().Be.False();
			target.IsReadOnly.Should().Be.False();
			target.Name.Should().Be.EqualTo( customPropertyName );
			target.PropertyType.Should().Be.EqualTo( typeof( Int32 ) );
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_canResetValue_normal_should_return_always_false()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );

			Boolean actual = target.CanResetValue( null );
			actual.Should().Be.False();
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_resetValue_normal_should_do_nothing()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.ResetValue( new GenericParameterHelper() );
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_shouldSerializeValue_normal_return_false()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			Boolean actual = target.ShouldSerializeValue( new GenericParameterHelper() );

			actual.Should().Be.False();
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_getValue_using_default_ctor_should_return_expected_value()
		{
			var expected = 100;
			var component = MockRepository.GenerateMock<IEntityItemView<GenericParameterHelper>>();
			component.Expect( mock => mock.EntityItem )
				.Return( new GenericParameterHelper( expected ) )
				.Repeat.Once();

			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			Int32 actual = ( Int32 )target.GetValue( component );

			actual.Should().Be.EqualTo( expected );
			component.VerifyAllExpectations();
		}

		[TestMethod]
		public void entityItemViewPropertyDescriptor_setValue_using_default_ctor_should_set_expected_value()
		{
			var expected = 100;
			var entityItem = new GenericParameterHelper( 0 );

			var component = MockRepository.GenerateMock<IEntityItemView<GenericParameterHelper>>();
			component.Expect( mock => mock.EntityItem )
				.Return( entityItem )
				.Repeat.Once();

			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.SetValue( component, expected );

			entityItem.Data.Should().Be.EqualTo( expected );
			component.VerifyAllExpectations();
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void entityItemViewPropertyDescriptor_getValue_using_null_reference_component_should_raise_ArgumentNullException()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.GetValue( null );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void entityItemViewPropertyDescriptor_setValue_using_null_reference_component_should_raise_ArgumentNullException()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.SetValue( null, 100 );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void entityItemViewPropertyDescriptor_getValue_using_invalid_reference_component_should_raise_ArgumentException()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.GetValue( new Object() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void entityItemViewPropertyDescriptor_setValue_using_invalid_reference_component_should_raise_ArgumentException()
		{
			var target = new EntityItemViewPropertyDescriptor<GenericParameterHelper>( "Data" );
			target.SetValue( new Object(), 100 );
		}
	}
}
