using Bookify.Domain.Abstractions;

namespace Bookify.Domain.ApartmentTask
{
    public static class ApartmentTaskErrors
    {
        public static Error AlreadyResolved = new(
            "ApartmentTask.AlreadyResolved",
            "The apartment task has already resolved");
    }
}