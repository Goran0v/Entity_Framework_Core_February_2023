using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Common
{
    public static class ValidationConstants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const int DirectorNameMinLength = 4;
        public const int DirectorNameMaxLength = 30;
        public const sbyte NumberOfHallsMinValue = 1;
        public const sbyte NumberOfHallsMaxValue = 10;

        //Ticket
        public const decimal TicketMinPrice = 1m;
        public const decimal TicketMaxPrice = 100m;
        public const sbyte RowNumberMinValue = 1;
        public const sbyte RowNumberMaxValue = 10;

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const int PlayDurationMinValue = 1;
        public const double PlayRatingMinValue = 0d;
        public const double PlayRatingMaxValue = 10d;
        public const int PlayDescriptionMaxLength = 700;
        public const int SreenwriterMinLength = 4;
        public const int SreenwriterMaxLength = 30;

        //Cast
        public const int FullNameMinLength = 4;
        public const int FullNameMaxLength = 30;
        public const string PhoneNumberRegEx = @"\+44-\d{2}-\d{3}-\d{4}";
    }
}
