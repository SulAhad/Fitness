namespace Fitness
{
    class DataBasePullUp
    {
        public DataBasePullUp() 
        { 

        }
        public DataBasePullUp(int id, double first_approach, double second_approach, double third_approach, double fourth_approach, double fiveth_approach, string date)
        {
            Id = id;
            this.First_approach = first_approach;
            this.Second_approach = second_approach;
            this.Third_approach = third_approach;
            this.Fourth_approach = fourth_approach;
            this.Fiveth_approach = fiveth_approach;
            this.Date = date;
        }

        public int Id { get; set; }
        public double First_approach { get; set; }
        public double Second_approach { get; set; }
        public double Third_approach { get; set; }
        public double Fourth_approach { get; set; }
        public double Fiveth_approach { get; set; }
        public string Date { get; set; }
    }
}
