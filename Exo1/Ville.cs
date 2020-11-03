using System;
using System.Text.RegularExpressions;

namespace Exo1
{
    public class Ville
    {
        private string codePostal;
        private string nom;
        private int nbHabitants;
        private int superficie;


        public Ville(string nom, int nbHabitants, int superficie, string codePostal)
        {
            //this.Majuscule --> déclenche le setter
            //this.miniscule --> déclenche la variable privée
            this.Nom = nom;
            this.NbHabitants = nbHabitants;
            this.Superficie = superficie;
            this.CodePostal = codePostal;
        }

        public string CodePostal
        {
            get => codePostal;
            set
            {
                Regex rgx = new Regex(@"^\d{5}$");
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Le code postal doit être composé de 5 chiffres");
                }
                else
                {
                    codePostal = value;
                }
            }
        }

        public string Nom
        {
            get => nom;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("valeur null interdite !");
                }
                nom = value;
            }
        }

        public int NbHabitants
        {
            get => nbHabitants;
            set
            {
                if (value < 0)
                {
                    throw new Exception("le nombre d'habitants ne peut pas être inférieur à 0");
                }
                nbHabitants = value;
            }
        }
        public int Superficie
        {
            get => superficie;
            set
            {
                if (value < 0)
                {
                    throw new Exception("lLa superficie ne peut pas être inférieure à 0");
                }
                superficie = value;
            }
        }

        public double CalculDensite()
        {
            return NbHabitants / Superficie;
        }

        public bool EstPlusDense(Ville v)
        {
            if(this.CalculDensite() > v.CalculDensite())
            {
                Console.WriteLine(this.Nom + " est plus dense que " + v.Nom);
                return true;
            }
            Console.WriteLine(v.Nom + " est plus dense que " + this.Nom);
            return false;
        }

        public bool EstDansLeMemeDepartement(Ville v)
        {
            if(this.CodePostal.Substring(0, 2) == v.CodePostal.Substring(0, 2))
            {
                Console.WriteLine(this.Nom + " est dans le même département que " + v.Nom);
                return true;
            }
            Console.WriteLine(this.Nom + " n'est pas dans le même département que " + v.Nom);
            return false;
            
            
        }

        public override string ToString()
        {
            return Nom + "\n" + "Nb habitants : " + NbHabitants + "\n" + "Superficie : " + Superficie + "\n" + "Code postal : " + CodePostal;
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                Console.WriteLine("True");
                return true;
            }
            Console.WriteLine("False");
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator >(Ville v1, Ville v2)
        {
            if(v1.NbHabitants > v2.NbHabitants)
            {
                Console.WriteLine(v1.Nom + " est plus grande que " + v2.Nom);
                return true;
            }
            else
            {
                Console.WriteLine(v1.Nom + " est plus petite que " + v2.Nom);
                return false;
            }
            
        }

        public static bool operator <(Ville v1, Ville v2)
        {
            if (v1.NbHabitants < v2.NbHabitants)
            {
                Console.WriteLine(v1.Nom + " est plus petite que " + v2.Nom);
                return true;
            }
            else
            {
                Console.WriteLine(v1.Nom + " est plus grande que " + v2.Nom);
                return false;
            }
        }

        public static bool operator >=(Ville v1, Ville v2)
        {
            if (v1.NbHabitants >= v2.NbHabitants)
            {
                Console.WriteLine(v1.Nom + " est plus grande ou de même taille que " + v2.Nom);
                return true;
            }
            else
            {
                Console.WriteLine(v1.Nom + " est plus petite ou de même taille que " + v2.Nom);
                return false;
            }
        }

        public static bool operator <=(Ville v1, Ville v2)
        {
            if (v1.NbHabitants <= v2.NbHabitants)
            {
                Console.WriteLine(v1.Nom + " est plus petite ou de même taille que " + v2.Nom);
                return true;
            }
            else
            {
                Console.WriteLine(v1.Nom + " est plus grande ou de même taille que " + v2.Nom);
                return false;
            }
        }

    }
}
