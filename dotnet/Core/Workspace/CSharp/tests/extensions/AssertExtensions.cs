namespace Tests.Workspace
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public static class AssertExtensions
    {
        public static void ShouldEqual(this object actual, object expected, Context context, Mode mode1, Mode mode2)
            => Assert.True(Equals(actual, expected), $"Expected Equals: [{actual}, {expected}] on context {context} with mode1 {mode1} and mode2 {mode2}");

        public static void ShouldEqual(this object actual, object expected, Context context, Mode mode)
            => Assert.True(Equals(actual, expected), $"Expected Equals: [{actual}, {expected}] on context {context} with mode1 {mode}");


        public static void ShouldNotBeNull(this object actual, Context context, Mode mode1, Mode mode2)
            => Assert.True(!(actual is null), $"Expected Not Null: [{actual}] on context {context} with mode1 {mode1} and mode2 {mode2}");

        public static void ShouldNotBeNull(this object actual, Context context, Mode mode)
            => Assert.True(!(actual is null), $"Expected Not Null: [{actual}] on context {context} with mode1 {mode}");


        public static void ShouldContains(this IEnumerable<object> colletion, object expected, Context context, Mode mode1, Mode mode2)
            => Assert.True(colletion.Contains(expected), $"Expected Not Null: [{colletion}, {expected}] on context {context} with mode1 {mode1} and mode2 {mode2}");

        public static void ShouldContains(this IEnumerable<object> colletion, object expected, Context context, Mode mode)
            => Assert.True(colletion.Contains(expected), $"Expected Not Null: [{colletion}, {expected}] on context {context} with mode1 {mode}");

        public static void ShouldNotContains(this IEnumerable<object> colletion, object expected, Context context, Mode mode)
            => Assert.True(!colletion.Contains(expected), $"Expected Not Contains: [{colletion}, {expected}] on context {context} with mode {mode}");

        public static void ShouldNotContains(this IEnumerable<object> colletion, object expected, Context context, Mode mode1, Mode mode2)
            => Assert.True(!colletion.Contains(expected), $"Expected Not Contains: [{colletion}, {expected}] on context {context} with mode& {mode1} and mode2 {mode2}");
    }
}