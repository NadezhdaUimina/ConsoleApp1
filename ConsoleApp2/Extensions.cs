using System.Globalization;

namespace ConsoleApp2;

internal static class Extensions
{
    internal static T Insert<T>(Predicate<T> predicate) where T : struct, IParsable<T>
    {
        T command;
        while (!T.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out command) || !predicate.Invoke(command))
            Console.WriteLine(ConsoleOutput.InputError);
        return command;
    }
}