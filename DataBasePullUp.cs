﻿namespace Fitness
{
    class DataBasePullUp
    {
        public DataBasePullUp() 
        { 

        }
        public DataBasePullUp(int id, string first_approach, string second_approach, string third_approach, string fourth_approach, string fiveth_approach, string date)
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
        public string First_approach { get; set; }
        public string Second_approach { get; set; }
        public string Third_approach { get; set; }
        public string Fourth_approach { get; set; }
        public string Fiveth_approach { get; set; }
        public string Date { get; set; }
    }
}
