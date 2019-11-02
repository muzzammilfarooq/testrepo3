using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlotPOS.Class
{
    public static class clsGlobalVar
    {
        static long _userid;
        static long _counterid;
        static bool _ispaymentdone;
        static bool? _FreeEntry;
        static bool _isCardActivated;
        static bool _isMasterCard;
        static bool _isNewCard;
        static decimal? _newCardAmount;
        static decimal? _basicCardAmount;
        static float _DeductionAmount;
        static DateTime _SaleDate;
        static bool _isCardActivationFormOpen;
        static bool? _closeDate;

        public static long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public static bool? closeDate
        {
            get { return _closeDate; }
            set { _closeDate = value; }
        }
        public static bool? FreeEntry
        {
            get { return _FreeEntry; }
            set { _FreeEntry = value; }
        }
        public static long CounterID
        {
            get { return _counterid; }
            set { _counterid = value; }
        }

        public static float DeductionAmount
        {
            get { return _DeductionAmount; }
            set { _DeductionAmount = value; }
        }
        public static decimal? NewCardAmount
        {
            get { return _newCardAmount; }
            set { _newCardAmount = value; }
        }
        public static decimal? BasicCardAmount
        {
            get { return _basicCardAmount; }
            set { _basicCardAmount = value; }
        }
        public static bool IsPaymentDone
        {
            get { return _ispaymentdone; }
            set { _ispaymentdone = value; }
        }
        public static bool IsCardActivated
        {
            get { return _isCardActivated; }
            set { _isCardActivated = value; }
        }
        public static bool IsNewCard
        {
            get { return _isNewCard; }
            set { _isNewCard = value; }
        }
        public static bool IsMasterCard
        {
            get { return _isMasterCard; }
            set { _isMasterCard = value; }
        }
        public static DateTime SaleDate
        {
            get { return _SaleDate; }
            set { _SaleDate = value; }
        }
        public static bool IsCardActivationFormOpen
        {
            get { return _isCardActivationFormOpen; }
            set { _isCardActivationFormOpen = value; }
        }
    }
}
