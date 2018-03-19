using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Bowling.Specs.Infrastructure
{
	public static class ShouldExtensionMethods
	{
		public static T And<T>(this T actual)
		{
			return actual;
		}

		public static void ShouldBeFalse(this bool condition)
		{
			Assert.IsFalse(condition);
		}

		public static void ShouldBeFalse(this bool condition, string message)
		{
			Assert.IsFalse(condition, message);
		}

		public static void ShouldBeTrue(this bool condition)
		{
			Assert.IsTrue(condition);
		}

		public static void ShouldBeTrue(this bool condition, string message)
		{
			Assert.IsTrue(condition, message);
		}

		public static T ShouldEqual<T>(this T actual, T expected)
		{
			Assert.AreEqual(expected, actual);
			return actual;
		}

		public static T ShouldEqual<T>(this T actual, T expected, string message)
		{
			Assert.AreEqual(expected, actual, message);
			return actual;
		}

		public static T ShouldNotEqual<T>(this T actual, T expected)
		{
			Assert.AreNotEqual(expected, actual);
			return actual;
		}

		public static void ShouldBeNull(this object anObject)
		{
			Assert.IsNull(anObject);
		}

		public static void ShouldBeNull(this object anObject, string message)
		{
			Assert.IsNull(anObject, message);
		}

		public static void ShouldNotBeNull(this object anObject)
		{
			Assert.IsNotNull(anObject);
		}

		public static void ShouldNotBeNull(this object anObject, string message)
		{
			Assert.IsNotNull(anObject, message);
		}

		public static object ShouldBeTheSameAs(this object actual, object expected)
		{
			Assert.AreSame(expected, actual);
			return actual;
		}

		public static object ShouldNotBeTheSameAs(this object actual, object expected)
		{
			Assert.AreNotSame(expected, actual);
			return actual;
		}

		public static T ShouldBeA<T>(this object actual)
		{
			Assert.IsInstanceOf(typeof(T), actual);
			return (T)actual;
		}

		public static void ShouldContain(this IEnumerable actual, params object[] expected)
		{
			foreach (object expect in expected)
				CollectionAssert.Contains(actual, expect);
		}

		public static void ShouldContain(this IEnumerable actual, string message, params object[] expected)
		{
			foreach (object expect in expected)
				CollectionAssert.Contains(actual, expect, message);
		}

		public static void ShouldContain(this IEnumerable actual, IEnumerable expected)
		{
			foreach (object expect in expected)
				CollectionAssert.Contains(actual, expect);
		}

		public static void ShouldContain(this IEnumerable actual, string message, IEnumerable expected)
		{
			foreach (object expect in expected)
				CollectionAssert.Contains(actual, expect, message);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, params T[] expected)
		{
			foreach (T expect in expected)
				CollectionAssert.Contains(actual, expect);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			foreach (T expect in expected)
				CollectionAssert.Contains(actual, expect);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, IEnumerable<T> expected, string message)
		{
			foreach (T expect in expected)
				CollectionAssert.Contains(actual, expect, message);
		}

		public static void ShouldContain<T>(this IEnumerable<T> actual, Func<T, bool> predicate )
		{
			var contained = false;
			foreach (T item in actual)
			{
				if (predicate(item)) contained = true;
			}	
			Assert.IsTrue(contained);
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> actual, Func<T, bool> predicate)
		{
			actual.ShouldNot(predicate, "the collection contained an item matching the predicate; it should not have.");
		}

		public static void Should<T>(this IEnumerable<T> list, Func<T, bool> predicate, string message)
		{
			foreach (T item in list)
				if (!predicate(item))
					throw new AssertionException(message);
		}

		public static void ShouldNot<T>(this IEnumerable<T> list, Func<T, bool> predicate, string message)
		{
			foreach (T item in list)
				if (predicate(item))
					throw new AssertionException(message);
		}

		public static void Should<T>(this T item, Func<T, bool> predicate, string message)
		{
			if (!predicate(item))
				throw new AssertionException(message);
		}

		public static void ShouldNot<T>(this T item, Func<T, bool> predicate, string message)
		{
			if (predicate(item))
				throw new AssertionException(message);
		}

		public static void ShouldNotContain(this IEnumerable collection, params object[] expected)
		{
			foreach (object item in expected)
				CollectionAssert.DoesNotContain(collection, item);
		}

		public static IComparable ShouldBeGreaterThan(this IComparable arg1, IComparable arg2)
		{
			Assert.Greater(arg1, arg2);
			return arg1;
		}

		public static IComparable ShouldBeLessThan(this IComparable arg1, IComparable arg2)
		{
			Assert.Less(arg1, arg2);
			return arg1;
		}

		public static void ShouldBeEmpty(this IEnumerable collection)
		{
			Assert.IsEmpty(collection);
		}

		public static void ShouldBeEmpty<T>(this IEnumerable<T> collection)
		{
			Assert.IsEmpty(collection);
		}

		public static void ShouldBeEmpty(this string aString)
		{
			Assert.IsEmpty(aString);
		}

		public static void ShouldNotBeEmpty(this IEnumerable collection)
		{
			Assert.IsNotEmpty(collection);
		}

		public static void ShouldNotBeEmpty<T>(this IEnumerable<T> collection)
		{
			Assert.IsNotEmpty(collection);
		}

		public static void ShouldNotBeEmpty(this string aString)
		{
			Assert.IsNotEmpty(aString);
		}

		public static void ShouldContain(this string actual, string expected)
		{
			StringAssert.Contains(expected, actual);
		}

		public static void ShouldNotContain(this string actual, string unexpected)
		{
			Assert.IsFalse(actual.Contains(unexpected), "Did not expect to contain the string {0}\nActual was {1}", unexpected, actual);
		}

		public static string ShouldBeEqualIgnoringCase(this string actual, string expected)
		{
			StringAssert.AreEqualIgnoringCase(expected, actual);
			return actual;
		}

		public static string ShouldStartWith(this string actual, string expected)
		{
			StringAssert.StartsWith(expected, actual);
			return actual;
		}

		public static string ShouldEndWith(this string actual, string expected)
		{
			StringAssert.EndsWith(expected, actual);
			return actual;
		}

		public static void ShouldBeSurroundedWith(this string actual, string expectedStartDelimiter,
			string expectedEndDelimiter)
		{
			actual.ShouldStartWith(expectedStartDelimiter).ShouldEndWith(expectedEndDelimiter);
		}

		public static void ShouldBeSurroundedWith(this string actual, string expectedDelimiter)
		{
			ShouldBeSurroundedWith(actual, expectedDelimiter, expectedDelimiter);
		}

		public static void ShouldMatch(this string actual, string expectedPattern)
		{
			Assert.IsTrue(actual.Matches(expectedPattern));
		}

		public static bool Matches(this string actual, string expectedPattern)
		{
			var regex = new Regex(expectedPattern, RegexOptions.Singleline | RegexOptions.ExplicitCapture);
			return regex.IsMatch(actual);
		}

		public static Exception ShouldBeThrownBy(this Type exceptionType, Action method)
		{
			Exception exception = null;

			try
			{
				method();
			}
			catch (Exception e)
			{
				Assert.AreEqual(exceptionType, e.GetType());
				exception = e;
			}

			if (exception == null)
			{
				Assert.Fail(String.Format("Expected {0} to be thrown.", exceptionType.FullName));
			}

			return exception;
		}

		public static IEnumerable<T> ShouldEqual<T>(this IEnumerable<T> actual, params T[] expected)
		{
			return ShouldEqual(actual, (IEnumerable<T>)expected);
		}
		/*
		public static IEnumerable<T> ShouldEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			Assert.AreElementsEqual(expected, actual);
			return actual;
		}*/

	}

	public static class MockingShoulds
	{
		public static void ShouldReceiveThisCall<T>(this T thingy, Action<T> action, Action<IMethodOptions<object>> options)
		{
			thingy.AssertWasCalled(action, options);
		}

		public static void ShouldReceiveThisCall<T>(this T thingy, Action<T> action)
		{
			thingy.AssertWasCalled(action, null);
		}

		public static void ShouldNotReceiveThisCall<T>(this T thingy, Action<T> action, Action<IMethodOptions<object>> options)
		{
			thingy.AssertWasNotCalled(action, options);
		}

		public static void ShouldNotReceiveThisCall<T>(this T thingy, Action<T> action)
		{
			thingy.ShouldNotReceiveThisCall(action, null);
		}

		public static void ShouldNeverCall<T>(this T thingy, Action<T> action)
		{
			thingy.ShouldNotReceiveThisCall(action, o => o.IgnoreArguments());
		}
	}
}