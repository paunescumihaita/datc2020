using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public static class StudentRepo
    {
        public static List<Student> st = new List<Student>();
       
        public static void adaugare(Student s)
        {
            st.Add(s);
        }
      
        
        
        

        public static Student cautare(int id)
        {
            foreach(Student s in st)
            {
                if (s.id == id)
                    return s;
            }
            return null;
        }
        public static void stergere(int id)
        {
            int i;
            foreach (Student s in st)
            {
                if (s.id == id)
                {
                    i = st.IndexOf(s);
                    st.RemoveAt(i);
                }
                    
            }

        }
        public static List<Student> afisare()
        {
            return st;
        }
        public static void update(int id, Student stud)
        {
            int i;
            foreach (Student s in st)
            {
                if (s.id == id)
                {
                    i = st.IndexOf(s);
                    st[i].nume = stud.nume;
                    st[i].prenume = stud.prenume;
                    st[i].an = stud.an;
                    st[i].mediegenerala = stud.mediegenerala;
                    st[i].facultate = stud.facultate;
                }

            }
        }
    }
}
