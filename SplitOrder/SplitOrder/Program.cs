using System;

namespace SplitOrder
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            SplitOrder(3, 24.95);
            SplitOrder(5, 55.78);
            var ord = SplitOrder(16, 322.52);
           

            Console.WriteLine("[{0}]", string.Join(", ", ord));
        }

        static double[] SplitOrder(int recipients, double order)
        {
            double remainder = order % recipients;
            //greatest common factor
            int GCF = Convert.ToInt32(Math.Floor(order / recipients));

            //Console.WriteLine(GCF);
            //each sub will be roughly the GCF + remainder divided by the number of recipients
            //for un even splits sumSubs - ord != 0
            double sub = Math.Round((GCF + (remainder / recipients)), 2);
            //Console.WriteLine(sub);

            //store each sub in an array
            double[] subs = new double[recipients];
            for (int i = 0; i < recipients; i++)
            {
                subs[i] = sub;
            }
            //Console.WriteLine("[{0}]", string.Join(", ", subs));

            //sum the subs
            double sumSubs = 0;
            for (int i = 0; i < recipients; i++)
            {
                sumSubs = sumSubs + subs[i];
            }
            sumSubs = Math.Round(sumSubs, 2);
            //Console.WriteLine(sumSubs);

            //get difference between sum of the subs and order total
            double difference = Math.Round(sumSubs - order, 2);
            //Console.WriteLine(Math.Abs(difference));

            //check if diff is bigger than 0.01 then split the change up evenly as possible between subs else add or subtract change from just 1 (one) sub
            if (Math.Abs(difference) > 0.01)
            {
                int splitChangeBetween = Convert.ToInt32(Math.Round((Math.Abs(difference) / 0.01), 0));

                //if diff > 0 subtract diff from one or more subs
                //if diff < 0 add to abs of diff to subs
                //if diff = 0  || -0 (seriously small number) even split
                if (difference > 0)
                {
                    for (int i = 0; i < splitChangeBetween; i++)
                    {
                        subs[i] = Math.Round(subs[i] - 0.01, 2);
                    }
                }
                else if (difference < 0)
                {
                    for (int i = 0; i < splitChangeBetween; i++)
                    {
                        subs[i] = Math.Round(subs[i] + 0.01, 2);
                    }
                }
            }
            else
            {
                //if diff > 0 subtract diff from one or more subs
                //if diff < 0 add to abs of diff to subs
                //if diff = 0  || -0 (seriously small number) even split
                if (difference > 0)
                {
                    subs[0] = Math.Round(subs[0] - difference, 2);
                }
                else if (difference < 0)
                {
                    subs[0] = Math.Round(subs[0] + Math.Abs(difference), 2);
                }
            }

            //sum subs again
            sumSubs = 0;
            for(int i = 0; i < recipients; i++)
            {
                sumSubs = sumSubs + subs[i];
            }
            sumSubs = Math.Round(sumSubs, 2);

            
            if(sumSubs == order)
            {
                //Console.WriteLine("Split order between " + recipients + " people");
                //Console.WriteLine("[{0}]", string.Join(", ", subs));
                //Console.WriteLine("Order Total ");
                //Console.WriteLine(order);
                return subs;
            }
            else
            {
                Console.WriteLine("Error: them sum of the array doesn't equal the order");
                return subs;
            }
            
        }
    }
}
