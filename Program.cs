using System;

namespace _4th_Degree__equation
{
    class Program
    {
        static void Main(string[] args)
        {


        //Przyjmowanie wartości

        Entering_Values:
            Console.WriteLine("Dana jest funkcja sześcienna");
            Console.Write("Podaj a:  ");
            string A = Console.ReadLine();

            while (A == "0")
            { //Sprawdzenie wartości A, która musi być różna od zera
                Console.WriteLine("Argument A nie może przyjmować wartości równej zero, podaj inny argument");
                goto Entering_Values;

            }

            Console.Write("Podaj b:  ");
            string B = Console.ReadLine();

            Console.Write("Podaj c:  ");
            string C = Console.ReadLine();

            Console.Write("Podaj d:  ");
            string D = Console.ReadLine();

            Console.Write("Podaj e:  ");
            string E = Console.ReadLine();


            //Konwertujemy zmienną tekstową na zmienno-przecinkową

            double a = Convert.ToDouble(A);
            double b = Convert.ToDouble(B);
            double c = Convert.ToDouble(C);
            double d = Convert.ToDouble(D);
            double e = Convert.ToDouble(E);

            //Obliczamy F,G,H

            double f = (c / a) - ((3 * Math.Pow(b, 2)) / (8 * Math.Pow(a, 2)));
            double g = (d / a) + (Math.Pow(b, 3) / (8 * Math.Pow(a, 3))) - ((b * c) / (2 * Math.Pow(a, 2)));
            double h = (e / a) - ((3 * Math.Pow(b, 4)) / (256 * Math.Pow(a, 4))) + ((Math.Pow(b, 2) * c) / (16 * Math.Pow(a, 3))) - ((b * d) / (4 * Math.Pow(a, 2)));

            //Definiujemy wartości Argumenty-PRIM

            double aprim = 1;
            double bprim = f / 2;
            double cprim = (Math.Pow(f, 2) - (4 * h)) / 16;
            double dprim = -(Math.Pow(g, 2) / 64);

            Console.WriteLine(aprim + "y^3 + " + bprim + "y^2 + " + cprim + "y + " + dprim + " = 0");

            double w = -(bprim / (3 * aprim));
            double p = ((3 * aprim * Math.Pow(w, 2)) + (2 * bprim * w) + cprim) / aprim;
            double q = ((aprim * Math.Pow(w, 3)) + (bprim * Math.Pow(w, 2)) + (cprim * w) + dprim) / aprim;


            //Obliczamy deltę i porównujemy ją z zerem

            double delta = (Math.Pow(q, 2) / 4) + (Math.Pow(p, 3) / 27);

            if (delta > 0)
            {
                DeltaWieksza(w, p, q, delta);
            }
            else if (delta < 0)
            {
                DeltaMniejsza(w, p, q, delta);
            }
            else if (delta == 0)
            {
                DeltaRowna(w, p, q, delta);
            }

        }

        static void DeltaWieksza(double w, double p, double q, double delta)
        {
            double u = Math.Cbrt((-q / 2.0) + Math.Sqrt(delta));
            double v = Math.Cbrt((-q / 2.0) - Math.Sqrt(delta));

            double x1 = u + v + w;
            double x2 = (-0.5 * (u + v)) + w;
            double x3 = x2;
            double urojona = (Math.Sqrt(3) / 2.0) * (u - v);
            Console.WriteLine("urojona: " + urojona);


            Console.WriteLine("Jeden pierwiastek rzeczyswisty i dwa zespolone.");
            Console.WriteLine("x1 = " + x1);
            Console.WriteLine(x2 + " + " + urojona + "i");
            Console.WriteLine(x3 + " - " + urojona + "i");



        }

        static void DeltaRowna(double w, double p, double q, double delta)
        {
            double x1 = w - 2 * Math.Cbrt(q / 2);
            double x23 = w + Math.Cbrt(q / 2);

            Console.WriteLine("Wynikiem równania są dwa pierwiastki rzeczywiste: " + x1 + " oraz drugi-podwójny: " + x23);
        }

        static void DeltaMniejsza(double w, double p, double q, double delta)
        {
            Console.WriteLine("Trzy pierowstki rzeczyswiste.");

            double fi = Math.Acos((3 * q) / (2 * p * Math.Sqrt(-p / 3.0)));
            Console.WriteLine($"fi= {fi}");

            double x1 = (w + (2 * Math.Sqrt(-p / 3.0)) * Math.Cos(fi / 3.0));
            double x2 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (2.0 * Math.PI) / 3.0));
            double x3 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (4.0 * Math.PI) / 3.0));
            Console.WriteLine("Trzy pierwiastki rzeczywiste:");
            Console.WriteLine("x1 = " + x1);
            Console.WriteLine("x2 = " + x2);
            Console.WriteLine("x3 = " + x3);



        }
    }
}

