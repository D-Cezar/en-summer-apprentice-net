namespace EndavaProject.ExceptionRepository.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(long entityId, string entityName) : base(FormattableString.Invariant($"'{entityName}' with id '{entityId}' was not found."))
        {
        }
    }
}