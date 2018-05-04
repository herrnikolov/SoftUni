namespace _04._Online_Radio_Database
{
    internal class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}
