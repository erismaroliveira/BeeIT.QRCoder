using System;

namespace BeeIT.QRCoder
{
    /// <summary>
    /// Helper functions to check for valid arguments.
    /// </summary>
    internal static class Objects
    {
        /// <summary>
        /// Ensures that the specified argument is <i>not null</i>.
        /// <para>
        /// Throws a <see cref="ArgumentNullException"/> exception if the argument is <c>null</c>.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="arg">The argument to check.</param>
        /// <returns>Argument passed to function.</returns>
        /// <exception cref="ArgumentNullException">The specified argument is <c>null</c>.</exception>
        internal static T RequireNonNull<T>(T arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException();
            }
            return arg;
        }
    }
}