﻿
namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCOde { get; } = default!;

        protected Address()
        {
            
        }

        private Address(string firstName, string lastName, string emailAddress, string addressline, string country, string state, string zipCode) { 
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressline;
            Country = country;
            State = state;
            ZipCOde = zipCode;
        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addressline, string country, string state, string zipCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addressline);
            return new Address(firstName, lastName, emailAddress, addressline, country, state, zipCode);
        }
    }
}
