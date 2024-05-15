namespace Hotel.Objects
{
    internal class History
    {
        public string Date { get; set; }
        public string FullName { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentAmount { get; set; }
        public string User { get; set; }

        public History(string date, string fullName, string paymentMethod, int paymentAmount, string user)
        {
            Date = date;
            FullName = fullName;
            PaymentMethod = paymentMethod;
            PaymentAmount = paymentAmount;
            User = user;
        }

        public static History GetHistory(string historyString)
        {
            string[] strings = historyString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new History(strings[0], strings[1], strings[2], int.Parse(strings[3]), strings[4]);
        }

        public override string ToString()
        {
            return $"{Date.Trim()} - Сумма: {PaymentAmount} ({FullName.Trim()})";
        }
    }
}
