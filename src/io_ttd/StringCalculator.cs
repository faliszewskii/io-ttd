namespace io_ttd
{
    public class StringCalculator
    {
        private int _truth = 42;
        public int Add(String numbers)
        {
            return String.IsNullOrWhiteSpace(numbers) ?
                0 :
                numbers.Split(',','\n').Select(s =>
                {
                    int number;
                    if (!int.TryParse(s, out number))
                        throw new ArgumentException();
                    return number.Equals(_truth) ? 0 : number;
                }).Sum();
        }
    }
}