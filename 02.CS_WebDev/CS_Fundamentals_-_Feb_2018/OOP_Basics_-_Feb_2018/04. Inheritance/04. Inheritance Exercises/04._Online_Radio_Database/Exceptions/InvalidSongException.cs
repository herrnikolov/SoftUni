namespace _04._Online_Radio_Database
{
    using System;

    internal class InvalidSongException : Exception
    {
        public override string Message => "Invalid song.";
    }
}
